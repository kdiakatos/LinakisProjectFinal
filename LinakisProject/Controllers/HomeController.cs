using LinakisProject.Business.Interfaces;
using LinakisProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace LinakisProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPageService _pageService;
        private readonly INewsApiConsumer _newsApiConsumer;
        public HomeController(ILogger<HomeController> logger, IPageService pageService, INewsApiConsumer newsApiConsumer)
        {
            _logger = logger;
            _pageService = pageService;
            _newsApiConsumer = newsApiConsumer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Page([FromRoute] int Id)
        {
            var model = await GetViewData(Id);
            return View(model);
        }

        public async Task<IActionResult> TechnologyAsync()
        {
            var model = await GetViewData(1);
            return View(model);
        }

        public async Task<IActionResult> EntertainmentAsync()
        {
            var model = await GetViewData(4);
            return View(model);
        }

        public async Task<IActionResult> MiscellaneousAsync()
        {
            var model = await GetViewData(3);
            return View(model);
        }
        public async Task<IActionResult> BusinessAsync()
        {
            var model = await GetViewData(2);
            return View(model);
        }

        private async Task<TitleViewModel> GetViewData(int pageId)
        {
            var titleViewModel = new TitleViewModel
            {
                Name = "N/A"
            };
            var title = await _pageService.GetById(pageId);
            if(!string.IsNullOrWhiteSpace(title))
            {
                var articles = await _newsApiConsumer.GetArticlesByTitle(title);
                titleViewModel.Name = title;
                titleViewModel.Articles = articles;
            }

            return titleViewModel;
        }
    }
}

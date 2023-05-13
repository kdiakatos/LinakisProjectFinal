using LinakisProject.Business.Interfaces;
using LinakisProject.Repository.Interfaces;
using System.Threading.Tasks;

namespace LinakisProject.Business.Services
{
    public class PageService : IPageService
    {
        private readonly IPageRepository _pageRepository;

        public PageService(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        public async Task<string> GetById(int id)
        {
            return await _pageRepository.GetById(id);
        }
    }
}

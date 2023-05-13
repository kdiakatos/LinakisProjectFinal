using LinakisProject.Business.Models;
using System.Collections.Generic;

namespace LinakisProject.Models
{
    public class TitleViewModel
    {
        public string Name { get; set; }

        public List<NewsModel> Articles { get; set; } = new List<NewsModel>();
    }
}

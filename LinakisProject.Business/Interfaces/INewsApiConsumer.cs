using LinakisProject.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinakisProject.Business.Interfaces
{
    public interface INewsApiConsumer
    {
        Task<List<NewsModel>> GetArticlesByTitle(string title);
    }
}

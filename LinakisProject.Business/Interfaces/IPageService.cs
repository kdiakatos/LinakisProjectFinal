using System.Threading.Tasks;

namespace LinakisProject.Business.Interfaces
{
    public interface IPageService
    {
        Task<string> GetById(int id);
    }
}

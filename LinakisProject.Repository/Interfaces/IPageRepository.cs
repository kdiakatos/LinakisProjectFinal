using System.Threading.Tasks;

namespace LinakisProject.Repository.Interfaces
{
    public interface IPageRepository
    {
        Task<string> GetById(int id);
    }
}

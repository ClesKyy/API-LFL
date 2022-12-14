using ProjetApiLFL.Models;

namespace ProjetApiLFL.Repositories
{
    public interface IResultRepository
    {
        Result GetResultById(int id);
        List<Result> GetResult();
        void CreateResult(Result result);
        void UpdateResult(Result newResult, int oldResultId);
        void DeleteResultById(int id);
    }
}

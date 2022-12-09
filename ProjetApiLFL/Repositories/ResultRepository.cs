using ProjetApiLFL.DbContexts;
using ProjetApiLFL.Dtos.Player;
using ProjetApiLFL.Dtos.Result;
using ProjetApiLFL.Models;

namespace ProjetApiLFL.Repositories
{
    public class ResultRepository
    {
        private readonly LFLDbContext _context;
        public ResultRepository(LFLDbContext context)
        {
            _context = context;
        }
        public Result GetResultById(int id)
        {
            return _context.Results.Where(t => t.ResultId == id).FirstOrDefault();
        }
        public void CreateResult(Result result)
        {
            _context.Results.Add(result);
            _context.SaveChanges();
        }
        public List<Result> GetResult()
        {
            return _context.Results.ToList();
        }
        public void UpdateResult(UpdateResultDto newResult, int oldResultId)
        {
            Result result = GetResultById(oldResultId);
            result.Score = newResult.Score;
            result.Winner = newResult.Winner;

            _context.Results.Update(result);
            _context.SaveChanges();
        }
        public void DeleteResult(int resultId)
        {
            Result result = GetResultById(resultId);
            _context.Results.Remove(result);
            _context.SaveChanges();
        }
    }
}

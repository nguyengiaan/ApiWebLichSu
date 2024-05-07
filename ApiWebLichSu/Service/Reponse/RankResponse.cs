using ApiWebLichSu.Data;
using ApiWebLichSu.Model;
using ApiWebLichSu.Model.DTO;
using ApiWebLichSu.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApiWebLichSu.Service.Reponse
{
    public class RankResponse : IRanking
    {
        private readonly MyDbcontext _context;

        public RankResponse(MyDbcontext context)
        { 
            _context=context;
        }   
        public async Task<bool> AddScore(RankVm rankVm)
        {
            try
            {

                var a=await _context.Rank.FirstOrDefaultAsync(e=>e.Id==rankVm.Id);
                if(a == null)
                {
                    Ranking ranking = new Ranking();
                    ranking.Id= rankVm.Id;
                    ranking.score = rankVm.score;
                    _context.Rank.Add(ranking);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    a.score += rankVm.score;
                    _context.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                return false;

            }
        }

        public async Task<List<RankVM2>> OrderRank()
        {
            try
            {
                var result = await (from rank in _context.Rank
                                    join user in _context.Appuser
                                    on rank.Id equals user.Id
                                    orderby rank.score descending
                                    select new RankVM2
                                    {
                                        score = rank.score,
                                        LastName = user.LastName
                                    })
                                    .Take(4)
                                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine($"An error occurred: {ex.Message}");

                // Return an empty list or rethrow the exception as needed
                return new List<RankVM2>();
            }


        }
    }
}

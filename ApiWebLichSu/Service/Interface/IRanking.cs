using ApiWebLichSu.Model;
using ApiWebLichSu.Model.DTO;

namespace ApiWebLichSu.Service.Interface
{
    public interface IRanking
    {
        public Task<bool> AddScore(RankVm rankVm);

        public Task<List<RankVM2>> OrderRank();
    }
}

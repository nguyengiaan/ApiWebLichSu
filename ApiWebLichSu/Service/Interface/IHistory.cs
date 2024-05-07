using ApiWebLichSu.Model;
using ApiWebLichSu.Model.DTO;

namespace ApiWebLichSu.Service.Interface
{
    public interface IHistory
    {
        List<HistoryVM> GetAll();
        HistoryVM GetbyId(int id);
        public Task< bool> Add(HistoryVM2 vm);
        void Update(HistoryVM vm);
        public Task<bool> Delete(int id);
        public Task<bool> Update(HistoryVM2 vm2,int idhis );
    }
}

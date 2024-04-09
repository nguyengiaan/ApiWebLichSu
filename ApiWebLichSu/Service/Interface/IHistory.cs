using ApiWebLichSu.Model;
using ApiWebLichSu.Model.DTO;

namespace ApiWebLichSu.Service.Interface
{
    public interface IHistory
    {
        List<HistoryVM> GetAll();
        HistoryVM GetbyId(int id);
        HistoryVM Add(HistoryVM vm);
        void Delete(int id);
        void Update(HistoryVM vm);
    }
}

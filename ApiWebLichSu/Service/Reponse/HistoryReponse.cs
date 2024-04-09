using ApiWebLichSu.Data;
using ApiWebLichSu.Model;
using ApiWebLichSu.Service.Interface;

namespace ApiWebLichSu.Service
{

    public class HistoryReponse : IHistory

    {
        public readonly MyDbcontext _context;
        public HistoryReponse(MyDbcontext context)
        {
            _context = context;
        }
        public HistoryVM Add(HistoryVM vm)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<HistoryVM> GetAll()
        {
            var listhistory = _context.History.Select(h=>new HistoryVM
            {
                ID_HISTORY=h.ID_HISTORY,
                CONTENT=h.CONTENT,
                TITLE=h.TITLE,  
            }); 
            return listhistory.ToList();

        }

        public HistoryVM GetbyId(int id)
        {
            var loai = _context.History.SingleOrDefault(lo => lo.ID_HISTORY == id);
            if (loai != null) 
            {
                return new HistoryVM
                {
                    ID_HISTORY = loai.ID_HISTORY,
                    CONTENT = loai.CONTENT,
                    TITLE = loai.TITLE,
                };
            }
            else
            {
                return null;
            }
        }

        public void Update(HistoryVM vm)
        {
            throw new NotImplementedException();
        }



    }
}

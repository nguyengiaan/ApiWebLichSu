using ApiWebLichSu.Data;
using ApiWebLichSu.Model;
using ApiWebLichSu.Model.DTO;
using ApiWebLichSu.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApiWebLichSu.Service
{

    public class HistoryReponse : IHistory

    {
        public readonly MyDbcontext _context;
        public HistoryReponse(MyDbcontext context)
        {
            _context = context;
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


        public async Task<bool> Add(HistoryVM2 vm)
        {
            try
            {
                History history = new History();
                history.Id = vm.Id;
                history.TITLE = vm.TITLE;
                history.ID_CATOGERY = vm.ID_CATOGERY;
                history.CONTENT = vm.CONTENT;
                await _context.History.AddAsync(history);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var existingHistory = await _context.History.FindAsync(id);

                if (existingHistory != null)
                {
                    _context.History.Remove(existingHistory);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false; // Trả về false nếu không tìm thấy đối tượng cần xóa
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ (nếu cần)
                return false; // Trả về false nếu có lỗi xảy ra
            }
        }

        public async Task<bool> Update(HistoryVM2 vm2, int idhis)
        {
            
            try
            {
                var history=await _context.History.FirstOrDefaultAsync(h=>h.ID_HISTORY== idhis);
                 if (history != null)
                {
                    history.TITLE = vm2.TITLE;
                    history.CONTENT = vm2.CONTENT;
                    await _context.SaveChangesAsync();
                    return true;
                }
                
            }
            catch(Exception ex)
            {
                return false;
            }
            return false;
        

        }
    }
}

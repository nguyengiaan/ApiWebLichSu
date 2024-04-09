using ApiWebLichSu.Data;
using ApiWebLichSu.Model;
using ApiWebLichSu.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace ApiWebLichSu.Service
{
    public class CatogeryResponse : ICatogerResponse
    {
        public readonly MyDbcontext _context;

        public CatogeryResponse(MyDbcontext context)
        {
            _context=context;
        }
        public CatogeryVM Add(CatogeryVM vm)
        {
            try
            {
                Catogery catogery = new Catogery ();
                catogery.NAME_CATOGERY = vm.NAME_CATOGERY;
                _context.Add(catogery);
                _context.SaveChanges();
                return new CatogeryVM
                {
                    NAME_CATOGERY = vm.NAME_CATOGERY,
                };
            }
            catch 
            {
                return null;
            }
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CatogeryVM_1> GetCatogeries()
        {
            var listcato = from catogery in _context.Catogery
                           join history
                           in _context.History
                           on catogery.ID_CATOGERY equals history.ID_CATOGERY
                           select new CatogeryVM_1
                           {
                               NAME_CATOGERY = catogery.NAME_CATOGERY.ToString(),
                               TITLE = history.TITLE,
                               ID_HISTORY=history.ID_HISTORY,
                           };
            return listcato.ToList();
        }

        public List<CatogeryVM> GetCatogeriesid(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CatogeryVM vm)
        {
            throw new NotImplementedException();
        }

    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiblotekaWeb.Areas.admin.Models;
using BiblotekaWeb.Areas.admin.Data;

namespace BiblotekaWeb.Areas.admin.Data
{
    public class HuazoService: IHuazoService
    {

        private readonly BiblotekaWebContext _context;

        public HuazoService(BiblotekaWebContext context)
        {
            _context = context;
        }

        public bool DeleteHuazimin(int id)
        {
            var huazimi = _context.Huazimis.FirstOrDefault(x => x.HuazimiId == id);
            if (huazimi == null) return false;
            _context.Huazimis.Remove(huazimi);
            _context.SaveChanges();
            return true;
        }

        public List<Huazimi> GetAllHuazimet()
        {
            return _context.Huazimis.ToList();
        }

        public Huazimi GetHuazimetById(int id)
        {
            return _context.Huazimis.FirstOrDefault(x => x.HuazimiId == id);
        }

        public void PerditesoHuazimin(Huazimi huazo)
        {
            _context.Huazimis.Update(huazo);
            _context.SaveChangesAsync();
        }

        public void ShtoHuazimin(Huazimi huazo)
        {
            _context.Huazimis.Add(huazo);
            _context.SaveChanges();
        }

       
    }
}

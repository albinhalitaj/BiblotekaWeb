using System.Collections.Generic;
using System.Linq;
using BiblotekaWeb.Areas.admin.Models;

namespace BiblotekaWeb.Areas.admin.Data
{
    public class KlientiService : IKlientiService
    {
        private readonly BiblotekaWebContext _context;

        public KlientiService(BiblotekaWebContext context)
        {
            _context = context;
        }

        public List<Klienti> GetAllKlients()
        {
            return _context.Klientis.ToList();
        }

        public void ShtoKlient(Klienti klienti)
        {
            _context.Klientis.AddAsync(klienti);
            _context.SaveChangesAsync();
        }

        public Klienti GetKlientById(string id)
        {
            return _context.Klientis.FirstOrDefault(x => x.KlientiId == id);
        }

        public void PerditesoKlient(Klienti klienti)
        {
            _context.Klientis.Update(klienti);
            _context.SaveChangesAsync();
        }

        public void DeleteKlient(string id)
        {
            var klienti = _context.Klientis.FirstOrDefault(x => x.KlientiId == id);
            if (klienti!=null) _context.Klientis.Remove(klienti);
        }
    }
}

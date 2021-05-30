using System.Collections.Generic;
using System.Linq;
using BiblotekaWeb.Areas.admin.Models;

namespace BiblotekaWeb.Areas.admin.Data
{
    public class LibriService : ILibriService
    {
        private readonly BiblotekaWebContext _context;

        public LibriService(BiblotekaWebContext context)
        {
            _context = context;
        }

        public List<Libri> GetAllLibri()
        {

            return _context.Libris.ToList();
        }

        public void ShtoLibrin(Libri libri)
        {
            _context.Libris.AddAsync(libri);
            _context.SaveChangesAsync();
        }

        public Libri GetLibriById(string id)
        {
            return _context.Libris.FirstOrDefault(x => x.LibriId == id);
        }

        public void PerditesoLibrin(Libri libri)
        {
            _context.Libris.Update(libri);
            _context.SaveChangesAsync();
        }

        public void DeleteLibrin(string id)
        {
            var libri = _context.Libris.FirstOrDefault(x => x.LibriId == id);
            if (libri != null) _context.Libris.Remove(libri);
        }
    }
}

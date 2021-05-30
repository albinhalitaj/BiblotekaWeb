using System.Collections.Generic;
using BiblotekaWeb.Areas.admin.Models;

namespace BiblotekaWeb.Areas.admin.Data
{
    public interface ILibriService
    {
        List<Libri> GetAllLibri();
        void ShtoLibrin(Libri libri);
        Libri GetLibriById(string id);
        void PerditesoLibrin(Libri libri);
        void DeleteLibrin(string id);
    }
}
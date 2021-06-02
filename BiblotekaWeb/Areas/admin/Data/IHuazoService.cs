using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiblotekaWeb.Areas.admin.Models;

namespace BiblotekaWeb.Areas.admin.Data
{
    public interface IHuazoService
    {
        List<Huazimi> GetAllHuazimet();
        void ShtoHuazimin(Huazimi huazo);
        Huazimi GetHuazimetById(int id);
        bool DeleteHuazimin(int id);
        void PerditesoHuazimin(Huazimi huazo);
    }
}

﻿using System.Collections.Generic;
using BiblotekaWeb.Areas.admin.Models;

namespace BiblotekaWeb.Areas.admin.Data
{
    public interface IKlientiService
    {
        List<Klienti> GetAllKlients();
        void ShtoKlient(Klienti klienti);
        Klienti GetKlientById(string id);
        void PerditesoKlient(Klienti klienti);
        void DeleteKlient(string id);
    }
}
﻿using System;
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
            _context.Klientis.Add(klienti);
            _context.SaveChanges();
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

        public bool DeleteKlient(string id)
        {
            var status = false;
            var klienti = _context.Klientis.FirstOrDefault(x => x.KlientiId == id);
            if (klienti == null) return status;
            try
            {
                _context.Klientis.Remove(klienti);
                _context.SaveChanges();
                status = true;
            }
            catch (Exception e)
            {
                status = false;
            }
            return status;
        }

        public Stafi GetStafi(int id)
        {
            return _context.Stafis.Single(x => x.StafiId == id);
        }
    }
}

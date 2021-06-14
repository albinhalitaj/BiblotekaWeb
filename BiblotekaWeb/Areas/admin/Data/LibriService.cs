﻿using System;
using System.Collections.Generic;
using System.Linq;
using BiblotekaWeb.Areas.admin.Models;
using Microsoft.EntityFrameworkCore;

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
            return _context.Libris.Include(x=>x.Kategoria)
                                .Include(x=>x.Gjuha)
                                .ToList();
        }

        public void ShtoLibrin(Libri libri)
        {
            _context.Add(libri);
            _context.SaveChanges();
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

        public bool DeleteLibrin(string id)
        {
            var libri = _context.Libris.FirstOrDefault(x => x.LibriId == id);
            var status = false;
            if (libri != null)
            {
                try
                {
                    _context.Libris.Remove(libri);
                    _context.SaveChanges();
                    status = true;
                }
                catch (Exception)
                {
                    status = false;
                }
            }
            return status;
        }
    }
}

﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>
    {
        public new Usuario Add(Usuario usuario)
        {
            using (_context = new AppDbContext())
            {
                usuario.senha = Encrypt(usuario.senha);
                usuario.ativo = true;
                _context.Usuario.Add(usuario);
                _context.SaveChanges();
            }
            Dispose();
            return usuario;
        }

        public new Usuario Edit(Usuario usuario)
        {
            using (_context = new AppDbContext())
            {
                usuario.senha = Encrypt(usuario.senha);
                _context.Entry(usuario).State = EntityState.Modified;
                _context.SaveChanges();
            }
            Dispose();
            return usuario;
        }


        private string Encrypt(string str) => Cipher.Encrypt(str,"user");
    }
}
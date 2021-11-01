using Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>
    {
        public new Usuario Add(Usuario usuario)
        {
            using (_context = new AppDbContext())
            {
                usuario.senha = Encrypt(usuario.senha, usuario.email);
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
                if (!string.IsNullOrWhiteSpace(usuario.senha))
                {
                    usuario.senha = Encrypt(usuario.senha, usuario.email);
                }
                else
                {
                    usuario.senha = _context.Usuario.AsNoTracking().FirstOrDefault(x => x.id == usuario.id).senha;
                }

                _context.Entry(usuario).State = EntityState.Modified;
                _context.SaveChanges();
            }
            Dispose();
            return usuario;
        }

        public Usuario Validar(string email, string senha)
        {
            Usuario _ret = new ();
            UsuarioRepository rep = new();

            _ret = rep.Get(x => x.email == email && x.senha == Encrypt(senha, email));

            Dispose();
            return _ret;
        }


        private string Encrypt(string str, string encode) => Cipher.Encrypt(str,"user"+encode);
    }
}

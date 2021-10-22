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
                usuario.senha = Encrypt(usuario.senha, usuario.email);
                _context.Entry(usuario).State = EntityState.Modified;
                _context.SaveChanges();
            }
            Dispose();
            return usuario;
        }

        public Pessoa Validar(string email, string senha)
        {
            Pessoa _ret = new ();
            PessoaRepository rep = new();

            _ret = rep.Get(x => x.usuarioObj.email == email && x.usuarioObj.senha == Encrypt(senha, email));

            Dispose();
            return _ret;
        }


        private string Encrypt(string str, string encode) => Cipher.Encrypt(str,"user"+encode);
    }
}

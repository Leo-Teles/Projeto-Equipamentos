using Patrimonio.Contexts;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonio.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly PatrimonioContext ctx;

        public UsuarioRepository(PatrimonioContext appContext)
        {
            ctx = appContext;
        }

        public Usuario Login(string email, string senha)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);


            if (usuario.Senha.Substring(0)!="$" && usuario.Senha.Substring(3) != "$")
            {
                var U = new UsuariosController(ctx);

                usuario.Senha = Criptografis.GeraHash(usuario.Senha);

                U.PutUsuario(usuario.Id, usuario);

            }


            if (usuario != null)
            {
                // Com o usuario encontrado temos a hash do banco para poder comparar com a senha vindo do formulário
                bool comparado = Criptografis.Comparar(senha, usuario.Senha);
                if (comparado)
                    return usuario;
            }




            return null;
        }
    }
}

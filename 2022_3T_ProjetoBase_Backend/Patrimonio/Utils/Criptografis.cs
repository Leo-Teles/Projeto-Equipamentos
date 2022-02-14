using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonio.Utils
{
    public static class Criptografis
    {

        public static string GeraHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool Comparar(string senhaLogin, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaLogin, senhaBanco);
        }

        
    }
}

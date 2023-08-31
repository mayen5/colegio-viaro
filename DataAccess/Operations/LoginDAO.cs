using DataAccess.Context;
using DataAccess.Models;
using System.Linq;

namespace DataAccess.Operations
{
    public class LoginDAO
    {
        public ColegioContext contexto = new ColegioContext();


        public Login login(string usuario, string pass)
        {
            var logIn = contexto.Logins.Where(l => l.Usuario == usuario && l.Pass == pass).FirstOrDefault();

            return logIn;
        }
    }
}

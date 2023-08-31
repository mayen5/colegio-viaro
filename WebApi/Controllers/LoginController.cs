using DataAccess.Models;
using DataAccess.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private LoginDAO loginDAO = new LoginDAO();

        [HttpPost("autentication")]
        public string login([FromBody] Login logIn)
        {
            var logInUser = loginDAO.login(logIn.Usuario, logIn.Pass);
            
            if (logInUser != null)
            {
                return logInUser.Usuario;
            }
            else
            {
                return null;
            }
        }


    }
}

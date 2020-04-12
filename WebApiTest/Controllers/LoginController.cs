using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private ILogger<LoginController> _logger;
        private Login _login;
        public LoginController(ILogger<LoginController> logger, Login login)
        {
            _logger = logger;
            _login = login;
        }

        [HttpPost]
        public Login Post(Login usr)
        {

            if (usr.Validate())
            {
                _logger.LogInformation("Login Succeded", new { usr.Usr_id});
                _login = usr;
                _login.Usr_id = "1";
                _login.Usr_Name = "Administrador";
            }
            return _login;
        }
        [HttpGet]
        public Login Get()
        {
            _login.Usr_id = "-1";
            _login.Usr_Name = "No existe el usuario";
            return _login;
        }
    }
}
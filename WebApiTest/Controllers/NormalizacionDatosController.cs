using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiTest.Services;

namespace WebApiTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NormalizacionDatosController : ControllerBase
    {
        private ILogger<NormalizacionDatosController> _logger;
        private NormalizacionDatos _datos;
        public NormalizacionDatosController(ILogger<NormalizacionDatosController> logger,NormalizacionDatos datos)
        {
            _logger = logger;
            _datos = datos;
        }
        [HttpGet("{name}")]
        public NormalizacionInfo Get(string name)
        {
            return _datos.Search(name);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Logging;

namespace WebApiTest.Models
{
    public class ServiceLayer
    {
        private ServiceModel _model;

        private ILogger<ServiceLayer> _logger;
        public ServiceLayer(ServiceModel Model,ILogger<ServiceLayer> logger)
        {
            _model = Model;
            _logger = logger;
        }
        public ServiceModel ServiceRequest(string resourceUrl)
        {
            HttpWebRequest req = WebRequest.Create(resourceUrl) as HttpWebRequest;
            try
            {
                _logger.LogInformation("Enviando solicitud al endpoint:"+ resourceUrl);
                req.Method = "GET";
                var resp = req.GetResponse() as HttpWebResponse;
                if(resp.StatusCode==HttpStatusCode.OK)
                {
                    var stream = new StreamReader(resp.GetResponseStream());
                    var str = stream.ReadToEnd();
                    _model = JsonConvert.DeserializeObject<ServiceModel>(str);
                }
                _logger.LogInformation("Solicitud resuelta ok");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError("Error en solicitudl al endpoint.", new { resourceUrl });
                _logger.LogError(ex.Message);
                _model.cantidad = 0;
                _model.total = 0;
            }
            return _model;
        }
    }
    public class ServiceModel
    {

        public List<Provincia> provincias { get; set; }        
        public int cantidad { get; set; }
        public int total { get; set; }
        public int inicio { get; set; }
        public Parametros parametros { get; set; }
    }

    public class Provincia 
    {
        public string nombre { get; set; }
        public int id { get; set; }
        public Centroide centroide { get; set; }
    }

    public class Centroide 
    {
        public Double lat { get; set; }
        public Double lon { get; set; }
    }
    public class Parametros
    {
        public string nombre { get; set; }
    }

}

using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Models;

namespace WebApiTest.Services
{
    public class NormalizacionDatos
    {
        private ServiceLayer _service;
        private NormalizacionInfo _info;
        public NormalizacionDatos(ServiceLayer service,NormalizacionInfo info)
        {
            _service = service;
            _info = info;
        }

        public NormalizacionInfo Search(string KeyName)
        {
            string requestUrl = "https://apis.datos.gob.ar/georef/api/provincias?nombre=" + KeyName;
            ServiceModel mod = _service.ServiceRequest(requestUrl);
            if (mod.provincias.Count > 0)
            {
                _info.Province_Name = mod.provincias[0].nombre;
                _info.Latitude = mod.provincias[0].centroide.lat;
                _info.Longitude = mod.provincias[0].centroide.lon;
            }
            else
            {
                throw new ArgumentException("Error al buscar - Dato no válido");
            }
            return _info;
        }
    }

    public class NormalizacionInfo : IEquatable<NormalizacionInfo>
    {
        public String Province_Name { get; set; }
        public Double Latitude { get; set; }
        public Double Longitude { get; set; }

        public static bool Equals([AllowNull] NormalizacionInfo x, [AllowNull] NormalizacionInfo y)
        {
            return ((x.Province_Name == y.Province_Name) && 
                    (x.Latitude == y.Latitude) && 
                    (x.Longitude == y.Longitude));
        }

        public int GetHashCode([DisallowNull] NormalizacionInfo obj)
        {
            return this.GetHashCode();
        }

        bool IEquatable<NormalizacionInfo>.Equals(NormalizacionInfo other)
        {
            return ((this.Province_Name == other.Province_Name) &&
                    (this.Latitude == other.Latitude) &&
                    (this.Longitude == other.Longitude));
        }
    }
}

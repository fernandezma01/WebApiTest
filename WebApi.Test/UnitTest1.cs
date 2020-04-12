using Microsoft.Extensions.Logging;
using NUnit.Framework;
using WebApiTest;
using WebApiTest.Services;
using WebApiTest.Models;
using NuGet.Frameworks;

namespace WebApi.Test
{
    public class Tests
    {
        private Login login;
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void LoginPass()
        {
            login = new Login() { Usr_id = "Admin", Psw = "Admin1*" };
            Assert.IsTrue(login.Validate());
        }
        [Test]
        public void LoginFail()
        {
            login = new Login() { Usr_id = "Jose", Psw = "Admin1*" };
            Assert.IsFalse(login.Validate());
        }
        [Test]
        public void ProvinceCheckPass()
        {
            ILoggerFactory factory = new LoggerFactory();
            ILogger<ServiceLayer> logger = factory.CreateLogger<ServiceLayer>();
            NormalizacionInfo obj1 = new NormalizacionInfo()
            {
                Province_Name = "Salta",
                Latitude = -24.2991344492002,
                Longitude = -64.8144629600627
            };
            NormalizacionDatos _dTest1 = new NormalizacionDatos(new ServiceLayer(new ServiceModel(), logger), new NormalizacionInfo());
            NormalizacionInfo obj2 = _dTest1.Search("Salta");
            //Assert.IsEqual(obj1,obj2);
            Assert.IsTrue(NormalizacionInfo.Equals(obj1, obj2));
        }
        [Test]
        public void ProvincheCheckFail()
        {
            ILoggerFactory factory = new LoggerFactory();
            ILogger<ServiceLayer> logger = factory.CreateLogger<ServiceLayer>();
            NormalizacionInfo obj1 = new NormalizacionInfo()
            {
                Province_Name = "Salta",
                Latitude = -24.2991344492002,
                Longitude = -64.8144629600627
            };
            NormalizacionDatos _dTest1 = new NormalizacionDatos(new ServiceLayer(new ServiceModel(), logger), new NormalizacionInfo());
            NormalizacionInfo obj2 = _dTest1.Search("Chaco");
            //Assert.IsEqual(obj1,obj2);
            Assert.IsFalse(NormalizacionInfo.Equals(obj1, obj2));
        }
    }
}
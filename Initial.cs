using Microsoft.Extensions.PlatformAbstractions;

namespace MHR.API.ApimAutomation
{
    public class Initial
    {
        //private readonly IConfiguration _configuration;
        //public Initial(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        public string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = "MHR.API.ApimAutomation.xml";
                return Path.Combine(basePath, fileName);
            }
        }
    }
}

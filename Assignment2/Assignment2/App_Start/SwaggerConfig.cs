using System.Web.Http;
using WebActivatorEx;
using Assignment2;
using Swashbuckle.Application;
using System.Web.Http.Routing;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Assignment2
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>c.SingleApiVersion("v1", "Assignment2"))
                .EnableSwaggerUi();
        }
    }
}

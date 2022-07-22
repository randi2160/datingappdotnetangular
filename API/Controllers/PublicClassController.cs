using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("[controller]")]
    public class PublicClassController : Controller
    {
        private readonly ILogger<PublicClassController> _logger;

        public PublicClassController(ILogger<PublicClassController> logger)
        {
            _logger = logger;
        }

        private void GetAllPublicClassInDoFixture()
        {
        Assembly a = Assembly.LoadFile(@"C:\Users\kheml\DatingApp\API\fitdll");
        Type[] types = a.GetTypes();
        foreach (Type type in types)
        {
            if (!type.IsPublic)
            {
                continue;
            }

            MemberInfo[] members = type.GetMethods();
            foreach (MemberInfo member in members)
            {
                Console.WriteLine(type.Name + "." + member.Name);
            }
        }
    
        }

        private static void ShowMethods(Type type)
        {
             foreach (var method in type.GetMethods())
        {
            var parameters = method.GetParameters();
            var parameterDescriptions = string.Join
                (", ", method.GetParameters()
                             .Select(x => x.ParameterType + " " + x.Name)
                             .ToArray());

            Console.WriteLine("{0} {1} ({2})",
                              method.ReturnType,
                              method.Name,
                              parameterDescriptions);
        }
        }


        [HttpGet]
        public string GetAllPublicClassInDoFixtures()
        {
           GetAllPublicClassInDoFixture();
            return "obje";
        }

        

        
    }
}
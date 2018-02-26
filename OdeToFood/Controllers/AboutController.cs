using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    [Route("company/[controller]/[action]")]
    public class AboutController
    {

        public string Phone()
        {
            return "+7 999 1111111";
        }

        public string Address()
        {
            return "Russia";
        }
    }
}

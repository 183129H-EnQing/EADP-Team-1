using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyCircles.DAL;

namespace MyCircles.Controller
{
    public class EventController : ApiController
    {
        [HttpPost]
        [Route("lol")]
        public string hello()
        {
            return "hello";
        }
    }
}

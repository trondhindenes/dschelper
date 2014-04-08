using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DSCHelper.Models;

namespace DSCHelper.Controllers
{
    public class HostToGuidController : ApiController
    {
        public IHttpActionResult GetHostGUid(String HostName)
        {
            HostGuidReader reader = new HostGuidReader();

            string myString = reader.ReadHostGuid(HostName);
            if (myString == null)
            {
                return NotFound();

            }
            else 
            {
                return Ok(myString);
            }
            
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ActiveMQProducerWebAPI.Controllers
{
    public class ActiveMQProducerController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [Route("api/postrequest")]
        [HttpPost]
        public string PostRequest(string req)
        {
            return "Success!";
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [Route("api/producerequest")]
        [HttpGet]
        public string ProduceRequest()
        {
            return "";
        }

    }
}

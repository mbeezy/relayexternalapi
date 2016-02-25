using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SurfSpots.Contracts;

namespace surfchecker.Controllers
{
    public class SurfCheckerController : ApiController
    {
        [HttpGet]
        [Route("api/surfchecker")]
        public string Get()
        {
            return "Hi TDers";
        }

        [HttpGet]
        [Route("api/surfchecker/sandiego")]
        public IEnumerable<SurfSpot> GetSanDiegoSpots()
        {
            List<SurfSpot> sanDiegoSpots = new List<SurfSpot>();

            using (var spotProxy = new SanDiegoSpotsProxy())
            {
                sanDiegoSpots = spotProxy.GetSanDiegoSpots();
            }

            return sanDiegoSpots.AsEnumerable();
        }
    }
}

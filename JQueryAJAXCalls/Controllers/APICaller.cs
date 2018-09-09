using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace JQueryAJAXCalls.Controllers
{
    public class APICallerController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Soldier> Get()
        {
            var retval = new List<Soldier>
            {
                new Soldier {Id = 1, Name = "Patton", Rank = "5-star General", SerialNumber = "1234-9987"},
                new Soldier {Id = 2, Name = "Halsey", Rank = "Admiral", SerialNumber = "7785-9587"},
                new Soldier {Id = 3, Name = "MacArthur", Rank = "3-star General", SerialNumber = "1245-9636"}
            };

            return retval;
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            // I can just return the object directly (no need to transform into JSON explicitly) inside of an
            // Ok ActionResult
            var retSoldier = new Soldier {Id = id, Name = "Patton", Rank = "General", SerialNumber = "1234-9987"};
            if (id==99)
            {
                return NotFound(); // just for the heck of it we'll return NotFound(404) if soldier id = 99
            }
            else
            {
                return Ok(retSoldier); // return ok (200)
            }
        }

        [Route("api/APICaller/{id}/rank")]
        public string GetRank(int id)
        {
            var returnVal = "";

            switch(id) {
            case 1:
                returnVal = "5-star General";
                break;
            case 2:
                returnVal = "Admiral";
                break;
            case 3:
                returnVal = "3-star General";
                break;
            default:
                break;
            }
            return returnVal ;
        }
        //
        [Route("api/APICaller/{id}/soldierJSON")]
        public string GetSoldierJSONFormat(int id)
        {
            var retSoldier = new Soldier {Id = id, Name = "Patton", Rank = "General", SerialNumber = "1234-9987"};
            var retJSON = JsonConvert.SerializeObject(retSoldier);
            return retJSON;


        }

        // POST api/<controller>
        public IHttpActionResult Post(Soldier soldier)
        {
            if(soldier.Rank != null && soldier.Name != null && soldier.SerialNumber != null)
            {
                var rank = soldier.Rank;
                var name = soldier.Name;
                var serialNumber = soldier.SerialNumber;
                return Ok( JsonConvert.SerializeObject(new Soldier {  Id = 0, Name=soldier.Rank, Rank = soldier.Name, SerialNumber=soldier.SerialNumber}));
            }
            else
            {
                return BadRequest();
            }
        }


    }
    public class Soldier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public string SerialNumber { get; set; }
    }}
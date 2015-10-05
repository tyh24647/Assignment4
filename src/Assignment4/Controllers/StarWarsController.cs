using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using System.Net;
//using Assignment4.Model;

namespace Assignment4.Controllers {

    
    //Stores character objects with associated names 
    //and favorite characters
    public class StarWarsCharacter {
        public string Name { get; set; }
        public string Character { get; set; }
        public string NumberOfTimes { get; set; }
    }


    // Controls data values stored in the local server
    [Route("api/[controller]")]
    public class ValuesController : Controller {


        public static List<StarWarsCharacter> characters = new List<StarWarsCharacter>() {
            new StarWarsCharacter() {
                Name = "Tyler Hostager",
                Character = "Obi-Wan Kanobi",
                NumberOfTimes = "25"
            }, new StarWarsCharacter() {
                Name = "Jimbob TestPerson",
                Character = "Luke Skywalker",
                NumberOfTimes = "45"
            }
        };

        
        // List of values to populate server
        public static List<string> values = new List<string>() {
            "Test1", "test2", "tyler", "test4", "example value"
        };
        
            
        // Checks for valid string submissions for new data values
        public bool IsValidSubmission(string value) {
            return (value != null && value.Length != 0);
        }
        

        // Checks for valid integer submissions for new data values
        public bool IsValidSubmission(int id) {
            return (id >= 0 && id < characters.Count);
            //return (id >= 0 && id < values.Count);
        }
        
              
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get() {
            return values;
        }


        // Returns associated Star Wars character
        [HttpGet]
        [Route("/")]
        public StarWarsCharacter GetStarWarsCharacter() {
            return new StarWarsCharacter() {
                Name = "Tyler",
                Character = "Obi-Wan Kanobi",
                NumberOfTimes = "23"
            };
        }


        // Patch /api/characters/5
        [HttpPatch("{id}")]
        public StarWarsCharacter Patch(int id, [FromBody]StarWarsCharacter character) {
            if (!ModelState.IsValid) {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            } if (id < 0 || id >= characters.Count /*values.Count*/) {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }

            characters[id] = character;
            //values[id] = character;

            return character;
        }



      
        /*
        // Patch api/values
        [HttpPatch]
        public void Patch([FromBody]string value) {
            if (!IsValidSubmission(value)) {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return;
            }


            values.Add(value);
        }
        */
       


            /*
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id) {
            if (!IsValidSubmission(id)) {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return "ERROR: Invalid index.\nNo data found at index "
                    + "\"" + id + "\"";
            }

            //return 
            //return values[id];
        }
        */

            /*
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value) {
            if (IsValidSubmission(value)) {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return;
            }
            
            values.Add(value);
        }

*/
        /** TEST */
        [HttpPost]
        public StarWarsCharacter Post([FromBody]StarWarsCharacter character) {
            if (!ModelState.IsValid) {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }

            characters.Add(character);
            return character;
        }
        /**/



            /*
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
            if (IsValidSubmission(id)) {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return;
            }

            values.RemoveAt(id);
        }
        */

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value) {
            //
        }
        
        // TEST
        private void Parsing() {
            string toParse = "fifty";

            int myBetterInt;


            /*
            // Throws exception
            var myNewInt = int.Parse(toParse);
            */

            // Better way to do it
            if (int.TryParse(toParse, out myBetterInt)) {
                // parsed correctly
            } else {
                // didn't parse correctly
            }
        }
    }
}

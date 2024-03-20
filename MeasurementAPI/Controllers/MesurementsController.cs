using MeasurementsLib;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeasurementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesurementsController : ControllerBase
    {
        private MeasurmentRepository repo;

        public MesurementsController(MeasurmentRepository repo)
        {
            this.repo = repo;
        }




        // GET: api/<MesurementsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public ActionResult<IEnumerable<Measurement>> Get()
        {
            IEnumerable<Measurement> me = repo.GETALL();
            if(me.Any())
            {
                return Ok(me);
            }
            else
            {
                return NoContent();
            }
           
        }

        // GET api/<MesurementsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public ActionResult<Measurement> Get(int id)
        {
            Measurement measurement =repo.GetById(id);
            if(measurement==null)
            {
                return NoContent();
            }
            return Ok(measurement);

        }

        // POST api/<MesurementsController>
        [HttpPost]
        public Measurement Post(Measurement measurement)
        {
           repo.Add(measurement);
            return measurement;
        }

        // PUT api/<MesurementsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string val)
        {
        }

        // DELETE api/<MesurementsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Delete(id);
        }
    }
}

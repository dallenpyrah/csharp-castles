using System.Collections.Generic;
using castles.Models;
using castles.Services;
using Microsoft.AspNetCore.Mvc;

namespace castles.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CastlesController : ControllerBase
    {

        private readonly CastlesService _service;

        private readonly KnightsService _knightService;

        public CastlesController(CastlesService service, KnightsService knightService)
        {
            _service = service;
            _knightService = knightService;
        }

        [HttpGet("{id}/knights")]
        public ActionResult<IEnumerable<Knight>> GetAllKnightsByCastleId(int id)
        {
            try
            {
                return Ok(_knightService.GetAllKnightsByCastleId(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Castle>> GetAll()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Castle> CreateCastle([FromBody] Castle newCastle)
        {
            try
            {
                return Ok(_service.CreateCastle(newCastle));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Castle> GetCastleById(int id)
        {
            try
            {
                return Ok(_service.GetCastleById(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Castle> EditCastle(int id, [FromBody] Castle editCastle)
        {
            try
            {
                editCastle.Id = id;
                return Ok(_service.EditCastle(editCastle));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Castle> DeleteCastle(int id)
        {
            try
            {
                return Ok(_service.DeleteCastle(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
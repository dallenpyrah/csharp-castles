using System.Collections.Generic;
using castles.Models;
using castles.Services;
using Microsoft.AspNetCore.Mvc;

namespace castles.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class KnightsController : ControllerBase
    {

        private readonly KnightsService _service;

        private readonly WifesService _wifeService;

        public KnightsController(KnightsService service, WifesService wifeService)
        {
            _service = service;
            _wifeService = wifeService;
        }

        [HttpGet("{id}/wifes")]
        public ActionResult<IEnumerable<Wife>> GetWifesByKnightId(int id)
        {
            try
            {
                return Ok(_wifeService.GetWifeByKnightId(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Knight>> GetAll()
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
        public ActionResult<Knight> CreateKnight([FromBody] Knight newKnight)
        {
            try
            {
                return Ok(_service.CreateKnight(newKnight));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Knight> GetOneById(int id)
        {
            try
            {
                return Ok(_service.GetOneById(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Knight> EditKnight(int id, [FromBody] Knight editKnight)
        {
            try
            {
                editKnight.Id = id;
                return Ok(_service.EditKnight(editKnight));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Knight> DeleteKnight(int id)
        {
            try
            {
                return Ok(_service.DeleteKnight(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
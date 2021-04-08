using System.Collections.Generic;
using castles.Models;
using castles.Services;
using Microsoft.AspNetCore.Mvc;

namespace castles.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class WifesController : ControllerBase
    {
        private readonly WifesService _service;
        private readonly KnightsService _knightsService;

        public WifesController(WifesService service, KnightsService knightsService)
        {
            _service = service;
            _knightsService = knightsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Wife>> GetAll()
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

        [HttpGet("{id}")]
        public ActionResult<Wife> GetOneById(int id)
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

        [HttpPost]
        public ActionResult<Wife> CreateWife([FromBody] Wife newWife)
        {
            try
            {
                return Ok(_service.CreateWife(newWife));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Wife> EditWife(int id, [FromBody] Wife editedWife)
        {
            try
            {
                editedWife.Id = id;
                return Ok(_service.EditWife(editedWife));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Wife> DeleteWife(int id)
        {
            try
            {
                return Ok(_service.DeleteWife(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
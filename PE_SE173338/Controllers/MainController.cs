using BO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Repo;

namespace PE_SE173338.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly ISilverJewelryRepo _repo;
        public MainController(ISilverJewelryRepo repo)
        {
            _repo = repo;
        }

        //[EnableQuery]
        
        [HttpGet("/api/AllS")]
        [Authorize(Policy = "AdminOrStaff")]
        public async Task<ActionResult<IEnumerable<SilverJewelry>>> GetAllS()
        {
            try
            {
                var silvers = await _repo.GetAllS();
                return Ok(silvers);
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{ex.Message}");
            }
        }

        [HttpGet("/api/Category")]
        [Authorize(Policy = "AdminOrStaff")]
       
        public async Task<ActionResult<List<Category>>> GetCategory()
        {
            try
            {
                var cate = await _repo.GetCategory();
                return Ok(cate);
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{ex.Message}");
            }
        }

        [HttpGet("/api/Sliver/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<SilverJewelry>> GetS(string id)
        {
            try
            {
                var silver = await _repo.GetSById(id);
                return Ok(silver);
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{ex.Message}");
            }
        }

        [HttpPost("/api/Silver")]
        [Authorize(Policy = "AdminOnly")]
     
        public async Task<ActionResult<SilverJewelry>> AddS([FromBody] SilverJewelry silver)
        {
            try
            {
                var newSilver = await _repo.AddS(silver);
                return Ok(newSilver);
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{ex.Message}");
            }
        }

        [HttpPut("/api/Silver/{id}")]
        [Authorize(Policy = "AdminOnly")]

        public async Task<ActionResult<SilverJewelry>> UpdateS(string id, [FromBody] SilverJewelry silver)
        {
            try
            {
                var updateS = await _repo.UpdateS(silver);
                return Ok(updateS);
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{ex.Message}");
            }
        }

        [HttpDelete("/api/Silver/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<SilverJewelry>> DeleteS(string id)
        {
            try
            {
                var deleteS = await _repo.DeleteS(id);
                return Ok(deleteS);
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{ex.Message}");
            }
        }
    }
}

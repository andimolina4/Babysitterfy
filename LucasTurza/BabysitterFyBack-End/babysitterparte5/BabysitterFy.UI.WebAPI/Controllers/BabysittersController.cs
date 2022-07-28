using BabysitterFy.Data.Models;
using BabysitterFy.Domain.DTO;
using BabysitterFy.Domain.Services.BabysitterService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabysitterFy.UI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BabysittersController : ControllerBase
    {
        private readonly IBabysitterService _babysitterService;

        public BabysittersController(IBabysitterService babysitterService)
        {
            _babysitterService = babysitterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BabysitterDTO>>> GetBabysitter()
        {
            var babyistters = _babysitterService.GetAllBabysitters();

            if(babyistters == null)
            {
                return NotFound();
            }

            return Ok(babyistters);
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<Babysitter>>> GetbyId(int id)
        {
            var babysitter = _babysitterService.GetById(id);
            if(babysitter == null)
            {
                return NotFound();
            }
            return Ok(babysitter);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBabysitter(int id, BabysitterDTO babysitter)
        {
            try
            {
                _babysitterService.EditBabysitter(id, babysitter);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Babysitter>> PostBabysitter(BabysitterDTO babysitter)
        {
            try
            {
                _babysitterService.AddBabysitter(babysitter);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return Ok(babysitter);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBabysitter(int id)
        {
            try
            {
                var deleteFlag = _babysitterService.DeleteBabysitter(id);
                if (!deleteFlag)
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return NoContent();
        }
    }
}

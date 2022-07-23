using BabysitterFy.Data.Models;
using BabysitterFy.Domain.DTO;
using BabysitterFy.Domain.Services.ParentService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabysitterFy.UI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly IParentService _parentService;

        public ParentsController(IParentService parentService)
        {
            _parentService = parentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParentDTO>>> GetParent()
        {
            var parents = _parentService.GetAllParents();

            if (parents == null)
            {
                return NotFound();
            }

            return Ok(parents);
        }

        [HttpGet("getbyId")]
        public async Task<ActionResult<IEnumerable<Parent>>> GetbyId(int id)
        {
            var parent = _parentService.GetById(id);
            if (parent == null)
            {
                return NotFound();
            }
            return Ok(parent);
        }

       [HttpPut("{id}")]
       public async Task<IActionResult> PutParent(int id, ParentDTO parent)
       {
           try
           {
               _parentService.EditParent(id, parent);
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
        public async Task<ActionResult<Parent>> PostParent(ParentDTO parent)
        {
            try
            {
                _parentService.AddParent(parent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(parent);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteParent(int id)
        {
            try
            {
                var deleteFlag = _parentService.DeleteParent(id);
                if (!deleteFlag)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return NoContent();
        }
    }
}

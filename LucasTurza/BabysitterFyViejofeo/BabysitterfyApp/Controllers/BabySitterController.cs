using BabysitterfyApp.Business.Services.BabySitterService;
using BabysitterfyApp.Dtos;
using BabysitterfyApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BabysitterfyApp.Controllers
{
    [Route("api/[controller]")]//al ser la ruta principal, este es el primer lugar al que entrara nuestra aplicacion a la hora de hacer una request
    [ApiController]
    public class BabySitterController : ControllerBase
    {
        private readonly IBabySitterService _babySitterService;//en vez de la base de datos utilizara la INTERFAZ del servicio babysitterInterface
        public BabySitterController(IBabySitterService babySitterService) //realiza la inyeccion de dependencia
        {
            _babySitterService = babySitterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BabySitter>>> GetAllBabySitter()
        {
            var babySitter = _babySitterService.GetAll(); 

            if (babySitter == null)
                return new NotFoundObjectResult("BabySitters NotFound");

            return Ok(babySitter);
        }
        [HttpPost]
        public async Task<ActionResult> PostBabySitter(CreateBabySitterDTO request)
        {
            if (request == null)
                return BadRequest("Something went wrong");

            return new OkObjectResult(_babySitterService.AddBabySitter(request));
        }
        [HttpPut]
        public async Task<ActionResult<BabySitter>> UpdateBabySitter(int id, UpdateBabySitterDTO request)
        {
            if (request == null)
                return BadRequest("Something went wrong");

            return _babySitterService.UpdateBabySitter(id, request);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteBabySitter(int id)
        {
            var babySitter = _babySitterService.GetById(id);

            if (babySitter == null)
                return BadRequest("BabySitter NotFound");

            try
            {
                var deleteFlag = _babySitterService.DeleteBabySitter(id);

                if (!deleteFlag)
                    return BadRequest("Cant delete babysitter");
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return new OkObjectResult(true);
        }


        
    }
}

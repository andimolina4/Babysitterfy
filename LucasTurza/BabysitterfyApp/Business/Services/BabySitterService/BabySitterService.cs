using BabysitterfyApp.DataAccess.Repositories.BabySitterRepository;
using BabysitterfyApp.Dtos;
using BabysitterfyApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BabysitterfyApp.Business.Services.BabySitterService
{
    public class BabySitterService : IBabySitterService
    {
        private readonly IBabySitterRepository _babySitterRepository;//va a utilizar la INTERFAZ del REPOSITORIO babysitterRepository
        public BabySitterService(IBabySitterRepository babySitterRepository)//inyecta el repositorio
        {
            _babySitterRepository = babySitterRepository;
        }
        public IEnumerable<BabySitter> GetAll()
        {
            return _babySitterRepository.GetAll();
        }
        public List<BabySitter> GetById(int id)//las funciones personalizadas son en base de lo que devuelve las funciones del repositorio
        {
            return GetAll().Where(b => b.Id == id).ToList();//usa la funcion GetAll() del repositorio pero agrega que traiga segun el id, entonces trae toda la lista y elige por ID el elemento que requiere
        }
        public Task<ActionResult> AddBabySitter(CreateBabySitterDTO request)
        {
            return _babySitterRepository.AddBabySitter(request);
        }
        public BabySitter UpdateBabySitter(int id, UpdateBabySitterDTO request)
        {
            return _babySitterRepository.UpdateBabySitter(id, request);
        }
        public bool DeleteBabySitter(int id)
        {
            return _babySitterRepository.DeleteBabySitter(id);
        }
    }
}

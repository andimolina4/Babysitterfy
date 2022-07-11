using BabysitterfyApp.DataAccess.Repositories.BabySitterRepository;
using BabysitterfyApp.Dtos;
using BabysitterfyApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BabysitterfyApp.Business.Services.BabySitterService
{
    public class BabySitterService : IBabySitterService
    {
        private readonly IBabySitterRepository _babySitterRepository;
        public BabySitterService(IBabySitterRepository babySitterRepository)
        {
            _babySitterRepository = babySitterRepository;
        }
        public IEnumerable<BabySitter> GetAll()
        {
            return _babySitterRepository.GetAll();
        }
        public List<BabySitter> GetById(int id)
        {
            return GetAll().Where(b => b.Id == id).ToList();
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

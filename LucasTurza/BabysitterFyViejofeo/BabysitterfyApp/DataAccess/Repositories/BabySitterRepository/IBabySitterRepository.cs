using BabysitterfyApp.Dtos;
using BabysitterfyApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BabysitterfyApp.DataAccess.Repositories.BabySitterRepository
{
    public interface IBabySitterRepository
    {
        public IEnumerable<BabySitter> GetAll();
        public Task<ActionResult> AddBabySitter(CreateBabySitterDTO request);
        public BabySitter UpdateBabySitter(int id, UpdateBabySitterDTO request);
        public bool DeleteBabySitter(int id);
    }
}

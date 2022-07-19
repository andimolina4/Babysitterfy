using BabysitterfyApp.Dtos;
using BabysitterfyApp.Models;

namespace BabysitterfyApp.Business.Services.BabySitterService
{
    public interface IBabySitterService
    {
        public IEnumerable<BabySitter> GetAll();
        public List<BabySitter> GetById(int id);
        public Task<ActionResult> AddBabySitter(CreateBabySitterDTO request);
        public BabySitter UpdateBabySitter(int id, UpdateBabySitterDTO request);
        public bool DeleteBabySitter(int id);
    }
}

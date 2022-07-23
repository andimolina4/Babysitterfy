using BabysitterFy.Data.Models;
using BabysitterFy.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterFy.Domain.Services.BabysitterService
{
    public interface IBabysitterService
    {
        public IEnumerable<BabysitterDTO> GetAllBabysitters(); //GetAll

        public BabysitterDTO GetById(int Id); //GetById

        public void AddBabysitter(BabysitterDTO babysitter); //AddBabysitter

        public Babysitter EditBabysitter(int Id, BabysitterDTO Updatedbabysitter); //EditBabysitter

        public bool DeleteBabysitter(int Id); //DeleteBabysitter
    }
}

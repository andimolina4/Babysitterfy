using BabysitterFy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterFy.Data.Repositories.BabysitterRepository
{
    public interface IBabysitterRepository
    {
        public IEnumerable<Babysitter> GetAllBabysitters(); //GetAll
        public Babysitter GetById(int Id); //GetById

        public void AddBabysitter(Babysitter babysitter); //AddBabysitter

        public Babysitter EditBabysitter(Babysitter UpdatedBabysitter); //EditBabysitter

        public bool DeleteBabysitter(int Id); //DeleteBabysitter
    }
}

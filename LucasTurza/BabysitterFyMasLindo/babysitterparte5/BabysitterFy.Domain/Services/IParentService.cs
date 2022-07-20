using BabysitterFy.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterFy.Domain.Services
{
    public interface IParentService
    {
        public IEnumerable<ParentDTO> GetAllParents(); //GetAll

        public ParentDTO GetById(int Id); //GetById

        public void AddParent(ParentDTO parent); //AddParent

        //public ParentDTO EditParent(int Id, ParentDTO UpdatedParent); //EditParent

        public bool DeleteParent(int Id); //DeleteParent
    }
}

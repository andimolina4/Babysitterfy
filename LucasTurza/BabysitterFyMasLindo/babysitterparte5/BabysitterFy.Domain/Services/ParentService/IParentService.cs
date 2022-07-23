using BabysitterFy.Data.Models;
using BabysitterFy.Domain.DTO;

namespace BabysitterFy.Domain.Services.ParentService
{
    public interface IParentService
    {
        public IEnumerable<ParentDTO> GetAllParents(); //GetAll

        public ParentDTO GetById(int Id); //GetById

        public void AddParent(ParentDTO parent); //AddParent

        public Parent EditParent(int Id, ParentDTO UpdatedParent); //EditParent

        public bool DeleteParent(int Id); //DeleteParent
    }
}

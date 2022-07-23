using BabysitterFy.Data.Models;

namespace BabysitterFy.Data.Repositories.ParentRepository
{
    public interface IParentRepository
    {
        public IEnumerable<Parent> GetAllParents(); //GetAll
        public Parent GetById(int Id); //GetById

        public void AddParent(Parent parent); //AddParent

        public Parent EditParent(Parent UpdatedParent); //EditParent

        public bool DeleteParent(int Id); //DeleteParent
    }
}

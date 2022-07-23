using BabysitterFy.Data.Data;
using BabysitterFy.Data.Models;

namespace BabysitterFy.Data.Repositories.ParentRepository
{
    public class ParentRepository : IParentRepository
    {
        private readonly BabysitterFyDbContext _context;

        public ParentRepository(BabysitterFyDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Parent> GetAllParents()
        {
            return _context.Parent;
        }

        public Parent GetById(int Id)
        {
            return _context.Parent.Find(Id);
        }

        public void AddParent(Parent parent)
        {
            if (parent != null)
            {
                try
                {
                    _context.Parent.Add(parent);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Parent EditParent(Parent UpdatedParent)
        {
            try
            {
                _context.Update(UpdatedParent);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return UpdatedParent;
        }

        public bool DeleteParent(int Id)
        {
            var parent = _context.Parent.Find(Id);
            if (parent != null)
            {
                try
                {
                    _context.Parent.Remove(parent);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return true;
            }
            return false;

        }
    }
}

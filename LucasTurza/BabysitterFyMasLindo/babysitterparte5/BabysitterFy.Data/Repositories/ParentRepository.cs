using BabysitterFy.Data.Data;
using BabysitterFy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterFy.Data.Repositories
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
            return _context.Parents;
        }

        public Parent GetById(int Id)
        {
            return _context.Parents.Find(Id);
        }

        public void AddParent(Parent parent)
        {
            if (parent != null)
            {
                try
                {
                    _context.Parents.Add(parent);
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
            var parent = _context.Parents.Find(Id);
            if (parent != null)
            {
                try
                {
                    _context.Parents.Remove(parent);
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

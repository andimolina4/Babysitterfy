using BabysitterFy.Data.Data;
using BabysitterFy.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterFy.Data.Repositories
{
    public class BabysitterRepository : IBabysitterRepository
    {
        private readonly BabysitterFyDbContext _context;
        public BabysitterRepository(BabysitterFyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Babysitter> GetAllBabysitters()
        {
            return _context.Babysitter;
        }
        public Babysitter GetById(int Id)
        {
            return _context.Babysitter.Find(Id);
        }

        public void AddBabysitter(Babysitter babysitter)
        {
            if(babysitter != null)
            {
                try
                {
                    _context.Babysitter.Add(babysitter);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Babysitter EditBabysitter(Babysitter UpdatedBabysitter)
        {
            try
            {
                _context.Update(UpdatedBabysitter);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return UpdatedBabysitter;
        }

        public bool DeleteBabysitter(int Id)
        {
            var babysitter = _context.Babysitter.Find(Id);
            if(babysitter != null)
            {
                try
                {
                    _context.Babysitter.Remove(babysitter);
                    _context.SaveChanges();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                return true;
            }
            return false;
        }
    }
}

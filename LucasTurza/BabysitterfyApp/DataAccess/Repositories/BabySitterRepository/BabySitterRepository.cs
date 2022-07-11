using AutoMapper;
using BabysitterfyApp.DataAccess.Data;
using BabysitterfyApp.Dtos;
using BabysitterfyApp.Models;

namespace BabysitterfyApp.DataAccess.Repositories.BabySitterRepository
{
    public class BabySitterRepository : IBabySitterRepository
    {
        private readonly BabySitterAppDbContext _context;
        private readonly IMapper _mapper;
        public BabySitterRepository(BabySitterAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<BabySitter> GetAll()
        {
            var babySitter = _context.BabySitter.ToList();
            var babySitterToReturn = _mapper.Map<IEnumerable<BabySitter>>(babySitter);
            return babySitterToReturn;
        }

        public async Task<ActionResult> AddBabySitter(CreateBabySitterDTO request)
        {
            try
            {
                var entity = _mapper.Map<CreateBabySitterDTO, BabySitter>(request);

                _context.BabySitter.Add(entity);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return new OkObjectResult(true);
        }

        public BabySitter UpdateBabySitter(int id, UpdateBabySitterDTO request)
        {
            BabySitter oldBabySitter = GetAll().First(x => x.Id == id);
            if(oldBabySitter != null)
            {
                var result = _mapper.Map(request, oldBabySitter);
                try
                { 
                    _context.SaveChanges();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                return result;
            }
            return oldBabySitter;
        }

        public bool DeleteBabySitter(int id)
        {
            var babySitter = GetAll().First(x => x.Id == id);
            if(babySitter != null)
            {
                try
                {
                    _context.Remove(babySitter);
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

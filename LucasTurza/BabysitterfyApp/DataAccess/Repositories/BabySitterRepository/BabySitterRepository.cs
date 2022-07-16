using AutoMapper;
using BabysitterfyApp.DataAccess.Data;
using BabysitterfyApp.Dtos;
using BabysitterfyApp.Models;
using System.Security.Cryptography;

namespace BabysitterfyApp.DataAccess.Repositories.BabySitterRepository
{
    public class BabySitterRepository : IBabySitterRepository //deriva de su interfaz que es a donde va a acceder de manera rapida a las funciones
    {
        private readonly BabySitterAppDbContext _context;//inyeccion de dependencia + el mapper
        private readonly IMapper _mapper;
        public BabySitterRepository(BabySitterAppDbContext context, IMapper mapper)//
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
                var babySitter = HashPassword(request.Password);

                request.Password = babySitter;
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

        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password invalid");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        //public static bool VerifyHashedPassword(string hashedPassword, string password)
        //{
        //    byte[] buffer4;
        //    if (hashedPassword == null)
        //    {
        //        return false;
        //    }
        //    if (password == null)
        //    {
        //        throw new ArgumentNullException("password");
        //    }
        //    byte[] src = Convert.FromBase64String(hashedPassword);
        //    if ((src.Length != 0x31) || (src[0] != 0))
        //    {
        //        return false;
        //    }
        //    byte[] dst = new byte[0x10];
        //    Buffer.BlockCopy(src, 1, dst, 0, 0x10);
        //    byte[] buffer3 = new byte[0x20];
        //    Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
        //    using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
        //    {
        //        buffer4 = bytes.GetBytes(0x20);
        //    }
        //    return ByteArraysEqual(buffer3, buffer4);
        //}
    }
}

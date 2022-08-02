using AutoMapper;
using BabysitterFy.Data.Models;
using BabysitterFy.Data.Repositories.BabysitterRepository;
using BabysitterFy.Domain.DTO;

namespace BabysitterFy.Domain.Services.BabysitterService
{
    public class BabysitterService : IBabysitterService
    {
        private readonly IBabysitterRepository _babysitterRepository;
        private readonly IMapper _mapper;

        public BabysitterService(IBabysitterRepository babysitterRepository, IMapper mapper)
        {
            _babysitterRepository = babysitterRepository;
            _mapper = mapper;
        }

        public IEnumerable<BabysitterDTO> GetAllBabysitters()
        {
            var babysitters = _babysitterRepository.GetAllBabysitters();
            var babysitterssToReturn = _mapper.Map<IEnumerable<BabysitterDTO>>(babysitters);
            return babysitterssToReturn;
        }

        public BabysitterDTO GetById(int Id)
        {
            var babysittes = _babysitterRepository.GetById(Id);
            var babysittesToReturn = _mapper.Map<BabysitterDTO>(babysittes);
            return babysittesToReturn;
        }

        public void AddBabysitter(BabysitterDTO babysitterDTO)
        {
            try
            {
                Babysitter babysitter = new Babysitter()
                {
                    Firstname = babysitterDTO.Firstname,
                    Lastname = babysitterDTO.Lastname,
                    Description = babysitterDTO.Description,
                    DateOfBirth = babysitterDTO.DateOfBirth,
                    Email = babysitterDTO.Email,
                    Image = babysitterDTO.Image,
                    Price = babysitterDTO.Price,
                    WorkTime = babysitterDTO.WorkTime,
                    Gender = babysitterDTO.Gender,
                    Phone = babysitterDTO.Phone,
                    Address = babysitterDTO.Address,
                    Province = babysitterDTO.Province,
                };
                _babysitterRepository.AddBabysitter(babysitter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Babysitter EditBabysitter(int Id, BabysitterDTO UpdatedBabysitter)
        {
            var oldbabysitter = _babysitterRepository.GetById(Id);
            if (oldbabysitter != null)
            {
                oldbabysitter.Firstname = UpdatedBabysitter.Firstname;
                oldbabysitter.Lastname = UpdatedBabysitter.Lastname;
                oldbabysitter.Description = UpdatedBabysitter.Description;
                oldbabysitter.DateOfBirth = UpdatedBabysitter.DateOfBirth;
                oldbabysitter.Email = UpdatedBabysitter.Email;
                oldbabysitter.Image = UpdatedBabysitter.Image;
                oldbabysitter.Price = UpdatedBabysitter.Price;
                oldbabysitter.WorkTime = UpdatedBabysitter.WorkTime;
                oldbabysitter.Gender = UpdatedBabysitter.Gender;
                oldbabysitter.Phone = UpdatedBabysitter.Phone;
                oldbabysitter.Address = UpdatedBabysitter.Address;
                oldbabysitter.Province = UpdatedBabysitter.Province;

                try
                {
                    return _babysitterRepository.EditBabysitter(oldbabysitter);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }

        public bool DeleteBabysitter(int Id)
        {
            if (Id <= 0)
            {
                return false;
            }

            var babysitter = _babysitterRepository.GetById(Id);

            if (babysitter == null)
            {
                throw new ApplicationException("Babysitter not found");
            }

            try
            {
                return _babysitterRepository.DeleteBabysitter(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

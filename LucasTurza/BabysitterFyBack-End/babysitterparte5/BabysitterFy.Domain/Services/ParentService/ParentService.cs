using AutoMapper;
using BabysitterFy.Data.Models;
using BabysitterFy.Data.Repositories.ParentRepository;
using BabysitterFy.Domain.DTO;

namespace BabysitterFy.Domain.Services.ParentService
{
    public class ParentService : IParentService
    {
        private readonly IParentRepository _parentRepository;
        private readonly IMapper _mapper;

        public ParentService(IParentRepository parentRepository, IMapper mapper)
        {
            _parentRepository = parentRepository;
            _mapper = mapper;
        }

        public IEnumerable<ParentDTO> GetAllParents()
        {
            var parents = _parentRepository.GetAllParents();
            var parentsToReturn = _mapper.Map<IEnumerable<ParentDTO>>(parents);
            return parentsToReturn;
        }

        public ParentDTO GetById(int Id)
        {
            var parent = _parentRepository.GetById(Id);
            var parentToReturn = _mapper.Map<ParentDTO>(parent);
            return parentToReturn;
        }

        public void AddParent(ParentDTO parentDTO)
        {
            try
            {
                Parent parent = new Parent()
                {
                    Firstname = parentDTO.Firstname,
                    Lastname = parentDTO.Lastname,
                    DateOfBirth = parentDTO.DateOfBirth,
                    Email = parentDTO.Email,
                    PhoneNumber = parentDTO.PhoneNumber,
                    NumberOfChildren = parentDTO.NumberOfChildren,
                    Address = parentDTO.Address,
                    Province = parentDTO.Province,
                };
                _parentRepository.AddParent(parent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Parent EditParent(int Id, ParentDTO updatedParent)
        {
            var oldparent = _parentRepository.GetById(Id);
            if (oldparent != null)
            {
                oldparent.Firstname = updatedParent.Firstname;
                oldparent.Lastname = updatedParent.Lastname;
                oldparent.DateOfBirth = oldparent.DateOfBirth;
                oldparent.Email = updatedParent.Email;
                oldparent.PhoneNumber = updatedParent.PhoneNumber;
                oldparent.NumberOfChildren = updatedParent.NumberOfChildren;
                oldparent.Address = updatedParent.Address;
                oldparent.Province = updatedParent.Province;

                try
                {
                    return _parentRepository.EditParent(oldparent);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }

        public bool DeleteParent(int Id)
        {
            if (Id <= 0)
            {
                return false;
            }

            var parent = _parentRepository.GetById(Id);

            if (parent == null)
            {
                throw new ApplicationException("Parent not found");
            }

            try
            {
                return _parentRepository.DeleteParent(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

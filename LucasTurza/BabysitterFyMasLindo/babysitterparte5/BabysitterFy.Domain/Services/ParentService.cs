using AutoMapper;
using BabysitterFy.Data.Models;
using BabysitterFy.Data.Repositories;
using BabysitterFy.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterFy.Domain.Services
{
    public class ParentService : IParentService
    {
        private readonly IParentRepository _parentsRepository;
        private readonly IMapper _mapper;

        public ParentService(IParentRepository parentRepository, IMapper mapper)
        {
            _parentsRepository = parentRepository;
            _mapper = mapper;
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
                    NumberOfChildren = parentDTO.NumberOfChildren
                };
                _parentsRepository.AddParent(parent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteParent(int Id)
        {
            if (Id <= 0)
            {
                return false;
            }

            var parent = _parentsRepository.GetById(Id);

            if (parent == null)
            {
                throw new ApplicationException("Parent not found");
            }

            try
            {
                return _parentsRepository.DeleteParent(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public ParentDTO EditParent(int Id, ParentDTO UpdatedParent)
        //{
        //    var oldParent = _parentsRepository.GetById(Id);
        //    if (oldParent != null)
        //    {
        //        oldParent.Firstname = UpdatedParent.Firstname;
        //        oldParent.Lastname = UpdatedParent.Lastname;
        //        oldParent.DateOfBirth = UpdatedParent.DateOfBirth;
        //        oldParent.Email = UpdatedParent.Email;
        //        oldParent.PhoneNumber = UpdatedParent.PhoneNumber;
        //        oldParent.NumberOfChildren = UpdatedParent.NumberOfChildren;

        //        try
        //        {
        //            return _parentsRepository.EditParent(oldParent);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //    return null;
        //}

        public IEnumerable<ParentDTO> GetAllParents()
        {
            var parents = _parentsRepository.GetAllParents();
            var parentsToReturn = _mapper.Map<IEnumerable<ParentDTO>>(parents);
            return parentsToReturn;
        }

        public ParentDTO GetById(int Id)
        {
            var parents = _parentsRepository.GetById(Id);
            var parentsToReturn = _mapper.Map<ParentDTO>(parents);
            return parentsToReturn;
        }
    }
}

﻿using BabysitterFy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterFy.Data.Repositories
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

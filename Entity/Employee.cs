﻿using Entity.Interface;
using Entity.Repository;
using System;

namespace Entity
{
    public class Employee:IDbModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime StartDate { get; set; }

        public string Department { get; set; }

        public string  PhoneNumber { get; set; }

        public string Email { get; set; }

        public string City { get; set; }


        public string Fullname
        {
            get
            {
                return FirstName + " " + LastName;
            }
            
        }

        #region Implement IDbModel
        public AbstractDapperRepo Repository { get; set; }

        public void SetId(object id)
        {
            try
            {
                Id =(int)id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SetRepository(AbstractDapperRepo dapperRepository)
        {
            Repository = dapperRepository;
        }
        #endregion
    }

}

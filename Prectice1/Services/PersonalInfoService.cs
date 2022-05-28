﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prectice1.Models;
using Prectice1.Services;

namespace Prectice1.Services
{
    public class PersonalInfoService
    {
        private readonly foodieEntities1 foodieEntitiesContext;
        public PersonalInfoService(foodieEntities1 _foodieEntitiesContext)
        {
           foodieEntitiesContext = _foodieEntitiesContext;
        }   
        public PersonalInfo create(PersonalInfo personalInfo)
        {
            PersonalInfo personalInfo1 = new PersonalInfo();
            personalInfo1.PersonName=personalInfo.PersonName;
            personalInfo1.Mobile_No=personalInfo.Mobile_No;
            personalInfo1.Contact=personalInfo.Contact;
            personalInfo1.Adress=personalInfo.Adress;
            personalInfo1.Pincode=personalInfo.Pincode;
            foodieEntitiesContext.PersonalInfoes.Add(personalInfo1);
            foodieEntitiesContext.SaveChanges();
            return personalInfo;
         
        }
        public PersonalInfo edit(PersonalInfo personalInfo, int id)
        {
            var personalInfoEdit = foodieEntitiesContext.PersonalInfoes.Where(c => c.PersonlId == id).FirstOrDefault();
            if (personalInfoEdit != null)
                return null;
            personalInfoEdit.PersonName=personalInfo.PersonName; 
            personalInfoEdit.Mobile_No = personalInfo.Mobile_No;
            personalInfoEdit.Contact = personalInfo.Contact;
            personalInfoEdit.Adress = personalInfo.Adress;
            personalInfoEdit.Pincode = personalInfo.Pincode;
            foodieEntitiesContext.SaveChanges();
            return personalInfoEdit;

        }
        public PersonalInfo Delete(int id)
        {
            var deletePersonalInfo=foodieEntitiesContext.PersonalInfoes.Where(c=>c.PersonlId==id).FirstOrDefault();
            foodieEntitiesContext.PersonalInfoes.Remove(deletePersonalInfo);
            foodieEntitiesContext.SaveChanges();
            return deletePersonalInfo;
        }
        public IEnumerable<PersonalInfo> get()
        {
            return foodieEntitiesContext.PersonalInfoes.ToList();
        }
        public PersonalInfo getById(int id)
        {
            return foodieEntitiesContext.PersonalInfoes.Where(c=>c.PersonlId==id).FirstOrDefault();
        }
    }
}
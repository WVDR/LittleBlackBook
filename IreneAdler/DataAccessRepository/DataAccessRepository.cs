using IreneAdler.Models;
using IreneAdler.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IreneAdler.DataAccessRepository
{
    public class ClsDataAccessRepository : IDataAccessRepository<CONTACT, Guid>
    {
        //The dendency for the DbContext specified the current class. 
        [Dependency]
        public LittleBlackBookEntities ctx { get; set; }

        //Get all Employees
        public IEnumerable<CONTACT> Get()
        {
            return ctx.CONTACTS.ToList();
        }
        //Get Specific Employee based on Id
        public CONTACT Get(Guid id)
        {
            return ctx.CONTACTS.Find(id);
        }

        //Create a new Employee
        public void Post(CONTACT entity)
        {
            ctx.CONTACTS.Add(entity);
            ctx.SaveChanges();
        }
        //Update Exisitng Employee
        public void Put(Guid id, CONTACT entity)
        {
            var contact = ctx.CONTACTS.Find(id);
            if (contact != null)
            {
                contact.Contact_ID = entity.Contact_ID;
                contact.Date_Added = entity.Date_Added;
                contact.Name = entity.Name;
                contact.Cell = entity.Cell;
                contact.Land_Line = entity.Land_Line;
                contact.Email = entity.Email;                
                ctx.SaveChanges();
            }
        }
        //Delete an Employee based on Id
        public void Delete(Guid id)
        {
            var Emp = ctx.CONTACTS.Find(id);
            if (Emp != null)
            {
                ctx.CONTACTS.Remove(Emp);
                ctx.SaveChanges();
            }
        }
    }    
}
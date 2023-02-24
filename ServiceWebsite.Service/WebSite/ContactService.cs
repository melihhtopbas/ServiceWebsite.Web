using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceWebsite.Data;
using ServiceWebsite.ViewModels.Common;
using ServiceWebsite.ViewModels.WebSite;

namespace ServiceWebsite.Service.WebSite
{
    public class ContactService
    {
        private readonly WebSiteContextContainer _context;

        public ContactService(WebSiteContextContainer context)
        {
            _context = context;
        }

        public ServiceCallResult AddContactForm(ContactViewModel model)
        {
            var callResult = new ServiceCallResult() { Success = false };

            var contact=new ContactForm()
            {
                Phone = model.Phone,
                FullName = model.FullName,
                Mail =model.Email,
                Message = model.Message,
                Subject = model.Subject,
                Date = DateTime.Now
            };
            _context.ContactForm.Add(contact);
            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    dbtransaction.Commit();
                    callResult.Success = true;
                   
                    return callResult;
                }
                catch (Exception exc)
                {
                    callResult.ErrorMessages.Add(exc.GetBaseException().Message);
                    return callResult;
                }
            }
 
            

        }
    }
}

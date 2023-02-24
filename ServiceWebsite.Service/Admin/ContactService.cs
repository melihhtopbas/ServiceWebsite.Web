using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinqKit;
using ServiceWebsite.Data;
using ServiceWebsite.ViewModels.Admin;

namespace ServiceWebsite.Service.Admin
{
    public class ContactService
    {
        private readonly WebSiteContextContainer _context;

        public ContactService(WebSiteContextContainer context)
        {
            _context = context;
        }
        private IQueryable<ContactViewModel> _getContactListIQueryable(Expression<Func<Data.ContactForm, bool>> expr)
        {
            return (from b in _context.ContactForm.AsExpandable().Where(expr)
                select new ContactViewModel()
                {
                    Phone = b.Phone,
                    Email = b.Mail,
                    FullName = b.FullName,
                    Message = b.Message,
                    Subject = b.Subject,
                    Id = b.Id,
                    Date = b.Date
                     
                });
        }

        public IQueryable<ContactViewModel> GetContactListIQueryable(ContactViewModel  contactViewModel)
        {
            var predicate = PredicateBuilder.New<Data.ContactForm>(true);/*AND*/
            if (!string.IsNullOrWhiteSpace(contactViewModel.FullName))
            {
                predicate.And(a => a.FullName.Contains(contactViewModel.FullName));
            }
            if (!string.IsNullOrWhiteSpace(contactViewModel.Subject))
            {
                predicate.And(a => a.Subject.Contains(contactViewModel.Subject));
            }

            return _getContactListIQueryable(predicate);
        }
        public async Task<ContactViewModel> GetContactDetailModelAsync(int contactId)
        {
            var contact = await (from p in _context.ContactForm
                                 where p.Id == contactId
                                 select new ContactViewModel()
                                 {
                                     FullName = p.FullName,
                                     Date = p.Date,
                                     Phone = p.Phone,
                                     Subject = p.Subject,
                                     Email = p.Mail,
                                     Message = p.Message

                                 }).FirstOrDefaultAsync();
            return contact;
        }
    }
}

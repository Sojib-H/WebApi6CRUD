using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi6CRUD.Data;
using WebApi6CRUD.Models;

namespace WebApi6CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContactAPIDbContext dbContext;

        public ContactsController(ContactAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetContact()
        {
            return Ok(await dbContext.Contacts.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContactById([FromRoute] Guid id)
        {
           var contact = await dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }


        [HttpPost]
        public async Task<IActionResult> AddContact(AddContact AddContact)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                FullName = AddContact.FullName,
                Email = AddContact.Email,
                Phone = AddContact.Phone,
                Address = AddContact.Address
            };
            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();
            return Ok(contact);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute] Guid id, UpdateContact UpdateContact)
        {
           var contact =await dbContext.Contacts.FindAsync(id);
            if (contact != null)
            {
                contact.FullName = UpdateContact.FullName;
                contact.Email = UpdateContact.Email;
                contact.Phone = UpdateContact.Phone;    
                contact.Address = UpdateContact.Address;
                await dbContext.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var contact = await dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            if (contact != null)
            {
                dbContext.Contacts.Remove(contact);
                await dbContext.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }

    }
}

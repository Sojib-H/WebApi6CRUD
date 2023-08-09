using Microsoft.EntityFrameworkCore;
using WebApi6CRUD.Models;

namespace WebApi6CRUD.Data
{
    public class ContactAPIDbContext : DbContext
    {
        public ContactAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

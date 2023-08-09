namespace WebApi6CRUD.Models
{
    public class User
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public string Address { get; set; }
    }
}

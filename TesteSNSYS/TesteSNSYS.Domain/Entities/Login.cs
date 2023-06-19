using System.ComponentModel.DataAnnotations.Schema;

namespace TesteSNSYS.Domain.Entities
{
    [Table("tb_users")]
    public class Login
    {
        public long Id { get; private set; }
        public string User { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public void SetId(long id)
        {
            Id = id;
        }
        public void SetUser(string user)
        {
            User = user;
        }
        public void SetPassword(string password)
        {
            Password = password;
        }
        public void SetRole(string role)
        {
            Role = role;
        }
    }
}

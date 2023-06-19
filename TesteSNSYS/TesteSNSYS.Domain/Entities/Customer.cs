using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteSNSYS.Domain.Entities
{
    [Table("tb_customer")]
    public class Customer
    {
        public long Id { get; private set; }
        public long UserId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }
        public void SetId(long id)
        {
            Id = id;
        }
        public void SetUserId(long userId)
        {
            UserId = userId;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetEmail(string email)
        {
            Email = email;
        }
        public void SetPhone(string phone)
        {
            Phone = phone;
        }
        public void SetRegisterDate(DateTime registerDate)
        {
            RegisterDate = registerDate;
        }
        public void SetUpdateDate(DateTime? updateDate)
        {
            UpdateDate = updateDate;
        }
    }
}

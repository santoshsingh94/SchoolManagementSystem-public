using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class UserType
    {
        public UserType()
        {
            this.Users = new List<User>();
        }
        [Key]
        public int UserTypeId { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }

        public ICollection<User> Users { get; set; }
    }
}

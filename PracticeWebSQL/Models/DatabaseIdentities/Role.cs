using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracticeWebSQL.Models.DatabaseIdentities
{
    public class Role
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Account> Users { get; set; }
        public Role()
        {
            Users = new List<Account>();
        }
    }
}
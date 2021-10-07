using System.Collections.Generic;

namespace PracticeWebSQL.Models
{
    public class DatabaseModel
    {
        public IEnumerable<Account> Accounts { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}
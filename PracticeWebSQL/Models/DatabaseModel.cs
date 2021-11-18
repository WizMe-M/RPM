using System.Collections.Generic;
using PracticeWebSQL.Models.DatabaseIdentities;

namespace PracticeWebSQL.Models
{
    public class DatabaseModel
    {
        public IEnumerable<Account> Accounts { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}
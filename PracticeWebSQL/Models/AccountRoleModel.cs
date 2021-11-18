using System.Collections.Generic;
using PracticeWebSQL.Models.DatabaseIdentities;

namespace PracticeWebSQL.Models
{
    public class AccountRolesModel
    {
        public Account Account { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}
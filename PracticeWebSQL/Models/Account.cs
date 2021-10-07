using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeWebSQL.Models
{
    public class Account
    {
        [Key]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        
        [ForeignKey(nameof(RoleID))] 
        public Role Role { get; set; }
    }
}
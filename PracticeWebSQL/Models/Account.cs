using System.ComponentModel.DataAnnotations;

namespace PracticeWebSQL.Models
{
    public class Account
    {
        [Key]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public  string Password { get; set; }
        
    }
}
using System.ComponentModel.DataAnnotations;

namespace PracticeWebSQL.Models
{
    public class Role
    {
        [Key]
        public int ID { get; set; }
        public string RoleName { get; set; }
    }
}
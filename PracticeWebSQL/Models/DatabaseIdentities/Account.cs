using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  PracticeWebSQL.Models.DatabaseIdentities
{
    public class Account
    {
        [Key]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public  string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        // public int? RoleID { get; set; }
        // [ForeignKey(nameof(RoleID))] 
        // public Role Role { get; set; }
    }
}
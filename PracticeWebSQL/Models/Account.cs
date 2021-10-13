using System;
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
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
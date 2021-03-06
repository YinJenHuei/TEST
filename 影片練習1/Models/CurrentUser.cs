using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace 影片練習1.Models
{
    public class CurrentUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name ="E-Mail")]
        public string Email { get; set; }

        public DateTime LoginTime { get; set; }

        

    }
}
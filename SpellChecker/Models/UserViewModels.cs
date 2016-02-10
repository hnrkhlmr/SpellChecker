using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpellChecker.Models
{
    public class UserStatViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int NumberOfTests { get; set; }
    }
    //public class UserViewModel
    //{
    //    public int UserId { get; set; }
    //    public string UserName { get; set; }
    //    public string Email { get; set; }
    //}

    ////Teststatistik
    //public class TestStatViewModel
    //{
    //    public int NumberOfTests { get; set; }
    //}
}
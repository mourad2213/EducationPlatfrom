using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public class AccountViewModel
{
    public string Fullname { get; set; }
    public string Email { get; set; }
    public AccountType AccountType { get; set; }
    //public string ExperienceLevel { get; set; }
}

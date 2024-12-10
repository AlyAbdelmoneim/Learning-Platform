using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Admin
{
    public int AdminID { get; set; }

    public string? first_name { get; set; }

    public string? last_name { get; set; }

    public string? email { get; set; }

    public string? adminPassword { get; set; }
}

using System;
using System.Collections.Generic;

namespace MyApi.Models;

public partial class UserAuthorization
{
    public int IdUser { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }
}

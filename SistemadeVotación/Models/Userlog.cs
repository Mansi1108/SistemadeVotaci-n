﻿using System;
using System.Collections.Generic;

namespace SistemadeVotación.Models;

public partial class Userlog
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public int Rol { get; set; }

    public string Password { get; set; } = null!;
}

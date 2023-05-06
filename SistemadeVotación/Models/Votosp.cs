﻿using System;
using System.Collections.Generic;

namespace SistemadeVotación.Models;

public partial class Votosp
{
    public int Id { get; set; }

    public int IdCandidato { get; set; }

    public string NoDpi { get; set; } = null!;

    public virtual CandidatosPresidenciale IdCandidatoNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace API_Votos.Models;

public partial class Fase
{
    public string Nombre { get; set; } = null!;

    public sbyte Activo { get; set; }
}

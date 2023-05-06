using System;
using System.Collections.Generic;

namespace SistemadeVotación.Models;

public partial class CandidatosPresidenciale
{
    public int Id { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string NoDpi { get; set; } = null!;

    public int Edad { get; set; }

    public string Nacionalidad { get; set; } = null!;

    public string DepartamentoNacimiento { get; set; } = null!;

    public string PartidoPolitico { get; set; } = null!;

    public string FotoUrl { get; set; } = null!;

    public DateTime FechaIngresoPartido { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Votosp> Votosps { get; set; } = new List<Votosp>();
}

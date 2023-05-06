using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelsAux
{
    public class CandidatosAux
    {
        public int Id { get; set; }
        [DisplayName("Nombre Completo")]
        public string NombreCompleto { get; set; } = null!;
        [DisplayName("No. DPI")]
        public string NoDpi { get; set; } = null!;

        public int Edad { get; set; }

        public string Nacionalidad { get; set; } = null!;
        [DisplayName("Departamento Nacimiento")]
        public string DepartamentoNacimiento { get; set; } = null!;
        [DisplayName("Nombre Partido Politico")]
        public string PartidoPolitico { get; set; } = null!;
        [DisplayName("Foto")]
        public string FotoUrl { get; set; } = null!;
        [DisplayName("Fecha de Ingreso Partido")]
        public DateTime FechaIngresoPartido { get; set; }

        public votosAux voto { get; set; }
    }
}

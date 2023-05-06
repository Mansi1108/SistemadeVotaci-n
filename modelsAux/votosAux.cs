using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelsAux
{
    public class votosAux
    {
        public int Id { get; set; }
        [DisplayName("Nombre Candidato")]
        public int IdCandidato { get; set; }
        [DisplayName("No. DPI")]
        public string NoDpi { get; set; } = null!;

        public CandidatosAux IdCandidatoNavigation { get; set; }
    }
}

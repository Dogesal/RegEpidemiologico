using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroEpidemiologico;

namespace CAPA_ENTIDAD.DTO
{
    public class DatosRegistroEpidemiologicoDTO
    {
        public DateTime fecha_generacion { get; set; }
        public List<DatosVigilancium>? DatosVigilancium { get; set; }
        public DatosNeonato? datosNeonato { get; set; }
        public DatosMadre? datosMadre { get; set; }
        public VigilanciaEpidemiologica? VigilanciaEpidemiologica { get; set; }

        public string? DNI { get; set; }

        public string? DNI_personal { get; set; }

        public int? IdCama { get; set; }

        public string? IdServicio { get; set; }

        public string? IdDependencia { get; set; }
        public string? Dx_ingreso { get; set; }



    }
}

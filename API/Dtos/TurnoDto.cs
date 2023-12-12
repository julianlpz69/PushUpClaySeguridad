using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class TurnoDto
    {
         public int Id { get; set; }

        public string NombreTurno { get; set; }

        public float? HoraTurnoInicio { get; set; }

        public float? HoraTurnoFinal { get; set; }
    }
}
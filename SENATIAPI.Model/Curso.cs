using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENATIAPI.Model
{
    public class Curso
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int DocenteId { get; set; }
        public virtual Docente Docente { get; set; }
        public bool Enabled { get; set; }
    }
}

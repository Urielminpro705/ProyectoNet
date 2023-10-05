using System.ComponentModel.DataAnnotations.Schema;

namespace Universidad.Models {
    public class Curso {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_curso {get;set;}
        public string titulo {get;set;}
        public int creditos {get;set;}

        public ICollection<Inscripcion> Inscripciones {get;set;}
    }
}
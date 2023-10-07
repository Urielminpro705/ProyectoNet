using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Universidad.Models {
    public class Curso {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int id_curso {get;set;}
        public string titulo {get;set;}
        public int creditos {get;set;}

        public ICollection<Inscripcion> Inscripciones {get;set;}
    }
}
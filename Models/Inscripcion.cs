using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Universidad.Models {
    public enum Grado {
        A,B,C,D
    }
    public class Inscripcion {
        [Key]
        public int id_inscripcion {get;set;}
        [ForeignKey("Curso")]
        public int id_curso {get;set;}
        [ForeignKey("Estudiante")]
        public int id_estudiante {get;set;}
        // [Display.Format(null.DisplayText="Sin Grado")]
        [Display(Name = "Sin Grado")]
        
        public Curso Curso {get;set;}
        public Estudiante Estudiante {get;set;}
    }
}
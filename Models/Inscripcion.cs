using System.ComponentModel.DataAnnotations;
namespace Universidad.Models {
    public enum Grado {
        A,B,C,D
    }
    public class Inscripcion {
        public int id_inscripcion {get;set;}
        public int id_curso {get;set;}
        public int id_estudiante {get;set;}
        // [Display.Format(null.DisplayText="Sin Grado")]
        [Display(Name = "Sin Grado")]
        
        public Curso Curso {get;set;}
        public Estudiante Estudiante {get;set;}
    }
}
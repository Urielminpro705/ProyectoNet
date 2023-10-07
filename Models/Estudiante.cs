using System.ComponentModel.DataAnnotations;
namespace Universidad.Models {
    public class Estudiante {
        [Key]
        public int id_estudiante {get;set;}
        public string Apellidos {get;set;}
        public string Nombre {get;set;}
        public DateTime Fecha_de_inscripcion {get;set;}
        public ICollection<Inscripcion> Inscripciones {get;set;}
    }
}
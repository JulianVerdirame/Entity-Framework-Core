using System.Collections.Generic;

namespace LeerData
{
    public class Instructor
    {
        public int InstructorID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Grado { get; set; }
        public byte[] FotoPerfil { get; set; }
        public ICollection<CursoInstructor> Cursos { get; set; }//Propiedad con tabla intermedia por relacion muchos a muchos con la tabla Curso (Propiedad de navegacion)
        public Direccion Direccion { get; set; } //(Propiedad de navegacion)
    }
}
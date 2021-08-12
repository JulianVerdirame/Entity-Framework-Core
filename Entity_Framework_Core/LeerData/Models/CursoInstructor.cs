using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace LeerData
{
    public class CursoInstructor
    {
        public int CursoID { get; set; }
        public int InstructorID { get; set; }
        public Curso Curso { get; set; }//Es el "ancla" necesario para la relacion muchos a muchos con Curso (Propiedad de navegacion)
        public Instructor Instructor { get; set; }//Es el "ancla" necesario para la relacion muchos a muchos con Instructor (Propiedad de navegacion)
    }
}
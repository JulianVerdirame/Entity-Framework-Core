using System;
using System.Collections.Generic;

namespace LeerData
{
    public class Curso
    {
        public int CursoID {get;set;}
        public string Titulo {get;set;}
        public string Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public Precio PrecioPromocion { get; set; } //Propiedad Precio para la relacion uno a uno con la tabla Precio (Propiedad de navegacion)
        public ICollection<Comentario> Comentarios { get; set; } //Propiedad Collection para la relacion uno a muchos con la tabla Comentario (Propiedad de navegacion)
        public ICollection<CursoInstructor> Instructores { get; set; }//Propiedad con tabla intermedia por relacion muchos a muchos con la tabla Instructor (Propiedad de navegacion)
    }
}
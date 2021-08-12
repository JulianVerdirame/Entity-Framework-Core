namespace LeerData
{
    public class Comentario
    {
        public int ComentarioID { get; set; }
        public string Alumno { get; set; }
        public int Puntaje { get; set; }
        public string Texto { get; set; }
        public int CursoID { get; set; }
        public Curso Curso { get; set; } //Es el "ancla" necesario para la relacion muchos a uno con la tabla Curso (Propiedad de navegacion)
    }
}
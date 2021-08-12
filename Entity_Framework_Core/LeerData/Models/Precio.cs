namespace LeerData
{
    public class Precio
    {
        public int PrecioID { get; set; }
        public decimal PrecioActual { get; set; }
        public decimal Promocion { get; set; }
        public int CursoID { get; set; } //Solo representa una columna de la tabla
        public Curso Curso { get; set; }//Es el "ancla" necesario para la relacion uno a uno con la tabla Curso (Propiedad de navegacion)
    }
}
namespace LeerData
{
    public class Direccion
    {
        public int DireccionID { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public int InstructorID { get; set; }
        public Instructor Instructor { get; set; } //(Propiedad de navegacion)
    }
}
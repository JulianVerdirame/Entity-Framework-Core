using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;

namespace LeerData
{
    //Esta clase es la encargada de tener la configuracion de conexion hacie el SQL Server
    public class CursosOnlineContext : DbContext /*El DbConext es una parte del Entityframewor, una instancia del DbContext representa una sesion con la BD
                    Es una instancia, una representacion de la BD, y por lo tanto tiene acceso a los diferentes elementos de la BD (Tablas, view, SP, etc..)*/
    {
        private const string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=CursosOnline;Integrated Security=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Crea la instancia hacia el servidor
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //Como la clase intermedia tiene dos claves primarias, es necesario este metodo para especificarlo
        {
            modelBuilder.Entity<CursoInstructor>().HasKey(ci => new {ci.CursoID, ci.InstructorID});
            // modelBuilder.Entity<Direccion>().HasOne(i => i.Instructor).IsRequired();
        }

        public DbSet<Curso> Curso{get;set;} //Un DbSet dentro del DbContext representa una tabla o una view de la BD
        public DbSet<Precio> Precio { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<CursoInstructor> CursoInstructor { get; set; }//Las entidades intermedias para las relaciones muchos a muchos tambien hay que declararlas como DbSet
        public DbSet<Direccion> Direccion { get; set; }
    }
}
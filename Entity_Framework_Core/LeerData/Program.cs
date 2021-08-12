using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;

namespace LeerData
{
    class Program
    {
        //  Para correr el proyecto escribir en Terminal: dotnet run --project nombreProyecto (En este caso nombrePoryecto seria LeerData)
        static void Main(string[] args)
        {
            using(var db = new CursosOnlineContext())
            {
                //var curso = db.Curso; //Eso solo devuelve la data de Curso
                var Curso = db.Curso                    //Esto es una consulta de tipo Eager Loading, al momento de hacer los include trae toda la informacion de la BD..
                    .Include(p => p.PrecioPromocion)    //Con Lazy Loading no es necesario los Include, y solo trae la info de la BD a medida que la vamos solicitando.
                    .Include(c => c.Comentarios)
                    .Include(ci => ci.Instructores).ThenInclude(i => i.Instructor).ThenInclude(d => d.Direccion) //Al ser relacion muchos a muchos, primero debemos incluir la tabla intermedia y entonces incluir la tabla correspondiente
                    .AsNoTracking(); //Se agrega el Include si deseamos que tambien traiga la data relacionada con otra tabla.
                foreach(var curso in Curso)
                {
                    decimal precio = curso.PrecioPromocion.Promocion;
                    string strPrecio = precio.ToString("N2"); //Convierte a string dejando solo 2 decimales
                    Console.WriteLine("\n\nCurso: " + curso.Titulo + " --- $" + strPrecio);

                    Console.WriteLine("\nInstructores: ");
                    foreach(var ins in curso.Instructores)
                    {
                        Direccion dire = ins.Instructor.Direccion;
                        if(ins.Instructor.Direccion != null){ //Si la BD no tiene un Instructor sin relacion con Direccion, falla. Alguna otra manera de solucionar esto?????
                            Console.WriteLine(ins.Instructor.Nombre + " " + ins.Instructor.Apellido + " - " + dire.Calle + " " + dire.Numero + ". ");
                        }
                        else Console.WriteLine(ins.Instructor.Nombre + " " + ins.Instructor.Apellido + " - Sin direccion en Base de Datos");
                    }

                    ICollection<Comentario> lstComentario = curso.Comentarios; /*Guardamos la lista de comentarios para recorrerla y mostrarlos 
                                                                        (Se puede hacer directo en el foreach pero lo dejo para que sea visible el tipo ICollection)*/

                    Console.WriteLine("\nComentarios: ");
                    foreach(var comentario in lstComentario)
                    {
                        Console.WriteLine("---> " + comentario.Texto + "\nAutor:" + comentario.Alumno + "\n");
                    }
                    Console.WriteLine("\n\n");
                }
            }
            
            // using(var db2 = new CursosOnlineContext())
            // {
            //     var Curso2 = db2.Curso.Include(ci => ci.Instructores).ThenInclude(i => i.Instructor.Select(d => d.Direccion)).AsNoTracking();
                
            //     foreach(var curso in Curso2){
            //         Console.WriteLine("Curso: " + curso.Titulo);

            //         foreach(var ins in curso.Instructores){
            //             Console.WriteLine("Instructores: " + ins.Instructor.Nombre + " Direccion: " + ins.Instructor.Direccion.Calle);
            //         }
            //     }
            // }
        }
    }
}

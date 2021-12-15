using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDBContext:DbContext
    {







                                                                                   //Para cuando tenemos que dar valor a un atributo de la clase padre y no existan inconevenientes al hacer asignacion de un valor
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {



        }

        //Tablas de nuestra BD

        public DbSet<Usuario> Usuario { get; set; }





    }
}

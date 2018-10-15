using ClasesAPI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiTaller.APIS.Models
{
    public class PublicacionContext :DbContext
    {
        public PublicacionContext() : base("PublicacionesConnection")
        {
            
        }

        public DbSet<Publicacion> Publicaciones { get; set; }
    }
}
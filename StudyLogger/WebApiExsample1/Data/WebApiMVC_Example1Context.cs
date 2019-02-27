using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApiMVC_Example1.Models
{
    public class WebApiMVC_Example1Context : DbContext
    {
        public WebApiMVC_Example1Context (DbContextOptions<WebApiMVC_Example1Context> options)
            : base(options)
        {
        }

        public DbSet<WebApiMVC_Example1.Models.ExampleModel> ExampleModel { get; set; }
    }
}

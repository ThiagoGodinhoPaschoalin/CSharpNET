using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppApiExample1.Model;

namespace WebAppApiExample1.Models
{
    public class WebAppApiExample1Context : DbContext
    {
        public WebAppApiExample1Context (DbContextOptions<WebAppApiExample1Context> options)
            : base(options)
        {
        }

        public DbSet<ExampleModel> ExampleModel { get; set; }
    }
}

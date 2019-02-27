using Microsoft.EntityFrameworkCore;

namespace WebApiMVC_UsingLoggerFactoryAndDB.Models
{
    /// <summary>
    /// Somente para fazer o migration!
    /// Pesquisar sobre, como fazer migrations diretamente usando Dapper!
    /// </summary>
    public class LogEventContext : DbContext
    {
        public LogEventContext (DbContextOptions<LogEventContext> options)
            : base(options)
        {

        }

        public DbSet<LogEventModel> LogEventModel { get; set; }
    }
}

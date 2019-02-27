using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiMVC_UsingLoggerFactoryAndDB.Models
{
    [Table("log_event", Schema = "logger")]
    public class LogEventModel
    {
        public Guid Id { get; set; }
        public int? EventId { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public DateTime? CreatedTime { get; set; }
    }
}

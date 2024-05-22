using Microsoft.EntityFrameworkCore;
using Backend_TeaTech.Models;

namespace Backend_TeaTech.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public ConnectionContext(DbContextOptions<ConnectionContext> options): base(options)
        {
        }
        public DbSet<ChildAssisted> ChildAssisteds { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Responsible> Responsibles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PreAnalysis> PreAnalysiss { get; set; }
        public DbSet<Assessment> Assessments { get; set; }  
        public DbSet<ProgramAssisted> Programs { get; set;}
    } 
}

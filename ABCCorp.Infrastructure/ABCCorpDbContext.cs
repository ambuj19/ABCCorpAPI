using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ABCCorp.Infrastructure
{
    public class ABCCorpDbContext: DbContext
    {
        public ABCCorpDbContext(DbContextOptions<ABCCorpDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Domain.Models.Task> Task { get; set; }
        public virtual DbSet<Domain.Models.EmployeInfo> EmployeInfo { get; set; }
        public virtual DbSet<Domain.Models.EmployeeTasks> EmployeeTasks { get; set; }
    }
}

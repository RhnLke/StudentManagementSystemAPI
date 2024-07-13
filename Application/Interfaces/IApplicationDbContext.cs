using Domain.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<City_tbl> City_tbls { get; set; }

        public DbSet<Course_tbl> Course_tbls { get; set; }

        public DbSet<DegreeType_tbl> DegreeType_tbls { get; set; }

        public DbSet<Gender_tbl> Gender_tbls { get; set; }

        public DbSet<Student_tbl> Student_tbls { get; set; }

        public DbSet<Subject_tbl> Subject_tbls { get; set; }

        public DatabaseFacade Database { get;}

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void UpdateRange([NotNull] IEnumerable<object> entities);
        EntityEntry Update([NotNull] object entity);
    }
}

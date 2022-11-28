using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InspectionAnalysis
{
    public class InspectionDatasContext : DbContext
    {
        public DbSet<InspectResult> InspectResults { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<WorkData> WorkDatas { get; set; } = null!;
        public DbSet<WorkDataChangeLog> WorkDataChangeLogs { get; set; } = null!;

        public string DatabaseName { get; set; } = "InspectionDatas";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Host=localhost; Port=5432; Database=" + DatabaseName + "; Username=postgres; Password=asvt; Include Error Detail=true;";
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

    }
}

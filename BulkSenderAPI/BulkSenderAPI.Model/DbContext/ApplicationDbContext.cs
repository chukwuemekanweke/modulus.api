using BulkSenderAPI.Model.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkSenderAPI.Model.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<PayrollPaymentBatch> PayrollPaymentBatches { get; set; }
        public DbSet<PayrollPaymentBatchDetails> payrollPaymentBatchDetails { get; set; }
        public DbSet<PayrollSchedule> PayrollSchedules { get; set; }
        public DbSet<PayrollSchedulePaymentEvent> PayrollSchedulePaymentEvents { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<StaffDesignation> StaffDesignations { get; set; }
        public DbSet<StaffPaymentEvent> StaffPaymentEvents { get; set; }





        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (Microsoft.EntityFrameworkCore.Metadata.IMutableForeignKey relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }



        }


    }
}

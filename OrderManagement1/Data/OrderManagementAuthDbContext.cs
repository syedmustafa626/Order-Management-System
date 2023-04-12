using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement1.Data
{
    public class OrderManagementAuthDbContext : IdentityDbContext
    {
        public OrderManagementAuthDbContext(DbContextOptions<OrderManagementAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "51efc669-46f3-4a79-96c8-99ac4adbf97f";
            var writerRoleId = "d531b57a-2630-4c86-b1e0-0f03a9ac1071";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp= readerRoleId,
                    Name="Reader",
                    NormalizedName="Reader".ToUpper()
                },

                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp= writerRoleId,
                    Name="Writer",
                    NormalizedName="Writer".ToUpper()
                }
            };
            builder.Entity<IdentityRole>().HasData(roles.ToArray());
        }
    }
}

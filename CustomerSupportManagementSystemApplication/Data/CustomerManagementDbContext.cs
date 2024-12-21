using CustomerSupportManagementSystemApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CustomerSupportManagementSystemApplication.Data
{
    /// <summary>
    /// Represents the database context for the Customer Support Management System application.
    /// Provides access to the Users and Tickets entities for performing CRUD operations.
    /// </summary>
    public class CustomerManagementDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the CustomerManagementDbContext with the specified options.
        /// </summary>
        /// <param name="options">The options to be used by the DbContext.</param>
        public CustomerManagementDbContext(DbContextOptions<CustomerManagementDbContext> options) : base(options) { }

        /// <summary>
        /// Gets or sets the Users table in the database.
        /// </summary>
        public DbSet<Users> Users { get; set; }

        /// <summary>
        /// Gets or sets the Tickets table in the database.
        /// </summary>
        public DbSet<Tickets> Tickets { get; set; }
    }
}

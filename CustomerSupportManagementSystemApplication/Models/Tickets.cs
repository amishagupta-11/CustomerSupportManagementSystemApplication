using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSupportManagementSystemApplication.Models
{
    /// <summary>
    /// Represents a ticket in the Customer Support Management System.
    /// Contains information about the ticket's issue, status, category, and timestamps.
    /// </summary>
    public class Tickets
    {
        /// <summary>
        /// Gets or sets the unique identifier for the ticket.
        /// </summary>
        [Key]
        public Guid TicketId { get; set; }

        /// <summary>
        /// Gets or sets the issue description of the ticket.
        /// This field is required.
        /// </summary>
        [Required]
        public string? Issue { get; set; }

        /// <summary>
        /// Gets or sets the current status of the ticket.
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who created the ticket.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the category of the ticket.
        /// </summary>
        public string? Category { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the ticket was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the ticket was last updated.
        /// This field is nullable.
        /// </summary>
        public DateTime? LastUpdatedDate { get; set; }

        // Navigation Properties

        /// <summary>
        /// Gets or sets the user who created the ticket.
        /// </summary>
        [ForeignKey("CreatedBy")]
        public Users? CreatedByUser { get; set; }
    }
}

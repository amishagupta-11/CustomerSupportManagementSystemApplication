using System.ComponentModel.DataAnnotations;

namespace CustomerSupportManagementSystemApplication.Models
{
    /// <summary>
    /// Represents a user in the Customer Support Management System.
    /// Contains information about the user's name, email, password, role, and creation date.
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// The name must contain only letters.
        /// </summary>
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name must contain only letters.")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// The email must be a valid email format.
        /// </summary>
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
            ErrorMessage = "Please enter a valid email address.")]
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the password for the user.
        /// The password must be at least 8 characters long.
        /// </summary>
        [Required]
        [RegularExpression(@"^.{8,}$", ErrorMessage = "Password must be at least 8 characters long.")]
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets the role of the user.
        /// </summary>
        public string? Role { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}

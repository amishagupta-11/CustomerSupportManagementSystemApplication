using CustomerSupportManagementSystemApplication.Models;

namespace CustomerSupportManagementSystemApplication.Interface
{
    /// <summary>
    /// Defines the contract for the user service in the Customer Support Management System application.
    /// Provides methods for managing and performing operations on users.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Asynchronously retrieves all users in the system.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with a result of the list of users.</returns>
        Task<IEnumerable<Users>> GetAllUsersAsync();

        /// <summary>
        /// Asynchronously creates a new user.
        /// </summary>
        /// <param name="user">The user to be created.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task CreateUserAsync(Users user);
    }
}

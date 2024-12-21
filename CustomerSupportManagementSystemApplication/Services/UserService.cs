using CustomerSupportManagementSystemApplication.Interface;
using CustomerSupportManagementSystemApplication.Models;

namespace CustomerSupportManagementSystemApplication.Services
{
    /// <summary>
    /// Service class for managing users in the Customer Support Management System.
    /// Provides methods for retrieving users and creating new users.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly ICustomerManangementRepo<Users> _userRepository;

        /// <summary>
        /// Initializes a new instance of the UserService with the provided user repository.
        /// </summary>
        /// <param name="userRepository">The repository used to interact with the user data.</param>
        public UserService(ICustomerManangementRepo<Users> userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Asynchronously retrieves all users from the repository.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with a result of the list of users.</returns>
        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        /// <summary>
        /// Asynchronously creates a new user and saves it to the repository.
        /// </summary>
        /// <param name="user">The user to be created.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task CreateUserAsync(Users user)
        {
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
        }
    }
}

using CustomerSupportManagementSystemApplication.Models;
using CustomerSupportManagementSystemApplication.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CustomerSupportManagementSystemApplication.Areas.Admin.Controllers
{
    /// <summary>
    /// Controller for managing the Admin area of the Customer Support Management System application. 
    /// Handles operations related to viewing and managing tickets, as well as creating and managing users.
    /// </summary>
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the HomeController with dependencies for ticket and user services.
        /// </summary>
        /// <param name="ticketService">Service for handling ticket-related operations.</param>
        /// <param name="userService">Service for handling user-related operations.</param>
        public HomeController(ITicketService ticketService, IUserService userService)
        {
            _ticketService = ticketService;
            _userService = userService;
        }

        /// <summary>
        /// Displays the list of all tickets in the system.
        /// </summary>
        /// <returns>A view displaying the tickets.</returns>
        public async Task<IActionResult> Index()
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            return View(tickets);
        }

        /// <summary>
        /// Displays the list of all users in the system for management purposes.
        /// </summary>
        /// <returns>A view displaying the users.</returns>
        public async Task<IActionResult> ManageUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return View(users);
        }

        /// <summary>
        /// Renders the Create User form for adding a new user to the system.
        /// </summary>
        /// <returns>A view displaying the Create User form.</returns>
        public IActionResult CreateUser()
        {
            return View();
        }

        /// <summary>
        /// Handles the creation of a new user in the system.
        /// </summary>
        /// <param name="user">The user details submitted from the form.</param>
        /// <returns>
        /// Redirects to the Manage Users page if successful; otherwise, redisplays the form with validation errors.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(Users user)
        {
            if (ModelState.IsValid)
            {
                user.CreatedDate = DateTime.UtcNow;
                await _userService.CreateUserAsync(user);

                return RedirectToAction("ManageUsers");
            }

            return View(user);
        }
    }
}

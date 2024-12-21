using CustomerSupportManagementSystemApplication.Interface;
using CustomerSupportManagementSystemApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerSupportManagementSystemApplication.Areas.Customer.Controllers
{
    /// <summary>
    /// Controller for managing the Customer area of the Customer Support Management System application. 
    /// Handles ticket-related operations, including creating, viewing, and deleting tickets for customers.
    /// </summary>
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ITicketService _ticketService;

        /// <summary>
        /// Initializes a new instance of the HomeController with dependencies for ticket services.
        /// </summary>
        /// <param name="ticketService">Service for handling ticket-related operations.</param>
        public HomeController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        /// <summary>
        /// Displays the list of tickets associated with the logged-in customer.
        /// </summary>
        /// <returns>A view displaying the tickets.</returns>
        public async Task<IActionResult> Index()
        {
            var userId = User.Identity?.Name;
            var tickets = await _ticketService.GetAllTicketsAsync();
            return View(tickets);
        }

        /// <summary>
        /// Renders the Create Ticket form for the customer to submit a new support ticket.
        /// </summary>
        /// <returns>A view displaying the Create Ticket form.</returns>
        public IActionResult CreateTicket()
        {
            return View();
        }

        /// <summary>
        /// Handles the creation of a new ticket submitted by the customer.
        /// </summary>
        /// <param name="ticket">The ticket details submitted from the form.</param>
        /// <returns>
        /// Redirects to the ticket list page if successful.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> CreateTicket(Tickets ticket)
        {
            ticket.CreatedDate = DateTime.UtcNow;
            ticket.Status = "Open";
            await _ticketService.CreateTicketAsync(ticket);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Deletes a ticket identified by its unique ID.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket to be deleted.</param>
        /// <returns>
        /// Redirects to the ticket list page after the ticket is deleted.
        /// </returns>
        public async Task<IActionResult> DeleteTicket(Guid id)
        {
            await _ticketService.DeleteTicketAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

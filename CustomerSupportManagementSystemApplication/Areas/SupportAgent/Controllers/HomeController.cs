using CustomerSupportManagementSystemApplication.Models;
using CustomerSupportManagementSystemApplication.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CustomerSupportManagementSystemApplication.Areas.SupportAgent.Controllers
{
    /// <summary>
    /// Controller for managing the Support Agent area of the Customer Support Management System application.
    /// Handles ticket-related operations, including viewing and editing tickets assigned to support agents.
    /// </summary>
    [Area("SupportAgent")]
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
        /// Displays the list of all tickets in the system for the support agent to manage.
        /// </summary>
        /// <returns>A view displaying the tickets.</returns>
        // GET: SupportAgent/Home/Index
        public async Task<IActionResult> Index()
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            return View(tickets);
        }

        /// <summary>
        /// Displays the Edit Ticket form for the support agent to modify a ticket.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket to be edited.</param>
        /// <returns>
        /// A view displaying the ticket details for editing, or a NotFound result if the ticket does not exist.
        /// </returns>
        // GET: SupportAgent/Home/EditTicket/{id}
        public async Task<IActionResult> EditTicket(Guid id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null)
                return NotFound();

            return View(ticket);
        }

        /// <summary>
        /// Handles the update of a ticket's status and last updated date by the support agent.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket being updated.</param>
        /// <param name="updatedTicket">The ticket details submitted from the form.</param>
        /// <returns>
        /// Redirects to the ticket list page after the ticket is updated, or returns a BadRequest or NotFound result if validation fails.
        /// </returns>
        // POST: SupportAgent/Home/EditTicket/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTicket(Guid id, Tickets updatedTicket)
        {
            if (id != updatedTicket.TicketId)
                return BadRequest();

            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null)
                return NotFound();

            ticket.Status = updatedTicket.Status;
            ticket.LastUpdatedDate = DateTime.UtcNow;

            await _ticketService.UpdateTicketAsync(ticket);

            return RedirectToAction(nameof(Index));
        }
    }
}

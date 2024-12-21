using CustomerSupportManagementSystemApplication.Models;

namespace CustomerSupportManagementSystemApplication.Interface
{
    /// <summary>
    /// Defines the contract for the ticket service in the Customer Support Management System application.
    /// Provides methods for managing and performing operations on tickets.
    /// </summary>
    public interface ITicketService
    {
        /// <summary>
        /// Asynchronously retrieves all tickets in the system.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with a result of the list of tickets.</returns>
        Task<IEnumerable<Tickets>> GetAllTicketsAsync();

        /// <summary>
        /// Asynchronously retrieves a ticket by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket to be retrieved.</param>
        /// <returns>A task representing the asynchronous operation, with a result of the ticket.</returns>
        Task<Tickets> GetTicketByIdAsync(Guid id);

        /// <summary>
        /// Asynchronously creates a new ticket.
        /// </summary>
        /// <param name="ticket">The ticket to be created.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task CreateTicketAsync(Tickets ticket);

        /// <summary>
        /// Asynchronously updates an existing ticket.
        /// </summary>
        /// <param name="ticket">The ticket with updated information.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateTicketAsync(Tickets ticket);

        /// <summary>
        /// Asynchronously deletes a ticket by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket to be deleted.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteTicketAsync(Guid id);
    }
}

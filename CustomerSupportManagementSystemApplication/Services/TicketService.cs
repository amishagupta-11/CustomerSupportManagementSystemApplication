using CustomerSupportManagementSystemApplication.Interface;
using CustomerSupportManagementSystemApplication.Models;

namespace CustomerSupportManagementSystemApplication.Services
{
    /// <summary>
    /// Service class for managing tickets in the Customer Support Management System.
    /// Provides methods for CRUD operations on tickets using the repository pattern.
    /// </summary>
    public class TicketService : ITicketService
    {
        private readonly ICustomerManangementRepo<Tickets> _ticketRepository;

        /// <summary>
        /// Initializes a new instance of the TicketService with the provided ticket repository.
        /// </summary>
        /// <param name="ticketRepository">The repository used to interact with the ticket data.</param>
        public TicketService(ICustomerManangementRepo<Tickets> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        /// <summary>
        /// Asynchronously retrieves all tickets from the repository.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with a result of the list of tickets.</returns>
        public async Task<IEnumerable<Tickets>> GetAllTicketsAsync()
        {
            return await _ticketRepository.GetAllAsync();
        }

        /// <summary>
        /// Asynchronously retrieves a ticket by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket.</param>
        /// <returns>A task representing the asynchronous operation, with a result of the ticket.</returns>
        public async Task<Tickets> GetTicketByIdAsync(Guid id)
        {
            return await _ticketRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Asynchronously creates a new ticket and saves it to the repository.
        /// </summary>
        /// <param name="ticket">The ticket to be created.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task CreateTicketAsync(Tickets ticket)
        {
            await _ticketRepository.AddAsync(ticket);
            await _ticketRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Asynchronously updates an existing ticket in the repository.
        /// </summary>
        /// <param name="ticket">The ticket to be updated.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateTicketAsync(Tickets ticket)
        {
            _ticketRepository.Update(ticket);
            await _ticketRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Asynchronously deletes a ticket from the repository by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the ticket to be deleted.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteTicketAsync(Guid id)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);
            if (ticket != null)
            {
                _ticketRepository.Remove(ticket);
                await _ticketRepository.SaveChangesAsync();
            }
        }
    }
}

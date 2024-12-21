using CustomerSupportManagementSystemApplication.Data;
using CustomerSupportManagementSystemApplication.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CustomerSupportManagementSystemApplication.Repositories
{
    /// <summary>
    /// Implements the repository pattern for managing entities in the Customer Support Management System.
    /// Provides methods for basic CRUD operations (Create, Read, Update, Delete) on generic entities.
    /// </summary>
    /// <typeparam name="T">The type of entity the repository will handle.</typeparam>
    public class CustomerManangementRepo<T> : ICustomerManangementRepo<T> where T : class
    {
        private readonly CustomerManagementDbContext _context; // Use specific DbContext type

        /// <summary>
        /// Initializes a new instance of the repository with the given DbContext.
        /// </summary>
        /// <param name="context">The DbContext to interact with the database.</param>
        public CustomerManangementRepo(CustomerManagementDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Asynchronously retrieves all entities of type T from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with a result of the list of entities.</returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Asynchronously retrieves an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>A task representing the asynchronous operation, with a result of the entity.</returns>
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Asynchronously retrieves a list of entities that match a given predicate.
        /// </summary>
        /// <param name="predicate">The predicate to filter the entities.</param>
        /// <returns>A task representing the asynchronous operation, with a result of the list of entities that match the predicate.</returns>
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        /// <summary>
        /// Asynchronously adds a new entity to the database.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        /// <summary>
        /// Updates an existing entity in the database.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        /// <summary>
        /// Removes an entity from the database.
        /// </summary>
        /// <param name="entity">The entity to be removed.</param>
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Asynchronously saves changes to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

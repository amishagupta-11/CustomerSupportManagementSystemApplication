using System.Linq.Expressions;

namespace CustomerSupportManagementSystemApplication.Interface
{
    /// <summary>
    /// Defines the contract for a generic repository for managing entities in the Customer Support Management System application.
    /// Provides basic CRUD operations and querying capabilities.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public interface ICustomerManangementRepo<T> where T : class
    {
        /// <summary>
        /// Asynchronously retrieves all entities of type T.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with a result of the list of entities.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Asynchronously retrieves an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to be retrieved.</param>
        /// <returns>A task representing the asynchronous operation, with a result of the entity.</returns>
        Task<T> GetByIdAsync(Guid id);

        /// <summary>
        /// Asynchronously finds entities that match a specific condition.
        /// </summary>
        /// <param name="predicate">The condition to filter entities by.</param>
        /// <returns>A task representing the asynchronous operation, with a result of the filtered entities.</returns>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Asynchronously adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity with updated values.</param>
        void Update(T entity);

        /// <summary>
        /// Removes an entity from the repository.
        /// </summary>
        /// <param name="entity">The entity to be removed.</param>
        void Remove(T entity);

        /// <summary>
        /// Asynchronously saves changes to the repository.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task SaveChangesAsync();
    }
}

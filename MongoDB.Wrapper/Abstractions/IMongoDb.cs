﻿using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MongoDB.Wrapper.Abstractions
{
    public interface IMongoDb
    {
        /// <summary>
        /// Returns a query to operate on
        /// </summary>
        /// <typeparam name="TEntity">Type of entities</typeparam>
        /// <param name="includeDeleted">When true, items returned in evaluation of query will contain (soft) deleted entites, otherwise they will be filtered out</param>
        IMongoQueryable<TEntity> Query<TEntity>(bool includeDeleted = false) where TEntity : IEntity;

        /// <summary>
        /// Assigns a new Id to entity and adds it to collection of type TEntity
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="obj">Entity to add</param>
        Task Add<TEntity>(TEntity entity) where TEntity : IEntity;

        /// <summary>
        /// Returns whether the collection of type TEntity contains entites matching the predicate
        /// </summary>
        /// <typeparam name="TEntity">Type of entities</typeparam>
        /// <param name="predicate">Predicate to compare entities against</param>
        /// <param name="includeDeleted">When set to true, the query will also look for (soft) deleted entites</param>
        Task<bool> Any<TEntity>(Expression<Func<TEntity, bool>> predicate, bool includeDeleted = false) where TEntity : IEntity;

        /// <summary>
        /// Returns whether the collection of type TEntity contains entites
        /// </summary>
        /// <typeparam name="TEntity">Type of entities</typeparam>
        /// <param name="includeDeleted">When set to true, the query will also look for (soft) deleted entites</param>
        Task<bool> Any<TEntity>(bool includeDeleted = false) where TEntity : IEntity;

        /// <summary>
        /// Returns the count of entites in the collection of type TEntity that match given predicate
        /// </summary>
        /// <typeparam name="TEntity">Type of entities</typeparam>
        /// <param name="predicate">Predicate to compare entities against</param>
        /// <param name="includeDeleted">When set to true, the query will also count (soft) deleted entites</param>
        Task<int> Count<TEntity>(Expression<Func<TEntity, bool>> predicate, bool includeDeleted = false) where TEntity : IEntity;

        /// <summary>
        /// Returns the count of entites in the collection of type TEntity
        /// </summary>
        /// <typeparam name="TEntity">Type of entities</typeparam>
        /// <param name="includeDeleted">When set to true, the query will also count (soft) deleted entites</param>
        Task<int> Count<TEntity>(bool includeDeleted = false) where TEntity : IEntity;

        /// <summary>
        /// Returns entity of type TEntity, which Id equals passed Guid. Default if not found
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="id">Entity Id</param>
        Task<TEntity> Get<TEntity>(Guid id) where TEntity : IEntity;

        /// <summary>
        /// Returns the first entity from collection of type TEntity, that matches the predicate
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="predicate">Predicate to compare entities against</param>
        /// <param name="includeDeleted">When set to true, the query will also search within (soft) deleted entites</param>
        Task<TEntity> FirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> predicate, bool includeDeleted = false) where TEntity : IEntity;

        /// <summary>
        /// Returns the entity from collection of type TEntity, that matches the predicate. If more than one entity matches the predicate, an exception is thrown
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="predicate">Predicate to compare entities against</param>
        /// <param name="includeDeleted">When set to true, the query will also search within (soft) deleted entites</param>
        Task<TEntity> SingleOrDefault<TEntity>(Expression<Func<TEntity, bool>> predicate, bool includeDeleted = false) where TEntity : IEntity;

        /// <summary>
        /// Returns list of entities from collection of type TEntity, that match the predicate
        /// </summary>
        /// <typeparam name="TEntity">Type of entities</typeparam>
        /// <param name="predicate">Predicate to compare entities against</param>
        /// <param name="includeDeleted">When set to true, the query will also return (soft) deleted entites</param>
        Task<List<TEntity>> Get<TEntity>(Expression<Func<TEntity, bool>> predicate, bool includeDeleted = false) where TEntity : IEntity;

        /// <summary>
        /// Returns list of entities from collection of type TEntity
        /// </summary>
        /// <typeparam name="TEntity">Type of entities</typeparam>
        /// <param name="includeDeleted">When set to true, the query will also return (soft) deleted entites</param>
        Task<List<TEntity>> Get<TEntity>(bool includeDeleted = false) where TEntity : IEntity;

        /// <summary>
        /// Replaces the object of type TEntity with passed object, compared by IEntity.Id. If IEntity.Id equals default, entity is added.
        /// When entity with given id is not found, an exception is thrown.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="obj">Updated (or new) object</param>
        Task Replace<TEntity>(TEntity entity) where TEntity : IEntity;
    }
}

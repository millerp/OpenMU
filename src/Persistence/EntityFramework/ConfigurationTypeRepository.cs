﻿// <copyright file="ConfigurationTypeRepository.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.Persistence.EntityFramework
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// A repository which gets its data from the <see cref="EntityDataContext.CurrentGameConfiguration"/>, without additionally touching the database.
    /// </summary>
    /// <typeparam name="T">The data object type.</typeparam>
    internal class ConfigurationTypeRepository<T> : IRepository<T>
        where T : class
    {
        private readonly IRepositoryManager repositoryManager;

        private readonly Func<GameConfiguration, ICollection<T>> collectionSelector;

        /// <summary>
        /// A cache which holds each <typeparamref name="T"/> in a dictionary to be able to access it by faster by id.
        /// There is one cache for each <see cref="GameConfiguration"/>, because it could be possible that more than one
        /// <see cref="GameConfiguration"/> could be hosted by one server.
        /// </summary>
        private readonly IDictionary<GameConfiguration, IDictionary<Guid, T>> cache = new ConcurrentDictionary<GameConfiguration, IDictionary<Guid, T>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationTypeRepository{T}"/> class.
        /// </summary>
        /// <param name="repositoryManager">The repository manager.</param>
        /// <param name="collectionSelector">The collection selector which returns the collection of <typeparamref name="T"/> of a <see cref="GameConfiguration"/>.</param>
        public ConfigurationTypeRepository(IRepositoryManager repositoryManager, Func<GameConfiguration, ICollection<T>> collectionSelector)
        {
            this.repositoryManager = repositoryManager;
            this.collectionSelector = collectionSelector;
        }

        /// <summary>
        /// Gets the repository manager of this repository.
        /// </summary>
        protected IRepositoryManager RepositoryManager => this.repositoryManager;

        /// <summary>
        /// Gets all objects by using the <see cref="collectionSelector"/> to the current <see cref="GameConfiguration"/>.
        /// </summary>
        /// <returns>All objects of the repository.</returns>
        public IEnumerable<T> GetAll()
        {
            return this.collectionSelector(this.GetCurrentGameConfiguration());
        }

        /// <inheritdoc />
        public T GetById(Guid id)
        {
            this.EnsureCacheForCurrentConfiguration();
            var dictionary = this.cache[this.GetCurrentGameConfiguration()];
            if (dictionary.TryGetValue(id, out T result))
            {
                return result;
            }

            throw new InvalidDataException($"The object of {nameof(T)} with the specified id {id} could not be found in the game configuration");
        }

        /// <inheritdoc />
        public bool Delete(object obj)
        {
            if (obj is T item)
            {
                var gameConfiguration = this.GetCurrentGameConfiguration();
                var collection = this.collectionSelector(gameConfiguration);
                return collection.Remove(item);
                //// TODO: remove from change tracker?
            }

            return false;
        }

        /// <inheritdoc />
        public bool Delete(Guid id)
        {
            return this.Delete(this.GetById(id));
        }

        /// <inheritdoc />
        object IRepository.GetById(Guid id)
        {
            return this.GetById(id);
        }

        private void EnsureCacheForCurrentConfiguration()
        {
            var configuration = this.GetCurrentGameConfiguration();
            if (this.cache.ContainsKey(configuration))
            {
                return;
            }

            lock (this.cache)
            {
                if (this.cache.ContainsKey(configuration))
                {
                    return;
                }

                var dictionary = this.collectionSelector(configuration)
                    .Where(item => item is IIdentifiable)
                    .ToDictionary(item => ((IIdentifiable)item).Id, item => item);
                this.cache.Add(configuration, dictionary);
            }
        }

        private GameConfiguration GetCurrentGameConfiguration()
        {
            var context = (this.repositoryManager.GetCurrentContext() as EntityFrameworkContext)?.Context as EntityDataContext;
            if (context == null)
            {
                throw new InvalidOperationException("This repository can only be used within an account context.");
            }

            return context.CurrentGameConfiguration;
        }
    }
}
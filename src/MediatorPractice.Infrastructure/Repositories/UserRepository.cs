using MediatorPractice.Application.Common.Repositories;
using MediatorPractice.Domain.Aggregates;
using MediatorPractice.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPractice.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserRepository(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient mongoClient = new(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _userCollection = mongoDatabase.GetCollection<User>(mongoDBSettings.Value.CollectionName);

            //BsonClassMap.RegisterClassMap<User>(classMap =>
            //{
            //    classMap.AutoMap();
            //    classMap.MapIdMember(u => u.Id);
            //    classMap.MapMember(u => u.Name).SetIsRequired(true);
            //    classMap.MapMember(u => u.Email).SetIsRequired(true);
            //    classMap.MapCreator(u => new User());
            //});
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await _userCollection.DeleteOneAsync(u => u.Id == id, cancellationToken: cancellationToken);
        }

        public async Task<User> FindUserByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("Id", id);

            return await _userCollection
                .FindAsync(filter, cancellationToken: cancellationToken)
                .Result
                .SingleAsync(cancellationToken: cancellationToken);
        }

        public async Task Insert(User entity, CancellationToken cancellationToken)
        {
            await _userCollection.InsertOneAsync(entity, cancellationToken: cancellationToken);
        }
    }
}

using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SmartOffice.Issat.API.Models;

namespace SmartOffice.Issat.API.Services
{
    public class UserService
    {
        private readonly IMongoCollection<UserDefinition> _usersCollection;

        public UserService(
        IOptions<SmartOfficeDatabase> SmartOfficeDatabase)
        {

            MongoClient mongoClient = new MongoClient(
                "mongodb://localhost:27017");

            IMongoDatabase mongoDatabase = mongoClient.GetDatabase("SmartOfficeStore");

            _usersCollection = mongoDatabase.GetCollection<UserDefinition>("Users");
        }

        public async Task<List<UserDefinition>> GetAsync() =>
      await _usersCollection.Find(_ => true).ToListAsync();

        public async Task<UserDefinition?> GetUserByNameAsync(string name) =>
           await _usersCollection.Find(x => x.Name == name).FirstOrDefaultAsync();
        public async Task<UserDefinition> GetUserAsync(UserDefinition user)
        =>
            await _usersCollection.Find(x => x.Name == user.Name).FirstOrDefaultAsync();
        
        
           


        public async Task CreateAsync(UserDefinition newUser) =>
            await _usersCollection.InsertOneAsync(newUser);

        public async Task UpdateAsync(string id, UserDefinition updatedUser) =>
            await _usersCollection.ReplaceOneAsync(x => x.Name == id, updatedUser);

        public async Task RemoveAsync(string id) =>
            await _usersCollection.DeleteOneAsync(x => x.Name == id);
      /*  public async Task AddUserAsync(string id, UserDefinition newUser)
        {
            FilterDefinition<User> filter = Builders<UserDefinition>.Filter.Eq("id", id);
            UpdateDefinition<User> update = Builders<UserDefinition>.Update.AddToSet<string>("Name", newUser.Name);
            //UpdateDefinition<User> updatepwd = Builders<User>.Update.AddToSet<string>("Password", newUser.Password);
            await _usersCollection.UpdateOneAsync(filter, update);
        }*/

    }
}

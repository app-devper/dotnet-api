using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Context
{
    public interface IAppContext
    {
        IMongoCollection<User> Users { get; }
        IMongoCollection<Member> Members { get; }
    }
    public class AppContext : IAppContext
    {
        private readonly IMongoDatabase _db;

        public AppContext(IOptions<AppSettings> options, IMongoClient client)
        {
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<User> Users => _db.GetCollection<User>("users");

        public IMongoCollection<Member> Members => _db.GetCollection<Member>("members");
    }
}

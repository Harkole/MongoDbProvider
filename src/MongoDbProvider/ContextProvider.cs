using MongoDB.Driver;
using MongoDbProvider.Interfaces;
using MongoDbProvider.Modules;

namespace MongoDbProvider
{
    public class ContextProvider<T>
    {
        public IMongoCollection<T> Context { get; set; }

        public ContextProvider(IDatabaseOptions options)
        {
            // Create the (Singleton) Client, Database and then return the Context ready for use
            Context = MongoProvider
                .CreateMongoClient(options.ConnectionString)
                .GetDatabase(options.DatabaseName)
                .GetCollection<T>(Pluralizer.Pluralize(nameof(T)));
        }
    }
}
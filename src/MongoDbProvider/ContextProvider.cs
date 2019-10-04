using MongoDB.Driver;
using MongoDbProvider.Interfaces;
using MongoDbProvider.Modules;

namespace MongoDbProvider
{
    public class ContextProvider<T>
    {
        /// <summary>
        /// Provides the accessor to the Context<T>, where <T> is the data 
        /// model/schema to use in the collection. The collection name will
        /// attempt to pluralize the <T> name
        /// </summary>
        public IMongoCollection<T> Context { get; set; }

        /// <summary>
        /// Constructs the Context with the Database Options values provided
        /// </summary>
        /// <param name="options">The connection string and name of the Database to use</param>
        public ContextProvider(IDatabaseOptions options)
        {
            // Create the (Singleton) Client, Database and then return the Context ready for use
            Context = MongoProvider
                .CreateMongoClient(options.ConnectionString)
                .GetDatabase(options.DatabaseName)
                .GetCollection<T>(Pluralizer.Pluralize(typeof(T).Name));
        }
    }
}
using System;
using MongoDB.Driver;

namespace MongoDbProvider.Modules
{
    public static class MongoProvider
    {
        private static Lazy<IMongoClient> lazyMongoClient;

        /// <summary>
        /// When requested will actually create (if not already in existence)
        /// then return the MongoClient object
        /// </summary>
        /// <value>IMongoClient</value>
        internal static IMongoClient MongoClient
        {
            get
            {
                return lazyMongoClient.Value;
            }
        }

        /// <summary>
        /// Creates a single instance of the IMongoClient for use when connecting
        /// to the Collections and Documents
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        internal static IMongoClient CreateMongoClient(string connectionString)
        {
            MongoProvider.lazyMongoClient = new Lazy<IMongoClient>(() =>
            {
                return new MongoClient(connectionString);
            });

            // Return the IMongoClient here so that we can chain the ContextProvider creation
            return MongoClient;
        }
    }
}
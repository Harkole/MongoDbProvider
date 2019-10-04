using MongoDbProvider.Interfaces;

namespace MongoDbProvider.Tests.Models
{
    public class DatabaseOptions : IDatabaseOptions
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
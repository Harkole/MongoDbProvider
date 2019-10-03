namespace MongoDbProvider.Interfaces
{
    public interface IDatabaseOptions
    {
        /// <summary>
        /// Connection string to the MongoDB server
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// The Database to use within the MongoDb Server
        /// </summary>
        string DatabaseName { get; set; }
    }
}
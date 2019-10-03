namespace MongoDbProvider.Interfaces
{
    public interface IDatabaseOptions
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
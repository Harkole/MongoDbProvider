using MongoDB.Driver;
using MongoDbProvider.Interfaces;
using MongoDbProvider.Tests.Models;
using Xunit;

namespace MongoDbProvider.Tests
{
    public class ContextTests
    {
        private readonly IDatabaseOptions options;

        public ContextTests()
        {
            options = new DatabaseOptions
            {
                //! Testing provided via MongoDB running in Docker on localhost with no security
                //* docker run --name mongo-test --mount source=mongodb-test,target=/data/db -p 27017:27017 mongo
                ConnectionString = "mongodb://localhost",
                DatabaseName = "CodeTest"
            };
        }

        [Fact]
        public void ShouldCreateSingletonInstance()
        {
            // Arrange
            ContextProvider<TestModel> provider = new ContextProvider<TestModel>(options);
            string expected = "TestModels";
            
            // Act
            var context = provider.Context.CollectionNamespace.CollectionName;

            // Assert
            Assert.NotEmpty(context);
            Assert.Equal(expected, context);
        }
    }
}
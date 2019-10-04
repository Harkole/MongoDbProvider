using MongoDB.Driver;
using MongoDbProvider.Interfaces;
using MongoDbProvider.Tests.Models;
using Xunit;

namespace MongoDbProvider.Tests
{
    public class ContextTests
    {
        private readonly IDatabaseOptions options;
        private readonly IMongoCollection<TestModel> collection;

        public ContextTests()
        {
            options = new DatabaseOptions
            {
                //! Testing provided via MongoDB running in Docker on localhost with no security
                //* docker run --name mongo-test --mount source=mongodb-test,target=/data/db -p 27017:27017 mongo
                ConnectionString = "mongodb://localhost",
                DatabaseName = "CodeTest"
            };

            collection = new ContextProvider<TestModel>(options).Context;

            // Insert the one document we'll try to select in the test
            collection.InsertOne(new TestModel { Name = "Bilbo", Age = 99 });
        }

        ~ContextTests()
        {
            // Ensure data is cleared (incase of persistance)
            collection.Database.DropCollection("TestModels");
        }

        [Fact]
        public void ShouldCreateSingletonInstance()
        {
            // Arrange
            string expected = "TestModels";
            
            // Act
            var context = collection.CollectionNamespace.CollectionName;

            // Assert
            Assert.NotEmpty(context);
            Assert.Equal(expected, context);
        }

        [Theory]
        [InlineData("Will", 37)]
        [InlineData("Ford", 42)]
        [InlineData("Dave", 105)]
        public void ShouldCreateOneDocument(string name, int age)
        {
            // Arrange
            TestModel data = new TestModel { Name = name, Age = age };

            // Act
            collection.InsertOne(data, new InsertOneOptions { BypassDocumentValidation = false });

            // Assert - MongoDB.Driver will populate the Id field
            Assert.NotEmpty(data.Id);
        }

        [Fact]
        public void ShouldReturnSingleDocument()
        {
            // Arrange
            string name = "Bilbo";
            TestModel expected = new TestModel { Name = name, Age = 99 };

            // Act
            TestModel actual = collection.Find(t => t.Name == name).FirstOrDefault();

            // Assert
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Age, actual.Age);
            Assert.NotNull(actual.Id);
        }
    }
}
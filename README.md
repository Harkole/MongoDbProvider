# MongoDbProvider
Wrapper for the C# MongoDB Driver to provide easier methods of generating a context to work with, in addition to providing automation around Collection names

# Usage
- Reference the project in your existing project
- `MongoDbProvider.Interfaces.IDatabaseOptions` is given to provide a template for the connection details
- Call the Context<T> as shown below:

```csharp
    using MongoDbProvider.Interfaces;
    using MongoDB.Driver;

    // ...

    private readonly IMongoCollection<Model> collection;
    
    // Ctor (IDatabaseOptions options)
    {
        collection = new ContextProvider<Model>(options).Context;
    }

    // ...
    // Method - InsertOne(Model model)
    {
        // Validation and other logic etc.
        await collection.InsertOneAsync(model);
    }
```

The CollectionName will be a pluralized version of the `<T>` model, eg. given `<T>` is a `class TestModel` then the collection name would appear as _TestModels_

For a working example of implementation see the included Tests code

# Dependencies
- MongoDB.Driver
- PluralizeService.Core

# Authors
Will Blackburn - [Harkole](https://github.com/harkole)

using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rissole.Mongo
{
    public class MongoContext
    {
        private IMongoDatabase _database;

        public MongoContext(MongoOptions options)
        {
            _database = new MongoClient(options.MongoClientSettings).GetDatabase(options.Database);
        }

        public IMongoDatabase Database => _database;
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Rissole.Mongo.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    [MongoCollection("demo")]
    public class DemoModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Name { get; set; }
    }
}

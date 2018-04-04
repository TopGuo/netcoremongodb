using Rissole.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo
{
    public class DemoMongoContext : MongoContext
    {
        public DemoMongoContext(MongoOptions options) : base(options)
        {
        }
    }
}

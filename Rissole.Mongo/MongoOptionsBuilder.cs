using System;
using System.Collections.Generic;
using System.Text;

namespace Rissole.Mongo
{
    public class MongoOptionsBuilder
    {
        private MongoOptions _options;

        public MongoOptionsBuilder()
        {
            _options = new MongoOptions();
        }

        public MongoOptionsBuilder(Action<MongoOptionsBuilder> optionsAction) : this()
        {
            optionsAction(this);
        }

        public MongoOptions Options => _options;

        public void UseMongo(string connectionString)
        {
            _options = new MongoOptions(connectionString);
        }
    }
}

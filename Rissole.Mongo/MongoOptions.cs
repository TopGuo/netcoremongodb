using MongoDB.Driver;
using Rissole.Mongo.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rissole.Mongo
{
    public class MongoOptions
    {
        private Dictionary<string, string> _options;

        public MongoOptions()
        {
            MongoClientSettings = new MongoClientSettings();

        }

        public MongoOptions(string connectionString) : this()
        {
            _options = GenerateOptions(connectionString);

            MongoClientSettings.Server = GenerateMongoServerAddress(_options);
        }

        public string Host
        {
            get => _options[MongoOptionConstants.Host];
            set
            {
                _options[MongoOptionConstants.Host] = value;
                MongoClientSettings.Server = GenerateMongoServerAddress(_options);
            }
        }

        public int Port
        {
            get => int.Parse(_options[MongoOptionConstants.Port]);
            set
            {
                _options[MongoOptionConstants.Port] = value.ToString();
                MongoClientSettings.Server = GenerateMongoServerAddress(_options);
            }
        }

        public string Database
        {
            get => _options[MongoOptionConstants.Database];
            set
            {
                _options[MongoOptionConstants.Database] = value;
            }
        }

        public MongoClientSettings MongoClientSettings { get; private set; }

        private Dictionary<string, string> GenerateOptions(string connectionString)
        {
            var options = new Dictionary<string, string>();

            foreach (var setting in connectionString.Split(';'))
            {
                var elements = setting.Split('=');
                var name = elements[0].Trim();
                var value = elements.Length > 1 ? elements[1].Trim() : "";

                var settingName = MongoOptionConstants.Settings.FirstOrDefault(x => x.Equals(name, StringComparison.CurrentCultureIgnoreCase));

                if (settingName == null) continue;

                options[settingName] = value;
            }

            return options;
        }

        private MongoServerAddress GenerateMongoServerAddress(Dictionary<string, string> options)
        {
            if (!options.ContainsKey(MongoOptionConstants.Host))
                throw new Exception("Mongo Options: Host is required");

            if (!options.ContainsKey(MongoOptionConstants.Port))
                return new MongoServerAddress(options[MongoOptionConstants.Host]);

            return new MongoServerAddress(options[MongoOptionConstants.Host], int.Parse(options[MongoOptionConstants.Port]));
        }
    }
}

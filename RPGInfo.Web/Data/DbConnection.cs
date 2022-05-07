using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Data
{
    public class DbConnection : IDbConnection
    {
        private readonly IConfiguration _config;
        private readonly IMongoDatabase _db;
        private string _connectionId = "MongoDB";

        public string DbName { get; private set; }
        // collection example public string CategoryCollectionName { get; private set; } = "categories"; 
        //  public IMongoCollection<CategoryModel> CategoryCollection { get; private set; }
        public MongoClient Client { get; private set; }

        public DbConnection(IConfiguration config)
        {
            _config = config;
            Client = new MongoClient(_config.GetConnectionString(_connectionId));
            DbName = _config["DatabaseName"];
            _db = Client.GetDatabase(DbName);

          // collection example  CategoryCollection = _db.GetCollection<CategoryModel>(CategoryCollectionName);
        }

    }
}

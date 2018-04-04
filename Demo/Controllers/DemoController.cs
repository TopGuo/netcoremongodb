using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Rissole.Mongo;

namespace Demo.Controllers
{
    [Produces("application/json")]
    [Route("api/Demo")]
    public class DemoController : Controller
    {
        private DemoMongoContext _context;
        private IBaseMongoCollection<DemoModel> _demoCollection;

        public DemoController(DemoMongoContext context)
        {
            _context = context;
            _demoCollection = new BaseMongoCollection<DemoModel>(_context);
        }

        [HttpGet]
        public IEnumerable<DemoModel> Get()
        {
            return _demoCollection.Queryable.Where(x => x.Id == ObjectId.Parse("123")).ToList();
        }

        //[HttpGet]
        //public async Task Get([FromBody]DemoModel model)
        //{
        //    await _demoCollection.InsertOneAsync(model);
        //}

        //[HttpPost]
        public async Task InsertPost([FromBody]DemoModel model)
        {
            await _demoCollection.InsertOneAsync(model);
        }

        [HttpPut("{id}")]
        public async Task PutAsync(string id, [FromBody]DemoModel model)
        {
            await _demoCollection.ReplaceOneAsync(x => x.Id == ObjectId.Parse(id), model);
        }
    }
}
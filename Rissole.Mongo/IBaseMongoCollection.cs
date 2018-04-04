using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Rissole.Mongo
{
    public interface IBaseMongoCollection<TDocument> where TDocument : class
    {
        IMongoCollection<TDocument> Collection { get; }

        IMongoQueryable<TDocument> Queryable { get; }

        Task InsertOneAsync(TDocument document);

        Task InsertManyAsync(IEnumerable<TDocument> documents);

        Task<IAsyncCursor<TDocument>> FindAsync(Expression<Func<TDocument, bool>> predicate,
            FindOptions<TDocument, TDocument> options = null, CancellationToken cancellationToken = default(CancellationToken));

        Task ReplaceOneAsync(Expression<Func<TDocument, bool>> predicate, TDocument document, UpdateOptions options = null, CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteOneAsync(Expression<Func<TDocument, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken));
    }
}

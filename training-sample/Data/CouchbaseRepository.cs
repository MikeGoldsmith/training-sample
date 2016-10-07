using System;
using System.Collections.Generic;
using Couchbase;
using Couchbase.Core;
using Couchbase.N1QL;

namespace training_sample.Data
{
    public class CouchbaseRepository<T> : IRepository<T>
        where T : class
    {
        // Could use DI instead of using ClusterHelper
        private readonly IBucket _bucket = ClusterHelper.GetBucket("default");

        private static string CreateKey(string id)
        {
            // generates key like 'customer::123'
            //return string.Format("{0}::{1}", typeof(T).Name, id);
            return id;
        }

        public T Get(string id)
        {
            var key = CreateKey(id);
            var result = _bucket.Get<T>(key);
            if (!result.Success)
            {
                // deal with error
                return null;
            }

            return result.Value;
        }

        public IEnumerable<T> GetAll()
        {
            var query = new QueryRequest("SELECT * FROM customer360 WHERE type = $1")
                .AddPositionalParameter(typeof(T).Name);

            var result = _bucket.Query<T>(query);
            if (!result.Success)
            {
                // error
                return null;
            }

            return result.Rows;
        }

        public T Create(string id, T item)
        {
            var key = CreateKey(id);
            var result = _bucket.Insert(key, item);
            if (!result.Success)
            {
                throw result.Exception;
            }

            return item;
        }

        public T Update(string id, T item)
        {
            var key = CreateKey(id);
            var result = _bucket.Replace(key, item);
            //var result = _bucket.Upsert(key, item);
            if (!result.Success)
            {
                throw result.Exception;
            }

            return item;
        }

        public T Delete(string id)
        {
            var key = CreateKey(id);
            var item = _bucket.Get<T>(key);
            if (item == null)
            {
                // didn't exist
                return null;
            }

            var result = _bucket.Remove(id);
            if (!result.Success)
            {
                throw result.Exception;
            }

            return item.Value;
        }

        public string NextId()
        {
            const string customerCounterKey = "customer::counter";
            var result = _bucket.Increment(customerCounterKey, 1, 1);

            return result.ToString();
        }
    }
}
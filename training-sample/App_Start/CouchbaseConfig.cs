using System;
using System.Collections.Generic;
using Couchbase;
using Couchbase.Configuration.Client;

namespace training_sample
{
    public static class CouchbaseConfig
    {
        public static void Setup()
        {
            var config = new ClientConfiguration
            {
                Servers = new List<Uri> {new Uri("couchbase://19.168.1.104")}
            };
            ClusterHelper.Initialize(config);
        }

        public static void CleanUp()
        {
            ClusterHelper.Close();
        }
    }
}
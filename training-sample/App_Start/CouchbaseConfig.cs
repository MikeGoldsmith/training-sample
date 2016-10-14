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
                Servers = new List<Uri> {new Uri("couchbase://192.168.1.104")}
            };
            ClusterHelper.Initialize(config);

            // force connection to open
            ClusterHelper.Get().OpenBucket("default");
        }

        public static void CleanUp()
        {
            ClusterHelper.Close();
        }
    }
}
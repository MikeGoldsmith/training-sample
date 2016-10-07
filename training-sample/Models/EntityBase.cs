using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace training_sample.Models
{
    public class EntityBase<T>
    {
        public string Id { get; set; }

        public string Type
        {
            get { return typeof(T).Name; }
        }
    }
}
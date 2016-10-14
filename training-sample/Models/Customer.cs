using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;

namespace training_sample.Models
{
    public class Customer : EntityBase<Customer>
    {
        // JsonProperty("first_name")] can override serialization property name
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
    }
}
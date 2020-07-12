using System;
using System.ComponentModel.DataAnnotations;

namespace server.DataModel
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public string Gender{get;set;}
        public string Country{get;set;}
        public DateTime Saledate{get;set;}

    }
}
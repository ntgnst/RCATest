using System;
using System.Collections.Generic;

namespace RCA.Data.Models
{
    public partial class Cafe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string OwnerId { get; set; }
        public DateTime? RegisterDate { get; set; }
        public DateTime? LicenceStartDate { get; set; }
        public DateTime? LicenceEndDate { get; set; }
        public string AppKey { get; set; }
        public string AppSecret { get; set; }
        public string FacebookId { get; set; }
        public string TwitterId { get; set; }

        public AspNetUsers Owner { get; set; }
    }
}

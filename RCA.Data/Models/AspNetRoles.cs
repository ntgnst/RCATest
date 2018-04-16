using System;
using System.Collections.Generic;

namespace RCA.Data.Models
{
    public partial class AspNetRoles
    {
        public string Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
    }
}

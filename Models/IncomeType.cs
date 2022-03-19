﻿using System;
using System.Collections.Generic;

#nullable disable

namespace InsaatAPINet.Models
{
    public partial class IncomeType
    {
        public IncomeType()
        {
            Customers = new HashSet<Customer>();
        }

        public int IncomeTypeId { get; set; }
        public string IncomeTypeName { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}

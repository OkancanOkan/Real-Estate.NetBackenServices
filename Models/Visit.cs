using System;
using System.Collections.Generic;

#nullable disable

namespace InsaatAPINet.Models
{
    public partial class Visit
    {
        public int VisitId { get; set; }
        public DateTime? VisitDate { get; set; }
        public int? CustomerId { get; set; }
        public int? ProjectId { get; set; }
        public string Notes { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Project Project { get; set; }
    }
}

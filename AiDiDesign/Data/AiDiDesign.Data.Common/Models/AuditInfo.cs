﻿namespace AiDiDesign.Data.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AuditInfo : IAuditInfo
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// Specifies whether or not the CreatedOn property should be automatically set.
        /// </summary>
        [NotMapped]
        public bool PreserveCreatedOn { get; set; }

        public bool IsHidden { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnmerCore.DataObjects
{
    [Table("LoggingSources")]
    public class LoggingSource
    {
        [Key]
        public long LoggingSourceID { get; set; }

        [StringLength(50)]
        public string Code
        {
            get;
            set;
        }

        [StringLength(255)]
        public string Name
        {
            get;set;
        }

        public string Description
        {
            get;
            set;
        }

        public DateTime DateCreated
        {
            get;
            set;
        }

        [StringLength(128), ForeignKey("UserProfile")]
        public string UserAdded
        {
            get;
            set;
        }

        [StringLength(500)]
        public string SiteLink
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

    }
}

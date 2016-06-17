using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnmerWeb.Models
{
    public class LoggingSourceModel
    {
        public long ID { get; set; }

        public string Code
        {
            get;
            set;
        }

        public string Name
        {
            get; set;
        }

        public string Description
        {
            get;
            set;
        }


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
    }
}
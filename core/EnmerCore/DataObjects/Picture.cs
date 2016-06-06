using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnmerCore.DataObjects
{
    [Table("Picture")]
    public class Picture
    {
        [Key]
        public string PictureID { get; set; }

        [Column(TypeName = "Image")]
        public byte[] Data
        {
            get;
            set;
        }
    }
}

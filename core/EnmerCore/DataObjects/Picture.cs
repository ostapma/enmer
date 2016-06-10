using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnmerCore.DataObjects
{
    [Table("Pictures")]
    public class Picture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string PictureID { get; set; }

        [Column(TypeName = "Image")]
        public byte[] Data
        {
            get;
            set;
        }
    }
}

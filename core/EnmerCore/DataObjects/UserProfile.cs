using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnmerCore.DataObjects
{


    [Table("UserProfile")]
    public partial class UserProfile
    {
        [Key]
        public string UserID { get; set; }

        [StringLength(50), ForeignKey("Picture")]
        public string PictureID { get; set; }

        public Picture Picture
        {
            get;
            set;
        }

        [StringLength(1024)]
        public string FirstName { get; set; }

        [StringLength(1024)]
        public string LastName { get; set; }
    }
}

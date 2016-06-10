using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnmerCore.DataObjects;

namespace EnmerCore.BL
{
    public class PictureManager
    {
        public Picture GetPicture(string pictureID)
        {
            using (var context = new EnmerDbContext())
            {
                return context.Pictures.Find(pictureID);
            }
           
        }

        public string AddPicture(byte[] data)
        {
            using (var context = new EnmerDbContext())
            {
                    var picture = new Picture()
                    {
                        Data = data
                    };
                    context.Pictures.Add(picture);
                    context.SaveChanges();
                    return picture.PictureID;
            }
        }

        internal void DeletePicture(string pictureID, EnmerDbContext context)
        {
            context.Pictures.Remove(context.Pictures.Find(pictureID));
        }
    }
}

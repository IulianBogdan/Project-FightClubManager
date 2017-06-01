using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace FinalProject
{
    static class ToolsForDataSet
    {

        public static byte[] TransformImageDataToArray(byte[] array, string imPath)
        {
            try
            {
                if (imPath != "")
                {
                    FileStream fs = new FileStream(imPath, FileMode.Open, FileAccess.Read);
                    array = new byte[fs.Length];
                    fs.Read(array, 0, Convert.ToInt32(fs.Length));
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return array;

        }


        public static BitmapImage FromByteToImage(byte[] array)
        {
            if (array == null || array.Length == 0)
            {
                return null;
            }
            else
            {
                var image = new BitmapImage();
                using (var mem = new MemoryStream(array))
                {
                    mem.Position = 0;
                    image.BeginInit();
                    image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = null;
                    image.StreamSource = mem;
                    image.EndInit();
                }
                image.Freeze();
                return image;

            }
        }

        public static BitmapImage CreatePictureForSelectedMember(int id, DataSet dsForPicture)
        {
            BitmapImage imageFromDB = new BitmapImage();
            byte[] imageArrayFromDS;

            foreach (DataTable table in dsForPicture.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    int memberIdFromRow = Convert.ToInt32(row["MemberID"]);
                    if (id == memberIdFromRow)
                    {
                        imageArrayFromDS = (byte[])row["MemberPicture"];
                        imageFromDB = FromByteToImage(imageArrayFromDS);
                    }
                }
            }
            return imageFromDB;
        }

        //public void DeleteMemberFromSelection(int idvalue, DataSet ds)
        //{
        //    DatabaseAccess dba = new DatabaseAccess(); 
        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        int value = Convert.ToInt32(ds.Tables[0].Rows[i]["MemberID"]);
        //        if (value == idvalue)
        //        {
        //            dba.DeleteMemberFromDB(value);
        //            ds.Tables[0].Rows[i].Delete();
        //        }
        //    }

        //} //The purpose of this method was to delete the selected record from the DataSet in accordance with the repository pattern.


    }
}

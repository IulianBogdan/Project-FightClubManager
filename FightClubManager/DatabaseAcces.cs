using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;


namespace FinalProject
{
    public static class DatabaseAccess
    {
        private static SqlConnection GetConnection()
        {
            string conString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            return conn;
        }

        public static DataSet MemberDataSet(DataSet ds)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("RetrieveMembers", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
            }
            return ds;
        }

        public static void DeleteMemberFromDB(int value)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("RemoveMemberFromDB", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MemberID", value);
                cmd.ExecuteNonQuery();
            }
        }
        public static void AddMemberToDb(Member obj)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("AddMemberToDB", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FirstName", obj.FirstName));
                cmd.Parameters.Add(new SqlParameter("@LastName", obj.LastName));
                cmd.Parameters.Add(new SqlParameter("@Nickname", obj.Nickname));
                cmd.Parameters.Add(new SqlParameter("@Weight", obj.Weight));
                cmd.Parameters.Add(new SqlParameter("@Age", obj.Age));
                cmd.Parameters.Add(new SqlParameter("@PhoneNumber", obj.PhoneNumber));
                cmd.Parameters.Add(new SqlParameter("@Email", obj.Email));
                cmd.Parameters.Add(new SqlParameter("@Nationality", obj.Nationality));
                cmd.Parameters.Add(new SqlParameter("@DateOfBirth", obj.DateOfBirth));
                cmd.Parameters.Add(new SqlParameter("@Status", obj.Status));
                cmd.Parameters.Add(new SqlParameter("@Adress", obj.Adress));
                cmd.Parameters.Add(new SqlParameter("@AmateurWins", obj.AmateurWins));
                cmd.Parameters.Add(new SqlParameter("@AmateurLosses", obj.AmateurLosses));
                cmd.Parameters.Add(new SqlParameter("@AmateurDraws", obj.AmateurDraws));
                cmd.Parameters.Add(new SqlParameter("@ProfessionalWins", obj.ProfessionalWins));
                cmd.Parameters.Add(new SqlParameter("@ProfessionalLosses", obj.ProfessionalLosses));
                cmd.Parameters.Add(new SqlParameter("@ProfessionalDraws", obj.ProfessionalDraws));
                cmd.Parameters.Add(new SqlParameter("@MemberPicture", obj.MemberImage));
                cmd.Parameters.Add(new SqlParameter("@PictureName", obj.FirstName + " " + obj.LastName));
                cmd.ExecuteNonQuery();
            }

        }
        //public static void RetrievePictureForSelection(int ID, DataSet ds)
        //{
        //    using(SqlConnection connection = GetConnection())
        //    {
        //        SqlCommand cmd = new SqlCommand("RetrievePictures", connection);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("MemberID", ID);
        //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //        sda.Fill(ds);
        //        cmd.ExecuteNonQuery();
        //    }
        //}
        public static DataSet RetrievePictures(DataSet ds)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("RetrieveAllPictures", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                cmd.ExecuteNonQuery();
            }
            return ds;
        }
    }
}
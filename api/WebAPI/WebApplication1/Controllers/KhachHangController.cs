using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;


namespace WebApplication1.Controllers
{
    public class KhachHangController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    select 
                     UserId, UserName, LoginName, Password, Email, ContactNo, isApporved
                    from dbo.KhachHang
                    ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["myProject"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);


        }

        public string Post(KhachHang kh)
        {
            try
            {
                string query = @"
                    insert into dbo.KhachHang values
                    (
                    '" + kh.UserName + @"'
                    ,'" + kh.LoginName + @"'
                    ,'" + kh.Password + @"'
                    ,'" + kh.Email + @"'
                    ,'" + kh.ContactNo + @"'
                   

                    )
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["myProject"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Add!!";
            }
        }


        public string Put(KhachHang kh)
        {
            try
            {
                string query = @"
                    update dbo.KhachHang set 
                    UserName ='" + kh.UserName + @"'
                    ,LoginName='" + kh.LoginName + @"'
                    ,Password ='" + kh.Password + @"'
                    ,Email ='" + kh.Email + @"'
                    ,ContactNo ='" + kh.ContactNo + @"'
                    where UserId=" + kh.UserId + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["myProject"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Update!!";
            }
        }


        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete from dbo.KhachHang 
                    where UserId=" + id + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["myProject"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Delete!!";
            }
        }
    }
}

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
    public class PhimController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    select MaPhim, TenPhim, Trailer, HinhAnh, NoiDung, Slogan, ThoiLuong
                    from
                    dbo.Phim
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

        public string Post(Phim p)
        {
            try
            {
                string query = @"
                    insert into dbo.Phim values
                    (
                    '" + p.TenPhim + @"'
                    ,'" + p.Trailer + @"'
                    ,'" + p.HinhAnh + @"'
                    ,'" + p.NoiDung + @"'
                    ,'" + p.Slogan + @"'
                    ,'" + p.ThoiLuong + @"'
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


        public string Put(Phim p)
        {
            try
            {
                string query = @"
                    update dbo.Phim set 
                    TenPhim ='" + p.TenPhim + @"'
                    ,Trailer='" + p.Trailer + @"'
                    ,HinhAnh ='" + p.HinhAnh + @"'
                    ,NoiDung ='" + p.NoiDung + @"'
                    ,Slogan ='" + p.Slogan + @"'
                    ,ThoiLuong ='" + p.ThoiLuong + @"'
                    where MaPhim=" + p.MaPhim + @"
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
                    delete from dbo.Phim 
                    where MaPhim=" + id + @"
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

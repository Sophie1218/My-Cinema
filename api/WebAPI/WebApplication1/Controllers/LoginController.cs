using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class LoginController : ApiController
    {
        //For user login   
        [Route("Api/Login/UserLogin")]
        [HttpPost]
        public Response Login(Login Lg)
        {
            LoginEntities DB = new LoginEntities();
            var Obj = DB.Usp_Login(Lg.LoginName, Lg.Password).ToList<Usp_Login_Result>().FirstOrDefault();
            if (Obj.IsApporved == 1)
            //    return new Response { Status = "Invalid", Message = "Invalid User." };
            //if (Obj.Status == -1)
            //    return new Response { Status = "Inactive", Message = "User Inactive." };
            //else
            return new Response { Status = "Success", Message = Lg.LoginName };
            else
                return new Response { Status = "False", Message = Lg.LoginName };
        }   
        //For new user Registration  
        [Route("Api/Login/UserRegistration")]
        [HttpPost]
        public object createcontact(Registration Lvm)
        {
            try
            {
                LoginEntities db = new LoginEntities();
                KhachHang Em = new KhachHang();
                if (Em.UserId == 0)
                {
                    Em.UserName = Lvm.UserName;
                    Em.LoginName = Lvm.LoginName;
                    Em.Password = Lvm.Password;
                    Em.Email = Lvm.Email;
                    Em.ContactNo = Lvm.ContactNo;
                    Em.IsApporved = Lvm.IsApporved;
                    db.KhachHangs.Add(Em);
                    db.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "SuccessFully Saved." };
                }
            }
            catch (Exception)
            {
                throw;
            }
            return new Response
            { Status = "Error", Message = "Invalid Data." };
        }
    }
}

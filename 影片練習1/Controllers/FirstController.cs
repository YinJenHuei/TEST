using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 影片練習1.Models;

namespace 影片練習1.Controllers
{
    public class FirstController : Controller
    {
        private List<CurrentUser> UserList = new List<CurrentUser>()
        {
            new CurrentUser()
            {
                Id = 1,
                Name = "Z",
                Account = "adimin1",
                Email = "123456@gmail.com",
                LoginTime = DateTime.Now,
                Password = "123456"
            },
            new CurrentUser()
            {
            Id = 2,
            Name = "小白",
            Account = "adimin2",
            Email = "123456@gmail.com",
            LoginTime = DateTime.Now,
            Password = "123456"
        },
        new CurrentUser()
        {
            Id = 3,
            Name = "小皮",
            Account = "adimin3",
            Email = "123456@gmail.com",
            LoginTime = DateTime.Now,
            Password = "123456"
        }
    };
        //ActionResult/ViewResult,都是返回view()
        // GET: First
        public ActionResult Index(int id =3)//默認參數
        {
            
            var currentUser = this.UserList.FirstOrDefault(u => u.Id == id)
                ?? this.UserList[0];
            ViewData["CurrentUserViewData"] = this.UserList[0];
            ViewBag.CurrentUserViewDataViewBag = this.UserList[1];

            ViewData["TestProp"] = "cx";//viewdata與viewbag是會蓋過去的,以後者為準
            ViewBag.TestProp = "Tank";
            TempData["TestProp"] = "spider"; //一次性的,並且是獨立存儲
            return View(this.UserList[2]);
        }

        public ActionResult Index1()
        {
            return View();
        }

        /// <summary>
        /// First/Index/id(1) id是路由解析出來的
        /// First/Index?id=3  url地址傳遞參數
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ViewResult IndexId(int id)
        {
            return View();
        }

        public ViewResult IndexIdNull(int? id)
        {
            return View(@"~/Views/First/index1.cshtml");
        }

        /// <summary>
        /// string name 沒有傳遞name,一樣可以開啟,因為string可以為空
        /// https://localhost:44396/First/stringname/123 不行為name,顯示不出來,因為rount有說最後/Id
        /// https://localhost:44396/First/stringname?name=小白 可以為name
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string StringName(string name)
        {
            return $"This is {name}";
        }

        public string StringJson(string name)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                id = 123,
                name = name
            });
        }
        /// <summary>
        /// https://localhost:44396/first/Json/3?name=%E5%B0%8F%E7%99%BD&remark=123
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public JsonResult Json(int id,string name,string remark)
        {
            return new JsonResult()
            {
                Data = new
                {
                    Id = id,
                    Name = name ?? "x",
                    Remark = remark ?? "這裡是默認的"
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet//允許get
                
                
            };
        }


        //public FilePathResult FileResult()
        //{
        //    return File(@"C:\Users\tiwwy\Desktop\快捷鍵.txt", "");
        //}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private NodeContext db = new NodeContext();
        // GET: Home
        public ActionResult Index()
        {
            List<string> dataDB = new List<string>();

            
            foreach (var item in db.Nodes.ToList())
            {
                dataDB.Add(Reverse(item.Sentence));
            }
            return View(dataDB);
        }

        public string Reverse(string input)
        {
            string[] words = input.Split();
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = new string(words[i].Reverse().ToArray());
            }
            return string.Join(" ", words);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, string keyWord)
        {
            if (file != null)
                try
                {
                    using (StreamReader read = new StreamReader(file.InputStream))
                    {
                        var line = read.ReadToEnd().Split('.');
                        foreach (var item in line)
                        {
                            if (item.Contains(" "+keyWord+ " "))
                            {
                                db.Nodes.Add(new Node(Reverse(item)));
                                db.SaveChanges();
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "Ви не вибрали файл!";
            }

            List<string> dataDB = new List<string>();

            foreach (var item in db.Nodes.ToList())
            {
                dataDB.Add(Reverse(item.Sentence));
            }
            return View(dataDB);
        }
    }
}
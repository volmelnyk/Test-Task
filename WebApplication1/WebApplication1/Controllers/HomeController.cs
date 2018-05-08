using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;

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
                    var fileName = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/Content/"), fileName);
                    file.SaveAs(path);
                    using (StreamReader read = new StreamReader(path))
                    {
                        var line = read.ReadToEnd().Split('.');
                        foreach (var item in line)
                        {
                            if (item.Contains(keyWord))
                            {
                                db.Nodes.Add(new Node(Reverse(item)));
                                db.SaveChanges();
                            }
                        }

                    }
            System.IO.File.Delete(path);



            List<string> dataDB = new List<string>();

            foreach (var item in db.Nodes.ToList())
            {
                dataDB.Add(Reverse(item.Sentence));
            }
            return View(dataDB);
        }
    }
}
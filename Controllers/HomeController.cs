using Musicalog_App.Models;
using System.Web.Mvc;
using System;
using PagedList;

namespace Musicalog_App
{
    public class HomeController : Controller
    {
        ServiceReference1.Albumdetail albumdetail = new ServiceReference1.Albumdetail();
        public ActionResult Index(string Sorting_Order, string Filter_Value, int? Page_No)
        {
            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "AlbumName" : "";
            var albumlist = from stu in db.albumdetail select stu;
            switch (Sorting_Order)
            {
                case "AlbumName":
                    albumlist = albumlist.OrderByDescending(stu => stu.AlbumName);
                    break;
                case "Artist":
                    albumlist = albumlist.OrderByDescending(stu => stu.Artist);
                    break;
                case "Type":
                    albumlist = albumlist.OrderByDescending(stu => stu.Type);
                    break;
                case "Stock":
                    albumlist = albumlist.OrderByDescending(stu => stu.Stock);
                    break;
                default:
                    albumlist = albumlist.OrderBy(stu => stu.AlbumName);
                    break;
            }

            int Size_Of_Page = 4;
            int No_Of_Page = (Page_No ?? 1);
            return View(albumdetail.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AlbumModel mdl)
        {
            AlbumModel mv = new AlbumModel();
            mv.Albumid = mdl.Albumid;
            mv.AlbumName = mdl.AlbumName;
            mv.Artist = mdl.Artist;
            mv.Type = mdl.Type;
            mv.Stock = (int)mdl.Stock;
            albumdetail.AddAlbum(mv.AlbumName, mv.Artist, mv.Type, mv.Stock);
            return RedirectToAction("Index", "Movies");

        }

        public ActionResult Delete(int id)
        {
            int retval = albumdetail.DeleteAlbumById(id);
            if (retval > 0)
            {
                return RedirectToAction("Index", "Movies");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var lst = albumdetail.GetAllMovieById(id);
            AlbumModel mv = new AlbumModel();
            mv.Albumid = lst.Albumid;
            mv.AlbumName = lst.AlbumName;
            mv.Artist = lst.Artist;
            mv.Type = lst.Type;
            mv.Stock = (int)lst.Stock;

            if (mv == null)
            {
                return HttpNotFound();
            }
            return View(mv);

        }

        [HttpPost]
        public ActionResult Edit(AlbumModel mdl)
        {
            AlbumModel mv = new AlbumModel();
            mv.Albumid = mdl.Albumid;
            mv.AlbumName = mdl.AlbumName;
            mv.Artist = mdl.Artist;
            mv.Type = mdl.Type;
            mv.Stock = (int)mdl.Stock;

            int Retval = albumdetail.UpdateAlbum(mv.AlbumName, mv.Artist, mv.Type, mv.Stock);
            if (Retval > 0)
            {
                return RedirectToAction("Index", "Movies");
            }

            return View();
        }
    }
}
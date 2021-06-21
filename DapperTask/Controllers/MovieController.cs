using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using DapperTask.Models;

namespace DapperTask.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            List<MovieModel> MVlist = new List<MovieModel>();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MVConStr"].ConnectionString))
            {
                MVlist = dbcon.Query<MovieModel>("select * from Movies").ToList();
            }
            return View(MVlist);
        }

        public ActionResult Details(int id)
        {
            MovieModel bk = new MovieModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MVConStr"].ConnectionString))
            {
                bk = dbcon.Query<MovieModel>("select * from Movies where No =" +id, new { id}).SingleOrDefault();
            }
            return View(bk);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MovieModel bmodel)
        {
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MVConStr"].ConnectionString))
            {
                string sqlQry = "Insert into Movies(MovieName) Values('" + bmodel.MovieName + "')";
                int rowins = dbcon.Execute(sqlQry);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            MovieModel bk = new MovieModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MVConStr"].ConnectionString))
            {
                bk = dbcon.Query<MovieModel>("select * from Movies where No =" + id, new { id }).SingleOrDefault();
            }
            return View(bk);
        }

        [HttpPost]
        public ActionResult Edit(int id,MovieModel mm)
        {
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MVConStr"].ConnectionString))
            {
                mm = dbcon.Query<MovieModel>("update Movies set MovieName='" + mm.MovieName + "' where No=" + id).SingleOrDefault();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            MovieModel bk = new MovieModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MVConStr"].ConnectionString))
            {
                bk = dbcon.Query<MovieModel>("select * from Movies where No =" + id, new { id }).SingleOrDefault();
            }
            return View(bk);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            MovieModel bk = new MovieModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MVConStr"].ConnectionString))
            {
                bk = dbcon.Query<MovieModel>("delete from Movies where No =" + id, new { id }).SingleOrDefault();
            }
            return RedirectToAction("Index");
        }
    }
}
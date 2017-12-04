using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarInsuranceClaim.Models;
using System.IO;

namespace CarInsuranceClaim.Controllers
{
    public class HomeController : Controller
    {

        DB aConn = new DB();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //
        public ActionResult AddAccidentForm()
        {

            return View();
        }
        //
        
        [HttpPost]
        public ActionResult ConfirmResults(string id, string Des, string claimRepairOneD, decimal claimRepairOneE, string claimRepairTwoD, decimal claimRepairTwoE, string involedPolicyNumber, string involedLicensePlate, string seceneLocation, string claimDate, string claimTime, HttpPostedFileBase file)
        {
            

            if (file != null)
            {
                string path = Path.Combine(Server.MapPath("~/Content/Images"), Path.GetFileName(file.FileName));
                file.SaveAs(path);
            }
            var claimIMG = Path.GetFileName(file.FileName);

            //Claim info
            ViewBag.Date = claimDate;
            ViewBag.Des = Des;
            ViewBag.Secene = seceneLocation;

            //people involed information
            ViewBag.PolicyNumber = involedPolicyNumber;
            ViewBag.PolicyPlate = involedLicensePlate;

            //repair shop information
            ViewBag.ShopOneD = claimRepairOneD;
            ViewBag.ShopOneE = claimRepairOneE;
            ViewBag.ShopTwoD = claimRepairTwoD;
            ViewBag.ShopTwoE = claimRepairTwoE;

            //image 
            ViewBag.Img = claimIMG;


            bool claimStats = false;
            aConn.addClaim(id, Des, claimRepairOneD, claimRepairOneE, claimRepairTwoD, claimRepairTwoE, claimIMG, involedPolicyNumber, involedLicensePlate, seceneLocation, claimDate, claimTime, claimStats);
            return View();
        }

        //selection view
        public ActionResult Selection()
        {

            return View();
        }

        public ActionResult SelectionBasic()
        {

            return View();
        }

        public ActionResult ClaimHistory()
        {
            List<claim> aListOfClaims = new List<claim>();
            aListOfClaims = aConn.ViewAllClaimHistory();

            ViewBag.History = aListOfClaims;

            return View();
        }

        public ActionResult MyClaimHistory(string id)
        {
            List<claim> aListOfClaims = new List<claim>();
            aListOfClaims = aConn.ViewYourClaimHistory(id);

            ViewBag.History = aListOfClaims;

            return View();
        }


        
    }
}
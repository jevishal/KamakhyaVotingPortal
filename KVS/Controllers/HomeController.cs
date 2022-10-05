using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KVS.Models;

namespace KVS.Controllers
{
  
    public class HomeController : Controller
    {
        DemoSSISEntities demoSSISEntities = new DemoSSISEntities();
        [HttpGet]
        public ActionResult Index()
        {

            return View();
           
        }

        [HttpGet]
        public ActionResult Ins()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Result()
        {
            List<VoteResult> customVotes = new List<VoteResult>();
            var listofData = demoSSISEntities.Vote_Sept22.ToList();
            // return View(listofData);
            
            var AGRAZ_SHARMA_A17Count = demoSSISEntities.Vote_Sept22.Count(c => c.AGRAZ_SHARMA_A17 == true);
            var ASHISH_GUPTA_A27Count = demoSSISEntities.Vote_Sept22.Count(c => c.ASHISH_GUPTA_A27 == true);
            var MOHSIN_KHAN_A3Count = demoSSISEntities.Vote_Sept22.Count(c => c.MOHSIN_KHAN_A3 == true);
            var PARWESH_RANJAN_DEEPAK_B13_14Count = demoSSISEntities.Vote_Sept22.Count(c => c.PARWESH_RANJAN_DEEPAK_B13_14 == true);
            var RAM_KUMAR_B26Count = demoSSISEntities.Vote_Sept22.Count(c => c.RAM_KUMAR_B26 == true);
            var DHEERAJ_MISHRA_B21Count = demoSSISEntities.Vote_Sept22.Count(c => c.DHEERAJ_MISHRA_B21 == true);
            var ASHISH_TRIPATHI_C29Count = demoSSISEntities.Vote_Sept22.Count(c => c.ASHISH_TRIPATHI_C29 == true);
            var TARUN_KUMAR_C31Count = demoSSISEntities.Vote_Sept22.Count(c => c.TARUN_KUMAR_C31 == true);
          
           
            foreach (var v in listofData)
            {
                VoteResult customVote = new VoteResult();
                customVote.AGRAZ_SHARMA_A17= v.AGRAZ_SHARMA_A17 == true ? "Yes" : "No" ;
                customVote.ASHISH_GUPTA_A27 = v.ASHISH_GUPTA_A27 == true ? "Yes" : "No";
                customVote.MOHSIN_KHAN_A3 = v.MOHSIN_KHAN_A3 == true ? "Yes" : "No";
                customVote.PARWESH_RANJAN_DEEPAK_B13_14 = v.PARWESH_RANJAN_DEEPAK_B13_14 == true ? "Yes" : "No";
                customVote.RAM_KUMAR_B26 = v.RAM_KUMAR_B26 == true ? "Yes" : "No";
                customVote.DHEERAJ_MISHRA_B21 = v.DHEERAJ_MISHRA_B21 == true ? "Yes" : "No";
                customVote.ASHISH_TRIPATHI_C29 = v.ASHISH_TRIPATHI_C29 == true ? "Yes" : "No";
                customVote.TARUN_KUMAR_C31 = v.TARUN_KUMAR_C31 == true ? "Yes" : "No";
               
                customVote.Token = v.Token;
                customVotes.Add(customVote);
            }
            VoteResult customVote1 = new VoteResult();
            customVote1.AGRAZ_SHARMA_A17 = AGRAZ_SHARMA_A17Count.ToString() +"-"+"A17";
            customVote1.ASHISH_GUPTA_A27 = ASHISH_GUPTA_A27Count.ToString() +"-"+"A27";
            customVote1.MOHSIN_KHAN_A3 = MOHSIN_KHAN_A3Count.ToString() + "-" + "A3";
            customVote1.PARWESH_RANJAN_DEEPAK_B13_14 = PARWESH_RANJAN_DEEPAK_B13_14Count.ToString() + "-" + "B13/14";
            customVote1.RAM_KUMAR_B26 = RAM_KUMAR_B26Count.ToString() + "-" + "B26";
            customVote1.DHEERAJ_MISHRA_B21 = DHEERAJ_MISHRA_B21Count.ToString() + "-" + "B21";
            customVote1.ASHISH_TRIPATHI_C29 = ASHISH_TRIPATHI_C29Count.ToString() + "-" + "C29";
            customVote1.TARUN_KUMAR_C31 = TARUN_KUMAR_C31Count.ToString() + "-" + "C31";
           
            customVotes.Add(customVote1);
            return View(customVotes);

            //List<Vote> votes = new List<Vote>();
            //using (DemoSSISEntities dc = new DemoSSISEntities())
            //{
            //    votes = dc.Votes.OrderBy(a => a.id).AsEnumerable<Vote>;
            //    foreach (var vote in votes)
            //    {
            //        CustomVote customVote = new CustomVote();
            //        customVote.A13 = vote.A13;
            //        customVote.A24 = vote.A24;
            //        customVote.A26 = vote.A26;
            //        customVote.A28 = vote.A28;
            //        customVote.B19 = vote.B19;
            //        customVote.B46 = vote.B46;
            //        customVote.B52 = vote.B52;
            //        customVote.B59 = vote.B59;
            //        customVote.C27 = vote.C27;
            //        customVote.Token = vote.Token;               }

            //}

        }

        public ActionResult Success()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(CustomVote customVote)
        {

            if (ModelState.IsValid)
            {
                bool res = CheckCode(customVote.Token);
                res = false;
                if (res == false)
                {
                    ModelState.AddModelError("Name", "Code is invalid or already used.");
                    return View(customVote);
                }
                int c = CountVote(customVote);
                if((c < 4) || (c > 4) )
                {
                    ModelState.AddModelError("Name", "Minimum 4 and Maximum 4 Members you can select.");
                    return View(customVote);
                }
                Vote_Sept22 vote = new Vote_Sept22();
                vote.AGRAZ_SHARMA_A17 = Convert.ToBoolean( customVote.AGRAZ_SHARMA_A17 );/*1*/
                vote.ASHISH_GUPTA_A27 = Convert.ToBoolean(customVote.ASHISH_GUPTA_A27);/*2*/
                vote.ASHISH_TRIPATHI_C29 = Convert.ToBoolean(customVote.ASHISH_TRIPATHI_C29);/*3*/
                vote.DHEERAJ_MISHRA_B21 = Convert.ToBoolean(customVote.DHEERAJ_MISHRA_B21);/*4*/
                vote.MOHSIN_KHAN_A3 = Convert.ToBoolean(customVote.MOHSIN_KHAN_A3);/*5*/
                vote.PARWESH_RANJAN_DEEPAK_B13_14 = Convert.ToBoolean(customVote.PARWESH_RANJAN_DEEPAK_B13_14);/*6*/
                vote.RAM_KUMAR_B26 = Convert.ToBoolean(customVote.RAM_KUMAR_B26);/*7*/
               vote.TARUN_KUMAR_C31 = Convert.ToBoolean(customVote.TARUN_KUMAR_C31);/*7*/
                vote.Token = customVote.Token;
                demoSSISEntities.Vote_Sept22.Add(vote);

                string resVotes = string.Empty;
                resVotes = "Your token no is : " + vote.Token + "-";
                if (vote.AGRAZ_SHARMA_A17 == true)
                {
                    resVotes = resVotes  + " A17 ,";
                }

                if (vote.ASHISH_GUPTA_A27 == true)
                {
                    resVotes = resVotes + "A27 ,";
                }

                if (vote.ASHISH_TRIPATHI_C29 == true)
                {
                    resVotes = resVotes + "C29 ,";
                }

                if (vote.DHEERAJ_MISHRA_B21 == true)
                {
                    resVotes = resVotes + "B21 ,";
                }

                if (vote.MOHSIN_KHAN_A3 == true)
                {
                    resVotes = resVotes + "A3 ,";
                }
                if (vote.PARWESH_RANJAN_DEEPAK_B13_14 == true)
                {
                    resVotes = resVotes + "B13/14 ,";
                }

                if (vote.RAM_KUMAR_B26 == true)
                {
                    resVotes = resVotes + "B26 ,";
                }
                if (vote.TARUN_KUMAR_C31 == true)
                {
                    resVotes = resVotes + "C31 ,";
                }

                @TempData["foo"] = resVotes;

                demoSSISEntities.SaveChanges();

                UpdateCode(vote.Token);
                if (vote.id > 0)
                {
                    ViewBag.Success = "Thank You!";

                }
                ModelState.Clear();
            }
            
            return RedirectToAction("Success");
        }
        [NonAction]
        private int CountVote(CustomVote customVote)
        {
            int c = 0;
            if (customVote.MOHSIN_KHAN_A3 == true)
            {
                c = c + 1;
            }
            if (customVote.PARWESH_RANJAN_DEEPAK_B13_14 == true)
            {
                c = c + 1;
            }
            if (customVote.RAM_KUMAR_B26== true)
            {
                c = c + 1;
            }
            if (customVote.TARUN_KUMAR_C31 == true)
            {
                c = c + 1;
            }
            if (customVote.AGRAZ_SHARMA_A17 == true)
            {
                c = c + 1;
            }
            if (customVote.ASHISH_GUPTA_A27 == true)
            {
                c = c + 1;
            }
            if (customVote.ASHISH_TRIPATHI_C29 == true)
            {
                c = c + 1;
            }
            if (customVote.DHEERAJ_MISHRA_B21 == true)
            {
                c = c + 1;
            }
            
            return c;
            
        }

        [NonAction]
        private bool CheckCode(string token)
        {
           bool CodeActive = false;

            var res = demoSSISEntities.Tokens.Where(t => t.TokenCode == token && t.Status == true).FirstOrDefault();
            if(res != null)
            {
                if (res.TokenCode == token)
                {
                    CodeActive = true;
                }
            }
           
          return CodeActive;
        }
        [NonAction]
        private void UpdateCode(string token)
        {

            Token t = new Token();
            var res = demoSSISEntities.Tokens.Where(u => u.TokenCode == token).FirstOrDefault();

            if (res != null)
            {
                res.Status = false;

                demoSSISEntities.Entry(res).State = EntityState.Modified;
                demoSSISEntities.SaveChanges();
            }
           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
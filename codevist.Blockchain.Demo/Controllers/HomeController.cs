using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using codevist.Blockchain.Demo.Models;

namespace codevist.Blockchain.Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Hash()
        {
            return View();
        }
        public ActionResult Block()
        {
            return View();
        }
        public ActionResult DistributedBlockChain()
        {
            return View();
        }

        public ActionResult ReturnBlockCalculatedHashAndNonceValue(BlockModel model)
        {
            int nonce = 0;
            string hash = string.Empty;
            int diffucultLevel = int.Parse(ConfigurationManager.AppSettings["DifficultyLevel"]);
            var zeros = GetHashRateZeros(diffucultLevel);
            while (true)
            {
                hash = Sha256.CreateSha256(model.Data + nonce);
                if (hash.Substring(0, diffucultLevel) == zeros)
                {
                    break;
                }
                nonce += 1;
            }
            model.Nonce = nonce;
            model.Hash = hash;
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        private static string GetHashRateZeros(int diffucultLevel)
        {
            string corpValue = String.Empty;
            for (int i = 0; i < diffucultLevel; i++)
            {
                corpValue += "0";
            }
            return corpValue;
        }

        public ActionResult BlockChain()
        {
            return View();
        }

        public ActionResult ReturnBlockChainCalculatedHashNonceAndPrev(BlockChainModel model)
        {
            int nonce = 0;
            string hash = string.Empty;
             int diffucultLevel = int.Parse(ConfigurationManager.AppSettings["DifficultyLevel"]);
            var zeros = GetHashRateZeros(diffucultLevel);

            while (true)
            {
                hash = Sha256.CreateSha256(model.Data + model.Prev + nonce);
                if (hash.Substring(0, diffucultLevel) == zeros)
                {
                    break;
                }
                nonce += 1;
            }
            model.Nonce = nonce;
            model.Hash = hash;
            return Json(model, JsonRequestBehavior.AllowGet);
        }



    }
}
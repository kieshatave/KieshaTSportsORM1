using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        { //use intial of table to keep organized
            ViewBag.WomensLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Womens")).ToList();
            ViewBag.HockeyLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Hockey")).ToList();
            ViewBag.NonFootballLeagues = _context.Leagues
                .Where(l => l.Sport != "Football").ToList();
            ViewBag.ConferenceLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Conference")).ToList();
            ViewBag.AtlanticRegion = _context.Leagues
                .Where(l => l.Name.Contains("Atlantic")).ToList();
            ViewBag.DallasTeams = _context.Teams
                .Where(t => t.Location.Contains("Dallas")).ToList();
            ViewBag.RaptorsTeams = _context.Teams
                .Where(t => t.TeamName.Contains("Raptors")).ToList();
            ViewBag.CityTeams = _context.Teams
                .Where(t => t.Location.Contains("City")).ToList();
            ViewBag.StartsWithT = _context.Teams
                .Where(t => t.TeamName.StartsWith("T")).ToList();
            ViewBag.AlphabeticalOrder =_context.Teams
                .OrderBy(t => t.Location).ToList();
            ViewBag.ReverseOrder = _context.Teams
                .OrderByDescending(t => t.Location).ToList();
            ViewBag.CooperPlayers = _context.Players
                .Where(p => p.LastName.Contains("Cooper")).ToList();
            ViewBag.JoshuaPlayers = _context.Players
                .Where(p => p.FirstName.Contains("Joshua")).ToList();
            ViewBag.CooperNotJoshua = _context.Players
                .Where(p => p.LastName == "Cooper" && p.FirstName != "Joshua").ToList();
            ViewBag.AlexanderOrWyatt = _context.Players
                .Where(p => p.FirstName == "Alexander" || p.FirstName == "Wyatt").ToList();
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}
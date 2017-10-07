using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace lab4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(String[] list)
        {
            System.Globalization.CultureInfo.CurrentCulture.ClearCachedData()
            DateTime today = DateTime.UtcNow;
            String month = DateTime.UtcNow.ToString("MMMM");
            DayOfWeek dayofweek = DateTime.UtcNow.DayOfWeek;
            int year = DateTime.UtcNow.Year;
            int day = DateTime.UtcNow.Day;
            String time = today.ToShortTimeString();

            int daysInYear = DateTime.IsLeapYear(today.Year) ? 366 : 365;
            int daysLeftInYear = daysInYear - today.DayOfYear;

            String date = $"The time is {time} on {dayofweek}, {month} {day}, {year}";
            String daysleft = $"There are {daysLeftInYear} more days in {year}";
            String greeting;

            TimeSpan start = new TimeSpan(11,59,59); //12 o'clock
            TimeSpan end = new TimeSpan(18, 0, 0); //12 o'clock
            TimeSpan now = DateTime.UtcNow.TimeOfDay;

            if (DateTime.UtcNow.ToString("tt") == "AM")
            {
                greeting = "Good Morning";
            }
            else if((now > start) && (now < end))
            {
                greeting = "Good Afternoon!";
            }
            else
            {
                greeting = "Good Evening!";
            }

            ViewData["date"] = date;
            ViewData["daysleft"] = daysleft;
            ViewData["greeting"] = greeting;

            return View();
        }

        public IActionResult Items()
        {
            String url = HttpContext.Request.Path;
            String newUrl = url.Substring(12);
            String[] listOfStuff = {"C#","HTML5","CSS3","JavaScript"};

            if(newUrl == "") {
                int id = 0;
                ViewData["id"] = id;
            }
            else
            {
                int id = Convert.ToInt32(newUrl);
                ViewData["id"] = id;
            }

            return View(listOfStuff);
        }

    }
}

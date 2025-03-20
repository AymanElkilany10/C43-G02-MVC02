using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
namespace WebApplication2.Controllers

{
    public class MovieController : Controller
    {
        public string Index()
        {
            return "Hello form Index";
        }

        [HttpGet]
        public IActionResult GetMovie(int? id, string name)
        {
            if (id == 0) return BadRequest();
            else if (id < 10) return NotFound();
            else return Content($"Movie with name = {name} and Id = {id}", "text/html");
        }

        public IActionResult TestRedirectAction()
        {
            return RedirectToRoute("Default", new { Controller = "Movies", Action = "GetMovie", id = 10 });
            //return RedirectToAction(nameof(GetMovie), "Movies", new {id = 10, name = "test"});
            //return Redirect("https://www.youtube.com/");
        }

        [HttpPost]
        public IActionResult TestModelBinding([FromQuery]int id, string name)
        {
            return Content($"Hello {name}, Your Id is {id}");
        }

        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            if (movie is null) return BadRequest();
            else return Content($"Movie {movie.Title} with Id {movie.Id}");
        }

    }
}

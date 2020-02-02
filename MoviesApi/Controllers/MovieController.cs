using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using MoviesApi.Domain;
using Services;

namespace MoviesApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieModel>> Get()
        {
            var userId = GetAuthorizedUserId();
            return Ok(_movieService.GetUserMoviesList(userId));
        }

        [HttpGet("{id}")]
        public ActionResult<MovieModel> Get(int id)
        {
            var userId = GetAuthorizedUserId();
            return Ok(_movieService.GetMovie(id, userId));
        }

        //[Route("byGenre/{genre}")]
        //[HttpGet()]
        //public ActionResult<IEnumerable<Movie>> GetByGenre(int genre)
        //{
        //    var userId = GetAuthorizedUserId();
        //    return Ok(_movieService.GetUserMoviesList();
                
        //}

        [HttpPost]
        public IActionResult Post([FromBody] MovieModel model)
        {
            try
            {
                model.UserId = GetAuthorizedUserId();
                _movieService.AddMovie(model);
                return Ok("Successfully added movie!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
    
           
        }


        private int GetAuthorizedUserId()
        {
            if (!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId))
            {
                throw new Exception("Name Identifier claim does not match!");
            }
            return userId;
        }
        
    }
}
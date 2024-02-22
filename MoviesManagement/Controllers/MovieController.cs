using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesManagement.Data;
using MoviesManagement.Models;

namespace MoviesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MoviesDbContext _ctx;
        private readonly Mapper _mapper;
        private readonly ILogger<MovieController> _logger;

        public MovieController(MoviesDbContext ctx, Mapper mapper, ILogger<MovieController> logger)
        {
            _ctx = ctx;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            Movie? entity = _ctx.Movies
                .Include(m => m.Technologies)
                .Include(m => m.AgeLimit)
                .Include(m => m.Projections)
                .ThenInclude(p => p.Room)
                .SingleOrDefault(m => m.MovieId == id);
            if(entity == null)
            {
                return BadRequest("Film non trovato");
            }
            MovieModel model = _mapper.MapEntityToModel(entity);
            return Ok(model);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Ingresso nel metodo GetAll del controller MovieController");
            try
            {
                List<Movie> movies = _ctx.Movies
                    .Include(m => m.Technologies)
                    .Include(m => m.AgeLimit)
                    .ToList();

                List<MovieModel> result = movies
                    .ConvertAll(_mapper.MapEntityToModel);

                return Ok(result);
            } 
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(
                    StatusCodes.Status500InternalServerError, 
                    "Si è rotto qualcosa"
                );
            }
        }

        [HttpGet]
        [Route("GetAllStringata")]
        public IActionResult GetAllMin()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch(Exception ex)
            {
                _logger.LogWarning(ex.Message, ex);
                return StatusCode(StatusCodes.Status501NotImplemented);
            }
        }
    }
}

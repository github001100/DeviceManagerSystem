using API_XL_OMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_XL_OMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly TestContext _context;

        public MoviesController(TestContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieItemDTO>>> GetMovie()
        {
            //return await _context.Movie.ToListAsync();
            return await _context.Movie.Select(x => ItemToDTO(x)).ToListAsync();//查看未限定属性
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieItemDTO>> GetMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return ItemToDTO(movie);
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);//替换 PostTodoItem 中的返回语句，以使用 nameof 运算符：
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
        /// <summary>
        /// DTO 可用于：防止过度发布。隐藏客户端不应查看的属性。
        /// 省略一些属性以缩减有效负载大小。平展包含嵌套对象的对象图。 对客户端而言，平展的对象图可能更方便。。
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        private static MovieItemDTO ItemToDTO(Movie movie) =>
       new MovieItemDTO
       {
           Id = movie.Id,
           Genre = movie.Genre,
           Title = movie.Title
       };
    }
}

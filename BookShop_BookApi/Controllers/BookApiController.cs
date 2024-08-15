using BookShop_BookApi.Data;
using BookShop_BookApi.Models;
using BookShop_BookApi.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShop_BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookApiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public BookApiController(ApplicationDbContext db) { 
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
        {
            return Ok(await _db.Books.ToListAsync());
        }

        [HttpGet("{id:int}", Name = "GetBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookDTO>> GetBook(int id) {
            if (id < 0) {
                return BadRequest();
            }
            var book = await _db.Books.FirstOrDefaultAsync(u => u.id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BookDTO>> AddBook([FromBody]BookDTO bookDTO) {
            if (await _db.Books.FirstOrDefaultAsync(u => u.title.ToLower() == bookDTO.title.ToLower()) != null)
            {
                ModelState.AddModelError("PostError", "Book is already exist");
                return BadRequest(ModelState);
            }
            if (bookDTO == null) {
                return BadRequest(bookDTO);
            }
            if(bookDTO.id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Book model = new Book()
            {
                title = bookDTO.title,
                author = bookDTO.author,
                description = bookDTO.description,
                coverUrl = bookDTO.coverUrl,
                price = bookDTO.price,
                stock = bookDTO.stock,
                addDate = DateTime.Now,
                language = bookDTO.language,
                genre = bookDTO.genre
            };
            await _db.Books.AddAsync(model);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("GetBook", new {id=bookDTO.id}, bookDTO);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBook(int id) {
            if (id == 0)
            {
                return BadRequest();
            }
            var book = await _db.Books.FirstOrDefaultAsync(u => u.id == id);
            if (book == null)
            {
                {
                    return NotFound();
                }
            }
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
            return NoContent();
           
        }

        [HttpPut("{id:int}", Name ="UpdateBook")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateBook(int id, [FromBody]BookDTO bookDTO)
        {
            if (bookDTO == null || bookDTO.id != id) 
            {
                return BadRequest();
            }
            Book? book = await _db.Books.FirstOrDefaultAsync(u => u.id == id);
            if (book == null)
            {
                return NotFound();
            }

            book.title = bookDTO.title;
            book.author = bookDTO.author;
            book.description = bookDTO.description;
            book.coverUrl = bookDTO.coverUrl;
            book.price = bookDTO.price;
            book.stock = bookDTO.stock;
            book.language = bookDTO.language;
            book.genre = bookDTO.genre;

            _db.Books.Update(book);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialBook")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePartialBook(int id, JsonPatchDocument<BookDTO> patchDTO)
        {
            if (id == 0 || patchDTO == null)
            {
                return BadRequest();
            }

            var book = await _db.Books.FirstOrDefaultAsync(u => u.id == id);

            if (book == null)
            {
                return NotFound();
            }

            var bookDTO = new BookDTO
            {
                title = book.title,
                author = book.author,
                description = book.description,
                coverUrl = book.coverUrl,
                price = book.price,
                stock = book.stock,
                language = book.language,
                genre = book.genre
            };

            patchDTO.ApplyTo(bookDTO, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            book.title = bookDTO.title;
            book.author = bookDTO.author;
            book.description = bookDTO.description;
            book.coverUrl = bookDTO.coverUrl;
            book.price = bookDTO.price;
            book.stock = bookDTO.stock;
            book.language = bookDTO.language;
            book.genre = bookDTO.genre;

            _db.Books.Update(book);
            await _db.SaveChangesAsync();

            return NoContent();
        }

    }
}

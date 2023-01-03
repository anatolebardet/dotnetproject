using Mapster;
using Microsoft.AspNetCore.Mvc;
using VideoTheque.Businesses.Film;
using VideoTheque.DTOs;
using VideoTheque.ViewModels;

namespace VideoTheque.Controllers
{
    [ApiController]
    [Route("films")]
    public class FilmsController : ControllerBase
    {

        private readonly IFilmBusiness _filmsBusiness;
        protected readonly ILogger<FilmsController> _logger;

        public FilmsController(ILogger<FilmsController> logger, IFilmBusiness filmsBusiness)
        {
            _logger = logger;
            _filmsBusiness = filmsBusiness;
        }

        [HttpGet]
        public async Task<List<FilmViewModel>> GetFilms() => _filmsBusiness.GetFilms().Adapt<List<FilmViewModel>>();

        [HttpGet("{id}")]
        public async Task<FilmViewModel> GetFilm([FromRoute] int id) => _filmsBusiness.GetFilm(id).Adapt<FilmViewModel>();

        [HttpPost]
        public async Task<IResult> InsentFilm([FromBody] FilmViewModel filmVM)
        {
            var created = _filmsBusiness.InsertFilm(filmVM.Adapt<FilmDto>());
            return Results.Created($"/films/{created.Id}", created);
        }

        [HttpPut("{id}")]
        public async Task<IResult> UpdateFilm([FromRoute] int id, [FromBody] FilmViewModel filmVM)
        {
            _filmsBusiness.UpdateFilm(id, filmVM.Adapt<FilmDto>());
            return Results.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteFilm([FromRoute] int id)
        {
            _filmsBusiness.DeleteFilm(id);
            return Results.Ok();
        }
    }
}

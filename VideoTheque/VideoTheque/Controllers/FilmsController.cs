namespace VideoTheque.Controllers
{
    using Mapster;
    using Microsoft.AspNetCore.Mvc;
    using VideoTheque.Businesses.Films;
    using VideoTheque.DTOs;
    using VideoTheque.ViewModels;

    [ApiController]
    [Route("films")]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmsBusiness _filmsBusiness;
        protected readonly ILogger<FilmsController> _logger;

        public FilmsController(ILogger<FilmsController> logger, IFilmsBusiness filmsBusiness)
        {
            _logger = logger;
            _filmsBusiness = filmsBusiness;
        }

        [HttpGet]
        public async Task<List<FilmsViewModel>> GetFilms() => (await _filmsBusiness.GetFilms()).Adapt<List<FilmsViewModel>>();

        [HttpGet("{id}")]
        public async Task<FilmsViewModel> GetFilms([FromRoute] int id) => _filmsBusiness.GetFilms(id).Adapt<FilmsViewModel>();

        [HttpPost]
        public async Task<IResult> InsentFilms([FromBody] FilmsViewModel filmsVM)
        {
            var created = _filmsBusiness.InsertFilms(filmsVM.Adapt<FilmsDto>());
            return Results.Created($"/films/{created.Id}", created);
        }

        [HttpPut("{id}")]
        public async Task<IResult> UpdateFilms([FromRoute] int id, [FromBody] FilmsViewModel filmsVM)
        {
            _filmsBusiness.UpdateFilms(id, filmsVM.Adapt<FilmsDto>());
            return Results.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteFilms([FromRoute] int id)
        {
            _FilmsBusiness.DeleteFilms(id);
            return Results.Ok();
        }
    }
}

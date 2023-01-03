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
        public async Task<List<FilmViewModel>> GetFilms() => _filmsBusiness.GetFilms().Adapt<List<FilmViewModel>>(getTypeAdapterConfig());

        [HttpGet("{id}")]
        public async Task<FilmViewModel> GetFilm([FromRoute] int id) => _filmsBusiness.GetFilm(id).Adapt<FilmViewModel>(getTypeAdapterConfig());

        [HttpPost]
        public async Task<IResult> InsentFilm([FromBody] FilmViewModel filmVM)
        {
            var created = _filmsBusiness.InsertFilm(filmVM.Adapt<FilmDto>(getTypeAdapterConfig()));
            return Results.Created($"/films/{created.Id}", created);
        }

        [HttpPut("{id}")]
        public async Task<IResult> UpdateFilm([FromRoute] int id, [FromBody] FilmViewModel filmVM)
        {
            _filmsBusiness.UpdateFilm(id, filmVM.Adapt<FilmDto>(getTypeAdapterConfig()));
            return Results.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteFilm([FromRoute] int id)
        {
            _filmsBusiness.DeleteFilm(id);
            return Results.Ok();
        }
        private TypeAdapterConfig getTypeAdapterConfig()
        {
            var _filmModel = new TypeAdapterConfig();
            _filmModel.NewConfig<FilmDto, FilmViewModel>()
                .Map(dest => dest.FirstActor, src => src.FirstActor)
                .Map(dest => dest.Scenarist, src => src.Scenarist)
                .Map(dest => dest.Support, src => src.Support)
                .Map(dest => dest.AgeRating, src => src.AgeRating)
                .Map(dest => dest.Director, src => src.Director);
            return _filmModel;
        }
    }
}

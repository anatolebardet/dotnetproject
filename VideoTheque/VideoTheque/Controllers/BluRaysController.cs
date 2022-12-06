namespace VideoTheque.Controllers
{
    using Mapster;
    using Microsoft.AspNetCore.Mvc;
    using VideoTheque.Businesses.BluRays;
    using VideoTheque.DTOs;
    using VideoTheque.ViewModels;

    [ApiController]
    [Route("blurays")]
    public class BluRaysController : ControllerBase
    {
        private readonly IBluRaysBusiness _bluRaysBusiness;
        protected readonly ILogger<BluRaysController> _logger;

        public BluRaysController(ILogger<BluRaysController> logger, IBluRaysBusiness bluRaysBusiness)
        {
            _logger = logger;
            _bluRaysBusiness = bluRaysBusiness;
        }

        [HttpGet]
        public async Task<List<BluRayViewModel>> GetBluRays() => (await _bluRaysBusiness.GetBluRays()).Adapt<List<BluRayViewModel>>();

        [HttpGet("{id}")]
        public async Task<BluRayViewModel> GetBluRay([FromRoute] int id) => _bluRaysBusiness.GetBluRay(id).Adapt<BluRayViewModel>();

        [HttpPost]
        public async Task<IResult> InsentBluRay([FromBody] BluRayViewModel bluRayVM)
        {
            var created = _bluRaysBusiness.InsertBluRay(bluRayVM.Adapt<BluRayDto>());
            return Results.Created($"/blurays/{created.Id}", created);
        }

        [HttpPut("{id}")]
        public async Task<IResult> UpdateBluRay([FromRoute] int id, [FromBody] BluRayViewModel bluRayVM)
        {
            _bluRaysBusiness.UpdateBluRay(id, bluRayVM.Adapt<BluRayDto>());
            return Results.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteBluRay([FromRoute] int id)
        {
            _bluRaysBusiness.DeleteBluRay(id);
            return Results.Ok();
        }
    }
}

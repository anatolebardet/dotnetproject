namespace VideoTheque.Controllers
{
    using Mapster;
    using Microsoft.AspNetCore.Mvc;
    using VideoTheque.Businesses.BluRays;
    using VideoTheque.DTOs;
    using VideoTheque.ViewModels;

    [ApiController]
    [Route("blurays")]
    public class SupportController : ControllerBase
    {
        private readonly IBluRaysBusiness _supportsBusiness;
        protected readonly ILogger<BluRaysController> _logger;

        public BluRaysController(ILogger<BluRaysController> logger, IBluRaysBusiness supportsBusiness)
        {
            _logger = logger;
            _supportsBusiness = supportsBusiness;
        }

        [HttpGet]
        public async Task<List<BluRayViewModel>> GetBluRays() => (await _supportsBusiness.GetBluRays()).Adapt<List<BluRayViewModel>>();

        [HttpGet("{id}")]
        public async Task<BluRayViewModel> GetBluRay([FromRoute] int id) => _supportsBusiness.GetBluRay(id).Adapt<BluRayViewModel>();

        [HttpPost]
        public async Task<IResult> InsentBluRay([FromBody] BluRayViewModel supportVM)
        {
            var created = _supportsBusiness.InsertBluRay(supportVM.Adapt<BluRayDto>());
            return Results.Created($"/blurays/{created.Id}", created);
        }

        [HttpPut("{id}")]
        public async Task<IResult> UpdateBluRay([FromRoute] int id, [FromBody] BluRayViewModel supportVM)
        {
            _supportsBusiness.UpdateBluRay(id, supportVM.Adapt<BluRayDto>());
            return Results.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteBluRay([FromRoute] int id)
        {
            _supportsBusiness.DeleteBluRay(id);
            return Results.Ok();
        }
    }
}

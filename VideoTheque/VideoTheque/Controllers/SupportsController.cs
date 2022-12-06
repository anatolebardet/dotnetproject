namespace VideoTheque.Controllers
{
    using Mapster;
    using Microsoft.AspNetCore.Mvc;
    using VideoTheque.Businesses.BluRays;
    using VideoTheque.DTOs;
    using VideoTheque.ViewModels;

    [ApiController]
    [Route("blurays")]
    public class SupportsController : ControllerBase
    {
        private readonly IBluRaysBusiness _supportsBusiness;
        protected readonly ILogger<BluRaysController> _logger;

        public SupportsController(ILogger<BluRaysController> logger, IBluRaysBusiness supportsBusiness)
        {
            _logger = logger;
            _supportsBusiness = supportsBusiness;
        }

        [HttpGet]
        public async Task<List<SupportsViewModel>> GetBluRays() => (await _supportsBusiness.GetBluRays()).Adapt<List<SupportsViewModel>>();

        [HttpGet("{id}")]
        public async Task<SupportsViewModel> GetBluRay([FromRoute] int id) => _supportsBusiness.GetBluRay(id).Adapt<SupportsViewModel>();

        [HttpPost]
        public async Task<IResult> InsentBluRay([FromBody] SupportsViewModel supportVM)
        {
            var created = _supportsBusiness.InsertBluRay(supportVM.Adapt<BluRayDto>());
            return Results.Created($"/blurays/{created.Id}", created);
        }

        [HttpPut("{id}")]
        public async Task<IResult> UpdateBluRay([FromRoute] int id, [FromBody] SupportsViewModel supportVM)
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

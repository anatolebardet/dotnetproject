namespace VideoTheque.Controllers
{
    using Mapster;
    using Microsoft.AspNetCore.Mvc;
    using VideoTheque.Businesses.Supports;
    using VideoTheque.DTOs;
    using VideoTheque.ViewModels;

    [ApiController]
    [Route("support")]
    public class SupportsController : ControllerBase
    {
        private readonly ISupportsBusiness _supportsBusiness;
        protected readonly ILogger<SupportsController> _logger;

        public SupportsController(ILogger<SupportsController> logger, ISupportsBusiness supportsBusiness)
        {
            _logger = logger;
            _supportsBusiness = supportsBusiness;
        }

        [HttpGet]
        public async Task<List<SupportsViewModel>> GetSupports() => (await _supportsBusiness.GetSupports()).Adapt<List<SupportsViewModel>>();

        [HttpGet("{id}")]
        public async Task<SupportsViewModel> GetSupport([FromRoute] int id) => _supportsBusiness.GetSupport(id).Adapt<SupportsViewModel>();

        [HttpPost]
        public async Task<IResult> InsertSupport([FromBody] SupportsViewModel supportVM)
        {
            var created = _supportsBusiness.InsertSupport(supportVM.Adapt<SupportDto>());
            return Results.Created($"/supports/{created.Id}", created);
        }

        [HttpPut("{id}")]
        public async Task<IResult> UpdateSupport([FromRoute] int id, [FromBody] SupportsViewModel supportVM)
        {
            _supportsBusiness.UpdateSupport(id, supportVM.Adapt<SupportDto>());
            return Results.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteSupport([FromRoute] int id)
        {
            _supportsBusiness.DeleteSupport(id);
            return Results.Ok();
        }
    }
}

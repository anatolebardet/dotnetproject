using Microsoft.AspNetCore.Mvc;
using VideoTheque.Businesses.Emprunts;

namespace VideoTheque.Controllers
{
    [ApiController]
    [Route("emprunts")]
    public class EmpruntsController : ControllerBase
    {
        private readonly IEmpruntsBusiness _empruntsBusiness;
        protected readonly ILogger<EmpruntsController> _logger;
        public EmpruntsController(ILogger<EmpruntsController> logger, IEmpruntsBusiness empruntsBusiness)
        {
            _logger = logger;
            _empruntsBusiness = empruntsBusiness;
        }
        



    } 
}

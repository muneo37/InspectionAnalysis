using InspectionAnalysis.Operator;
using InspectionAnalysis.Shared;
using Microsoft.AspNetCore.Mvc;

namespace InspectionAnalysis.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InspectionDataController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<InspectResult> Get()
        {
            var indexDate = DateTime.Now;
            return Select.InspectResultWhereTime(indexDate, indexDate.AddDays(1));
        }
    }
}

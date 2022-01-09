using AIHR.WorkloadCalculator.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace AIHR.WorkloadCalculator.Service.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class WorkloadCalculatorController : ControllerBase
    {


        private readonly ILogger<WorkloadCalculatorController> _logger;
        private readonly IWorkloadCalculatorService _service;

        public WorkloadCalculatorController(ILogger<WorkloadCalculatorController> logger, IWorkloadCalculatorService service)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }


        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Course>))]
        [HttpGet("GetCourseList")]
        public async Task<IEnumerable<Course>> GetAsync(CancellationToken cancellationToken)
        {
            return await _service.GetAllCoursesAsync();
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WorkloadCalculateHistory>))]
        [HttpGet("GetWorkloadCalculationsHistory")]
        public async Task<IEnumerable<WorkloadCalculateHistory>> GetWorkloadCalculationsHistoryAsync(CancellationToken cancellationToken)
        {
            return await _service.GetAllSavedWorkloadCalculationsAsync();
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WorkloadCalculateResponse))]
        [HttpPost("CalculateWorkload")]
        public async Task<WorkloadCalculateResponse> CalculateWorkloadAsync(WorkloadCalculateRequest request, CancellationToken cancellationToken)
        {
            var res= await _service.WorkloadCalculate(request);
            return new WorkloadCalculateResponse(res.SuggestedDailyStudyHours);
        }

    }
}
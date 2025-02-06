using Cen_ConWEB.BAL.Dtos.Types;
using Cen_ConWEB.BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cen_ConWEB.APP.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobService _jobService;
        private readonly IClientService _clientService;
        private readonly IConcreteCustomerService _concreteCustomerService;
        private readonly IConcreteSupplierService _concreteSupplierService;
        private readonly IFinishService _finishService;
        private readonly ICrewService _crewService;
        private readonly IJobTypeService _jobTypeService;

        public JobsController(IJobService jobService, IClientService clientService, 
            IConcreteCustomerService concreteCustomerService, IConcreteSupplierService concreteSupplierService, 
            IFinishService finishService, ICrewService crewService, IJobTypeService jobTypeService)
        {
            _jobService = jobService;
            _clientService = clientService;
            _concreteCustomerService = concreteCustomerService;
            _concreteSupplierService = concreteSupplierService;
            _finishService = finishService;
            _crewService = crewService;
            _jobTypeService = jobTypeService;
        }

        [HttpGet]
        [Route("{controller}/get-jobs")]
        public async Task<IActionResult> Index()
        {
            var jobs = await _jobService.GetAll();
            return base.View("Index", (object)jobs);
        }

        [HttpGet]
        [Route("{controller}/get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var job = await _jobService.GetById(id);
            return base.View("GetById", (object)job);
        }

        [HttpGet]
        [Route("{controller}/create-job/clientId={id}")]
        public async Task<IActionResult> Create(int id)
        {
            var clients = await _clientService.GetAll();
            var customers = await _concreteCustomerService.GetAll();
            var suppliers = await _concreteSupplierService.GetAll();
            var finishes = await _finishService.GetAll();
            var jobTypes = await _jobTypeService.GetAll();
            var crews = await _crewService.GetAll();

            var jobCreateDto = new JobCreateOptionsDto
            {
                ClientId = id,
                Clients = clients,
                Customers = customers,
                Suppliers = suppliers,
                Finishes = finishes,
                JobTypes = jobTypes,
                Crews = crews
            };
            return View(jobCreateDto);
        }

        [HttpPost]
        [Route("{controller}/create-job-post")]
        public async Task<IActionResult> CreateJob(JobCreateDto job)
        {
            job.StatusId = 1;
            job.CreatedAt = DateTime.UtcNow;
            job.UpdatedAt = DateTime.UtcNow;


            if (ModelState.IsValid)
            {
                var result = await _jobService.CreateJob(job);
                return RedirectToAction("Index");
            }
            return View("Create", job);
        }
    }
}

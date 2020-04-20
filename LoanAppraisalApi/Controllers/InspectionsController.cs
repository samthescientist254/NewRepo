using LoanAppraisalApi.Models;
using LoanAppraisalApi.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LoanAppraisalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionsController : ControllerBase
    {
        private readonly IDataRepository<Inspection, long> _iRepo;
        public InspectionsController(IDataRepository<Inspection, long> repo)
        {
            _iRepo = repo;
        }


        // GET: api/Inspections
        [HttpGet]
        public IEnumerable<Inspection> Get()
        {
            return _iRepo.GetAll();
        }
        // GET: api/Inspections/5
        [HttpGet("{id}")]
        public Inspection Get(int id)
        {
            return _iRepo.Get(id);
        }

        // PUT: api/Inspections/5
        [HttpPut]
        public long Put([FromBody]Inspection inspection)
        {
            _iRepo.Update(inspection.ID, inspection);
            return inspection.ID;
        }

        // POST: api/Inspections
        [HttpPost]
        public object Post([FromBody]Inspection inspection)
        {

            return _iRepo.Add(inspection);
        }

        // DELETE: api/Inspections/5
        [HttpDelete("{id}")]
        public long Delete(int id)
        {
            return _iRepo.Delete(id);
        }
    }
}

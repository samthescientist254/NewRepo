using LoanAppraisalApi.Models;
using LoanAppraisalApi.Models.DataManager;
using LoanAppraisalApi.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LoanAppraisalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanAppraisalDetailsController : ControllerBase
    {
        private readonly IDataRepository<LoanAppraisalDetails, long> _iRepo;

        public LoanAppraisalDetailsController(IDataRepository<LoanAppraisalDetails, long> repo)
        {
            _iRepo = repo;
        }

        // GET: api/LoanAppraisalDetails
        [HttpGet]
        public IEnumerable<LoanAppraisalDetails> Get()
        {
            return _iRepo.GetAll();
        }

        // GET: api/LoanAppraisalDetails/5
        [HttpGet("{id}")]
        public LoanAppraisalDetails Get(int id)
        {
            return _iRepo.Get(id);
        }

        // PUT: api/LoanAppraisalDetails/5
        [HttpPut]
        public long Put([FromBody]LoanAppraisalDetails loanAppraisalDetails)
        {
            _iRepo.Update(loanAppraisalDetails.ID, loanAppraisalDetails);
            return loanAppraisalDetails.ID;
        }
        // POST: api/LoanAppraisalDetails
        [HttpPost]
        public object Post([FromBody]LoanAppraisalDetails appraisalDetails)
        {

            return _iRepo.Add(appraisalDetails);
        }

        // DELETE: api/LoanAppraisalDetails/5
        [HttpDelete("{id}")]
        public long Delete(int id)
        {
            return _iRepo.Delete(id);
        }
    }
}

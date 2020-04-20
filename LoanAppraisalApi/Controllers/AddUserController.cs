using LoanAppraisalApi.Models;
using LoanAppraisalApi.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace LoanAppraisalApi.Controllers
{
    [Route("api/[controller]")]
    public class AddUserController : Controller

    {


        private readonly IDataRepository<Users, long> _iRepo;
        public AddUserController(IDataRepository<Users, long> repo)
        {
            _iRepo = repo;
        }


        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return _iRepo.GetAll();
        }

        // GET api/values/5  
        [HttpGet("{id}")]
        public Users Get(int id)
        {
            return _iRepo.Get(id);
        }

        // POST api/values  
        [HttpPost]
        public object Post([FromBody]Users users)
        {
            users.AddTime = DateTime.Now;
            return _iRepo.Add(users);
        }

        // POST api/values  
        [HttpPut]
        public long Put([FromBody]Users user)
        {
            _iRepo.Update(user.UserId, user);
            return user.UserId;
        }

        // DELETE api/values/5  
        [HttpDelete("{id}")]
        public long Delete(int id)
        {
            return _iRepo.Delete(id);
        }
    }



}


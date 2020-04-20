using LoanAppraisalApi.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoanAppraisalApi.Models.DataManager
{
    public class LoanAppraisalDetailsManager : IDataRepository<LoanAppraisalDetails, long>
    {
        private readonly LoanAppraisalContext ctx;

        readonly Response response = new Response();
        public LoanAppraisalDetailsManager(LoanAppraisalContext c)
        {
            ctx = c;
        }

        public LoanAppraisalDetails Get(long id)
        {
            LoanAppraisalDetails loanAppraisalDetails = ctx.loanAppraisalDetails.FirstOrDefault(b => b.ID == Convert.ToInt64(id));
            return loanAppraisalDetails;
        }

        public IEnumerable<LoanAppraisalDetails> GetAll()
        {
            List<LoanAppraisalDetails> loanapraisal = ctx.loanAppraisalDetails.ToList();
            return loanapraisal;
        }

        public object Add(LoanAppraisalDetails loanAppraisal)
        {
            try
            {
                LoanAppraisalDetails loanAppraisal__ = ctx.loanAppraisalDetails.FirstOrDefault(b => b.BusinessRegNo == loanAppraisal.BusinessRegNo);
                /*LoanAppraisalDetails loan=ctx.loanAppraisalDetails.FirstOrDefault(c=> c.Users.)*/
                if (loanAppraisal__ == null)
                {
                    ctx.loanAppraisalDetails.Add(loanAppraisal);
                    ctx.SaveChanges();
                    response.status = true;
                    response.Description = "Appraisal  Was Added Successfully";
                    response.code = 57;
                    return response;
                }
                else
                {
                    response.status = false;
                    response.Description = "Appraisal failed to add";
                    response.code = 58;
                    return response;
                }
            }
            catch(Exception e) {
                response.status = false;
                response.Description = e.Message;
                response.code = 59;
                return response;
            }
        }

        public long Delete(long id)
        {
            LoanAppraisalDetails loanDetails = ctx.loanAppraisalDetails.FirstOrDefault(b => b.ID == id);
            if (loanDetails != null)
            {
                ctx.loanAppraisalDetails.Remove(loanDetails);
                ctx.SaveChanges();
            }
            return loanDetails.ID;
        }

        public long Update(long ID, LoanAppraisalDetails loanAppraisal)
        {
            LoanAppraisalDetails loanAppraisal1 = ctx.loanAppraisalDetails.Find(Convert.ToInt32(ID));
            if (loanAppraisal1 != null)
            {
                loanAppraisal1.Adress = loanAppraisal.Adress;
                loanAppraisal1.BusinessRegNo = loanAppraisal.BusinessRegNo;
                loanAppraisal1.City = loanAppraisal.City;
                loanAppraisal1.CurrentGPSLAT = loanAppraisal.CurrentGPSLAT;
                loanAppraisal1.CurrentGPSLONG = loanAppraisal.CurrentGPSLONG;
                loanAppraisal1.ImageOne = loanAppraisal.ImageOne;
                loanAppraisal1.ImageTwo = loanAppraisal.ImageTwo;
                loanAppraisal1.LoanAmount = loanAppraisal.LoanAmount;
                loanAppraisal1.LoaneeeLastName = loanAppraisal.LoaneeeLastName;
                loanAppraisal1.LoaneeFirstName = loanAppraisal.LoaneeFirstName;
                loanAppraisal1.LoaneeIdNo = loanAppraisal.LoaneeIdNo;

                ctx.SaveChanges();
            }
            return loanAppraisal1.ID;
        }

      

    }
}

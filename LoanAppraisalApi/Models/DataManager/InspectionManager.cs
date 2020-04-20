using LoanAppraisalApi.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoanAppraisalApi.Models.DataManager
{
    public class InspectionManager : IDataRepository<Inspection, long>
    {

        private readonly LoanAppraisalContext ctx;
        string IsSuccess = "";
        readonly Response response = new Response();
        public InspectionManager(LoanAppraisalContext c)
        {
            ctx = c;
        }
        public object Add(Inspection inspect)
        {

            bool AppraisalRangeOK = false;


            if (inspect.GPSLAT.HasValue && inspect.GPSLONG.HasValue)
            {
                AppraisalRangeOK = VerifyLocation(inspect.GPSLAT, inspect.GPSLONG, inspect.LoaneeAccountNo);
            }
            if (AppraisalRangeOK == false)
            {
                response.status = false;
                response.Description = "Location Out of Range";
                response.code = 60;
                return response;
            }
            else
            {
                ctx.inspections.Add(inspect);
                ctx.SaveChanges();

                response.status = true;
                response.Description = "Inspection Was Added Successfully";
                response.code = 61;
                return response;
            }



        }

        public long Delete(long id)
        {
            int ID = 0;
            Inspection inspection = ctx.inspections.FirstOrDefault(b => b.ID == id);
            if (inspection != null)
            {
                ctx.inspections.Remove(inspection);
                ID = ctx.SaveChanges();
            }
            return ID;
        }

        public Inspection Get(long id)
        {
            Inspection inspection = ctx.inspections.FirstOrDefault(b => b.ID == Convert.ToInt64(id));
            return inspection;
        }

        public IEnumerable<Inspection> GetAll()
        {
            List<Inspection> inspections = ctx.inspections.ToList();
            return inspections;
        }

        public long Update(long id, Inspection inspect)
        {
            Inspection inspection = ctx.inspections.Find(Convert.ToInt32(id));

            if (inspection != null)
            {
                inspection.BusinessRegNo = inspection.BusinessRegNo;
                inspection.GPSLAT = inspection.GPSLAT;
                inspection.GPSLONG = inspection.GPSLONG;
                inspection.Image = inspection.Image;
                inspection.Image_ = inspection.Image_;

                ctx.SaveChanges();
            }
            return inspection.ID;
        }

        public bool VerifyLocation(double? DeviceTransmissionlat, double? DeviceTransmissionLong, string LoaneeAccount)
        {
            bool LocationOkay = false;
            var BusinessRegNo = ctx.loanAppraisalDetails.FirstOrDefault(o => o.LoaneeAccount == LoaneeAccount).BusinessRegNo;
            var LoanDetails = ctx.loanAppraisalDetails.FirstOrDefault(d => d.BusinessRegNo == BusinessRegNo);

            var busLat = (double)LoanDetails.CurrentGPSLAT;
            var buslong = (double)LoanDetails.CurrentGPSLONG;
            double dist = CalcDistance((double)DeviceTransmissionlat, (double)DeviceTransmissionLong, busLat, buslong);
            var maxRange = 1000000000;
            LocationOkay = (dist <= maxRange) ? true : false;
            return LocationOkay;

        }

        Func<double, double, double, double, double> CalcDistance = (TransmissionLat, TransmissionLong, BusiLat, BusiLong) =>
        {
            Func<double, double> Radians = (angle) =>
            {
                return angle * (180.0 / Math.PI);
            };

            const double radius = 6371;

            double delataSigma = Math.Acos(Math.Sin(Radians(TransmissionLat)) * Math.Sin(Radians(BusiLat)) +
                Math.Cos(Radians(TransmissionLat)) * Math.Cos(Radians(BusiLat)) * Math.Cos(Math.Abs(Radians(BusiLong) - Radians(TransmissionLong))));

            double distance = radius * delataSigma;

            return distance;
        };
    }
}

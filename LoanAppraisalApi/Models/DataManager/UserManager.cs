using LoanAppraisalApi.Models.Repository;
using LoanAppraisalApi.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoanAppraisalApi.Models.DataManager
{


    public class UserManager : IDataRepository<Users, long>
    {
        readonly SecureData secureData = new SecureData();
        readonly Response response = new Response();
        private readonly LoanAppraisalContext ctx;
        public UserManager(LoanAppraisalContext c)
        {
            ctx = c;
        }

        public Users Get(long ID)
        {
            Users users = ctx.users.FirstOrDefault(b => b.UserId == Convert.ToInt64(ID));
            return users;
        }


        public IEnumerable<Users> GetAll()
        {
            List<Users> students = ctx.users.ToList();
            return students;
        }

        public object Add(Users user)
        {
            Users users = ctx.users.FirstOrDefault(b => b.UserName == user.UserName);
            Users IDNO = ctx.users.FirstOrDefault(b => b.EmployeeIDNO == user.EmployeeIDNO);
            Users phoneNumber = ctx.users.FirstOrDefault(b => b.Cellphone == user.Cellphone);
            if (users == null & IDNO == null & phoneNumber == null)
            {

                user.Password = secureData.Encrypt(user.Password, "LoanApp");
                ctx.users.Add(user);
                ctx.SaveChanges();
                /*Console.WriteLine(secureData.Decrypt(user.Password, "LoanApp"));*/
                response.status = true;
                response.Description = "User Was Added Successfully";
                response.code = 55;
                return response;


            }
            else
            {
                if (users != null & IDNO != null & phoneNumber != null)
                {
                    response.status = false;
                    response.Description = user.UserName + "  and    " + user.EmployeeIDNO + "  :exits";
                    response.code = 56;
                    return response;

                }
                else if (IDNO != null)
                {

                    response.status = false;
                    response.Description = user.EmployeeIDNO + ":  exits";
                    response.code = 57;
                    return response;

                }

                else if (phoneNumber != null)
                {

                    response.status = false;
                    response.Description = user.Cellphone + ":  exits";
                    response.code = 58;
                    return response;

                }
                else if (users != null)
                {

                    response.status = false;
                    response.Description = user.UserName + ":  exits ";
                    response.code = 59;
                    return response;

                }
                else
                {

                    response.status = false;
                    response.Description = "server error";
                    return response;

                }
            }
        }

        public long Delete(long id)
        {
            Users user = ctx.users.FirstOrDefault(b => b.UserId == id);
            if (user != null)
            {
                ctx.users.Remove(user);
                ctx.SaveChanges();
            }
            return user.UserId;
        }

        public long Update(long id, Users users)
        {
            Users users1 = ctx.users.Find(Convert.ToInt64(id));
            if (users1 != null)
            {
                users1.FirstName = users.FirstName;
                users1.LastName = users.LastName;
                users1.EmployeeNumber = users.EmployeeNumber;
                users1.EmployeeIDNO = users.EmployeeIDNO;
                users1.UserName = users.UserName;
                users1.Adress = users.Adress;
                users1.Cellphone = users.Cellphone;
                users1.City = users.City;
                users1.Password = users.Password;

                ctx.SaveChanges();
            }
            return users1.UserId;
        }



    }
}


using LoanAppraisalApi.Models;
using LoanAppraisalApi.Models.DataManager;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace XUnitTestLoanAppraisal
{
    public class UnitTest1
    {
        UserManager userManager;
        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var usernameMissingItem = new Users()
            {
                FirstName = "William",
                LastName = "Kung'u",
                Adress = "1289",
                City = "Nairobi",
                EmployeeNumber = "5566789",
                Password = "pass@word1",
                Cellphone = "0724354609",
                EmployeeIDNO = "32722757"

            };
            //_controller.ModelState.AddModelError("Name", "Required");

            // Act
            var badResponse = userManager.Add(usernameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }


        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Users testItem = new Users()
            {
                FirstName = "William",
                LastName = "Kung'u",
                Adress = "1289",
                City = "Nairobi",
                EmployeeNumber = "5566789",
                UserName = "skim",
                Password = "pass@word1",
                Cellphone = "0724354609",
                EmployeeIDNO = "32722757"
            };

            // Act
            var createdResponse = userManager.Add(testItem);

            // Assert
            Assert.IsType<Response>(createdResponse);
        }
    }
}

using System;
using Xunit;
using Credit_Card_Management_System.Controllers;
using Credit_Card_Management_System.Models;
using Credit_Card_Management_System.Repository;

namespace XUnitTesting
{
    public class UnitTesting
    {
        ApplicationController appControler;
        [Fact]
        public void AddNewApplication()
        {
            var expectedValue = "1";
            Application appln = new Application();
            
            appln.EmailId = "rejith.suseelan@gmail.com";
            appln.MobileNumber = "9600046575";
            appln.FirstName = "Rejith";
            appln.LastName = "Suseelan";
            appln.FatherName = "Suseelan";
            appln.FatherLastName = "P";
            appln.DateOfBirth = "10/05/1985";
            appln.MaritalStatus = 1;
            appln.Citizenship = 1;

            appln.Pancard = "AQXPR9697R";
            appln.Profession = 1;
            appln.CompanyName = "Test";
            appln.Designation = "Senior Techleader";
            appln.AnnualIncome = 1800000;
            appln.MonthlyIncome = 130000;

            appln.CorporateEmailId = "rejith.suseelan@hcl.com";
            appln.Area = "pallawaram";
            appln.HouseNo = "MapleS2";
            appln.Street = "NarasimhanNager";
            appln.Landmark = "Near SBI Bank";
            appln.City = "Chennai";

            appln.Pincode = "600074";
            appln.IsTermsAndCondition =true;
            appln.CardName = "Rejith S";
            appln.CardStatus = 1;
            appln.StatusUpdatedDate = DateTime.Today.Date;
            var result = appControler.AddApplication(appln);
            Assert.Equal(expectedValue, result.ToString());
        }
        [Fact]
        public void UpdateApplicationStatus()
        {
            UpdateApplicationInput updateAppnInput = new UpdateApplicationInput
             {
              ApplicationId=1001,
              CardStatus=1
             };
            var updateexpectedValue = "1";

            var result = appControler.UpdateApplicationStatus(updateAppnInput);
            Assert.Equal(updateexpectedValue, result.ToString());
        }
        [Fact]
        public void UpdateConsignmentStatus()
        {
            var updateexpectedStatus = "1";
            ConsignamentInput consignInput = new ConsignamentInput();
            consignInput.ApplicationId = 1001;
            consignInput.CourierName = "DTDC";
            consignInput.CardStatus = 1;
            consignInput.TrackingNumber = "DTDC10010110";
             var updateResult=  appControler.UpdateConsignmentStatus(consignInput);
            Assert.Equal(updateexpectedStatus, updateResult.ToString());
        }
        
             [Fact]
        public void CourierLog()
        {
            CourierLog courierLog = new CourierLog();
            courierLog.ApplicationId = 1001;
            courierLog.StatusId = 1;
            courierLog.Updatedate = DateTime.Today.Date;
           var courierLogResult= appControler.CourierLog(courierLog);

            var expectedCourierLog = "1";
            Assert.Equal(expectedCourierLog, courierLogResult.ToString());
        }
        [Fact]
        public void GetApplicationById()
        {
            string applicationresultData = null;
            string expectedApplicationData = "Data";
            var applicationOutput = appControler.GetApplicationById(1001);
            if (!string.IsNullOrEmpty(applicationOutput.ToString()))
                applicationresultData = "Data";
            else
                applicationresultData = "";
            Assert.Equal(expectedApplicationData, applicationresultData);
        }
        [Fact]
        public void GetCategories()
        {
            string categoriesresultData = null;
            string expectedCategoriesData = "Data";
            var applicationOutput = appControler.GetCategories();
            if (!string.IsNullOrEmpty(applicationOutput.ToString()))
                categoriesresultData = "Data";
            else
                categoriesresultData = "";
            Assert.Equal(expectedCategoriesData, categoriesresultData);
        }
        
    }
}

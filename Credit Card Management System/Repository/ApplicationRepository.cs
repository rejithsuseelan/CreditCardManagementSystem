using Credit_Card_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Credit_Card_Management_System.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {

        CCMSDBContext db;
        public ApplicationRepository(CCMSDBContext _db)
        {
            db = _db;
        }

        public async Task<decimal> AddApplication(Application application)
        {
            if (db != null)
            {
                await db.Applications.AddAsync(application);
                await db.SaveChangesAsync();

                return application.ApplicationId;
            }

            return 0;
        }

        public async Task<List<Application>> GetApplications()
        {
            if (db != null)
            {
                return await db.Applications.ToListAsync();
            }

            return null;
        }

        public ApplicationOutput GetApplicationById(decimal id)
        {
            if (db != null)
            {
                var filteredApp = db.Applications.Where(app => app.ApplicationId == id).FirstOrDefault();
                if (filteredApp != null)
                {
                    ApplicationOutput application = new ApplicationOutput();
                    application.AnnualIncome = filteredApp.AnnualIncome;
                    application.ApplicationId = filteredApp.ApplicationId;
                    application.Area = filteredApp.Area;
                    application.CardName = filteredApp.CardName;
                    application.CardStatus = filteredApp.CardStatus;
                    application.City = filteredApp.City;
                    application.CompanyName = filteredApp.CompanyName;
                    application.CorporateEmailId = filteredApp.CorporateEmailId;
                    application.CourierName = filteredApp.CourierName;
                    application.DateOfBirth = filteredApp.DateOfBirth;
                    application.Designation = filteredApp.Designation;
                    application.EmailId = filteredApp.EmailId;
                    application.FatherName = filteredApp.FatherName + " " + filteredApp.FatherLastName;
                    application.ApplicantName = filteredApp.FirstName + " " + filteredApp.LastName;
                    application.HouseNo = filteredApp.HouseNo;
                    application.IsShipped = filteredApp.IsShipped;
                    application.IsTermsAndCondition = filteredApp.IsTermsAndCondition;
                    application.Landmark = filteredApp.Landmark;
                    application.MobileNumber = filteredApp.MobileNumber;
                    application.MonthlyIncome = filteredApp.MonthlyIncome;
                    application.Pancard = filteredApp.Pancard;
                    application.Pincode = filteredApp.Pincode;
                    application.StatusUpdatedDate = filteredApp.StatusUpdatedDate;
                    application.Street = filteredApp.Street;
                    application.TrackingNumber = filteredApp.TrackingNumber;

                    application.CourierLogs = db.CourierLogs
                        .Where(c => c.ApplicationId == id)
                        .Join(db.StandardValues, e => e.StatusId, d => d.Id, (e, d) => new CourierLogs {
                         Updatedate =  e.Updatedate,
                         Status = d.Value
                    }).ToList();

                    application.Citizenship = db.StandardValues.Where(value => value.Id == filteredApp.Citizenship).FirstOrDefault().Value;
                    application.Profession = db.StandardValues.Where(value => value.Id == filteredApp.Profession).FirstOrDefault().Value;
                    application.MaritalStatus = db.StandardValues.Where(value => value.Id == filteredApp.MaritalStatus).FirstOrDefault().Value;

                    return application;
                }
            }

            return null;
        }


        public async Task UpdateApplication(Application post)
        {
            if (db != null)
            {
                //Delete that post
                db.Applications.Update(post);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }

        public async Task UpdateApplicationStatus(decimal applicationId, int? statusId)
        {
            if (db != null)
            {
                var post = db.Applications.Where(app => app.ApplicationId == applicationId).FirstOrDefault();
                if (post != null)
                {
                    post.CardStatus = statusId;
                    post.StatusUpdatedDate = DateTime.UtcNow;

                    //Delete that post
                    db.Applications.Update(post);

                    //Commit the transaction
                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task UpdateConsignmentStatus(ConsignamentInput input)
        {
            if (db != null)
            {
                var post = db.Applications.Where(app => app.ApplicationId == input.ApplicationId).FirstOrDefault();
                if (post != null)
                {
                    post.CourierName = input.CourierName;
                    post.IsShipped = true;
                    post.TrackingNumber = input.TrackingNumber;
                    post.CardStatus = input.CardStatus;

                    //Delete that post
                    db.Applications.Update(post);

                    //Commit the transaction
                    await db.SaveChangesAsync();

                    CourierLog cLog = new CourierLog();
                    cLog.ApplicationId = input.ApplicationId;
                    cLog.StatusId = input.CardStatus;

                    await ApplicationCourierLog(cLog);

                }
            }
        }

        public async Task<decimal> CourierLog(CourierLog input)
        {
            if (db != null)
            {

                var post = db.Applications.Where(app => app.ApplicationId == input.ApplicationId).FirstOrDefault();
                if (post != null)
                {
                    post.CardStatus = input.StatusId;

                    //Delete that post
                    db.Applications.Update(post);

                    //Commit the transaction
                    await db.SaveChangesAsync();

                    await ApplicationCourierLog(input);
                    return input.LogId;
                }
            }

            return 0;
        }

        private async Task ApplicationCourierLog(CourierLog Input)
        {
            Input.Updatedate = DateTime.Now;
            await db.CourierLogs.AddAsync(Input);
            await db.SaveChangesAsync();
        }

    }
}



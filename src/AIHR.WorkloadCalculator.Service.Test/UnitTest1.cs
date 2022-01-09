using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AIHR.WorkloadCalculator.Service.Controllers;
using AIHR.WorkloadCalculator.Service.Data;
using AIHR.WorkloadCalculator.Service.Models;
using AIHR.WorkloadCalculator.Service.Services;
using AIHR.WorkloadCalculator.Service.Services.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;

namespace AIHR.WorkloadCalculator.Service.Test
{

    public class WorkloadCalculatorServiceFake : IWorkloadCalculatorService
    {
        private readonly List<Course> _courses;
        public WorkloadCalculatorServiceFake()
        {
            _courses = new List<Course>(Seed.Courses);
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return _courses;
        }

        #region This Members not required for testing
        public Task<IEnumerable<WorkloadCalculateHistory>> GetAllSavedWorkloadCalculationsAsync()
        {
            throw new NotImplementedException();
        }


        #endregion


        public async Task<WorkloadCalculateHistory> WorkloadCalculate(WorkloadCalculateRequest request)
        {
            var qry = _courses.Where(c => request.CourseIds.Contains(c.Id))
                .Select(c => new WorkloadCalculationCourse(c.Name, c.Duration)).ToList();

            var totalHours = qry.Sum(c => c.Duration);
            var workingDays = (request.EndDate - request.StartDate).Days;
            var res = new WorkloadCalculateHistory { Courses = qry, StartDate = request.StartDate, EndDate = request.EndDate, RequestTime = DateTime.Now, SuggestedDailyStudyHours = totalHours / workingDays };
            return res;
        }
    }

    public class CalculationTests
    {
        [Fact]
        public void calculation_test()
        {
            //Arrange
            var service = new WorkloadCalculatorServiceFake();
            var req1  =new WorkloadCalculateRequest(new[] { 1 }, new DateTime(2022, 01, 01), new DateTime(2022, 01, 02));
            var req2 = new WorkloadCalculateRequest(new[] {1, 2}, new DateTime(2022, 01, 01), new DateTime(2022, 01, 03));
            var req3 = new WorkloadCalculateRequest(new[] { 1, 3, 5 }, new DateTime(2022, 01, 01), new DateTime(2022, 01, 10));
            var req4 = new WorkloadCalculateRequest(new[] { 1, 5, 6 }, new DateTime(2022, 01, 01), new DateTime(2022, 01, 20));
            var req5 = new WorkloadCalculateRequest(new[] { 10, 11, 12, 5}, new DateTime(2022, 01, 01), new DateTime(2022, 01, 15));


            //Act
            var res1 = service.WorkloadCalculate(req1);
            var res2 = service.WorkloadCalculate(req2);
            var res3 = service.WorkloadCalculate(req3);
            var res4 = service.WorkloadCalculate(req4);
            var res5 = service.WorkloadCalculate(req5);


            //Assert
            Assert.Equal(8,res1.Result.SuggestedDailyStudyHours);
            Assert.Equal(20, res2.Result.SuggestedDailyStudyHours);
            Assert.Equal(6, res3.Result.SuggestedDailyStudyHours);
            Assert.Equal(1, res4.Result.SuggestedDailyStudyHours);
            Assert.Equal(6, res5.Result.SuggestedDailyStudyHours);
        }
    }
}
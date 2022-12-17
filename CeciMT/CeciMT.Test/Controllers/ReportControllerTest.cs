﻿using CeciMT.Domain.Interfaces.Service;
using CeciMT.Test.Fakers.Commons;
using CeciMT.Test.Fakers.User;
using CeciMT.WebApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CeciMT.Test.Controllers
{
    public class ReportControllerTest
    {
        private readonly Moq.Mock<IReportService> _mockReportService;

        public ReportControllerTest()
        {
            _mockReportService = new Moq.Mock<IReportService>();
        }

        [Fact]
        public async Task Generate_users_report()
        {
            //Arrange
            var arrayBytes = Array.Empty<byte>();
            var userFilterDto = UserFaker.UserFilterDTO().Generate();
            var resultResponse = ResultResponseFaker.ResultResponseData<byte[]>(arrayBytes, It.IsAny<HttpStatusCode>());

            _mockReportService.Setup(x => x.GenerateUsersReport(userFilterDto))
                .ReturnsAsync(resultResponse);

            var reportController = ReportControllerConstrutor();

            //Act
            var result = await reportController.GenerateUsersReport(userFilterDto);

            //Assert
            Assert.IsType<FileStreamResult>(result);
        }

        [Fact]
        public async Task Generate_users_report_null()
        {
            //Arrange
            var arrayBytes = Array.Empty<byte>();
            var userFilterDto = UserFaker.UserFilterDTO().Generate();
            var resultResponse = ResultResponseFaker.ResultResponseData<byte[]>(null, It.IsAny<HttpStatusCode>());

            _mockReportService.Setup(x => x.GenerateUsersReport(userFilterDto))
                .ReturnsAsync(resultResponse);

            var reportController = ReportControllerConstrutor();

            //Act
            var result = await reportController.GenerateUsersReport(userFilterDto);

            //Assert
            Assert.IsType<ObjectResult>(result);
        }

        private ReportController ReportControllerConstrutor()
        {
            return new ReportController(_mockReportService.Object);
        }
    }
}

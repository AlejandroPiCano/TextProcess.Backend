using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TextProcess.Backend.API.Controllers;
using TextProcess.Backend.Application.DTOs;
using TextProcess.Backend.Application.Services;

namespace TextProcess.Backend.API.Tests
{
    /// <summary>
    /// The OrderOptionsController Tests.
    /// </summary>
    public class OrderOptionsControllerTest
    {
        #region MemberData
        public static IEnumerable<object[]> PostOrderedTextData =>
            new List<object[]>
            {
                new object[] { "yellow red blue", OrderOptionDTO.AlphabeticAsc, new List<string>() { "blue", "red", "yellow" } },
                new object[] { "one four ten elven", OrderOptionDTO.AlphabeticDesc, new List<string>() { "elven", "four", "one", "ten" } },
                new object[] { "one do array largeword", OrderOptionDTO.LenghtAsc, new List<string>() { "do", "one", "array", "largeword" } }
            };

        public static IEnumerable<object[]> PostStatisticsData =>
            new List<object[]>
            {
            new object[] { "yellow red blue", new TextStatisticsDTO(0,3,2)},
            new object[] { "one four ten elven-",  new TextStatisticsDTO(1,4,3)},
            };

        public static IEnumerable<object[]> PostException =>
          new List<object[]>
          {
            new object[] { new Exception("An error occurred while processing the text"), StatusCodes.Status500InternalServerError,  "An error occurred while processing the text"  },
            new object[] { new ArgumentException("Argument textToAnalize is null or empty"), StatusCodes.Status400BadRequest, "Argument textToAnalize is null or empty" },
          };

        #endregion

        [Theory, MemberData(nameof(PostOrderedTextData))]
        public void Post_OrderedText_ReturnsExpectedResult(string inputText, OrderOptionDTO orderOption, List<string> expectedResult)
        {
            // Arrange
            var orderOptionsService = new Mock<IOrderOptionsService>();

            var orderProcessApplicationService = new Mock<IOrderProcessApplicationService>();

            orderProcessApplicationService.Setup(x => x.GetOrderedText(inputText, orderOption)).Returns(expectedResult);

            var logger = new Mock<ILogger<TextProcessController>>();
            var sut = new TextProcessController(orderOptionsService.Object, orderProcessApplicationService.Object, logger.Object);

            // Act
            var result = sut.Post(inputText, orderOption);

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>();
            (result.Result as OkObjectResult).Value.Should().Be(expectedResult);
        }

        [Theory, MemberData(nameof(PostException))]
        public void Post_OrderedText_ThrowsAnException(Exception expectedException, int expectedStatusCode, string expectedMessageException)
        {
            // Arrange
            string textToOrder = null;
            OrderOptionDTO orderOption = OrderOptionDTO.AlphabeticAsc;

            var orderOptionsService = new Mock<IOrderOptionsService>();

            var mockOrderProcessApplicationService = new Mock<IOrderProcessApplicationService>();
            mockOrderProcessApplicationService
                .Setup(x => x.GetOrderedText(textToOrder, orderOption))
                .Throws(expectedException);

            var mockLogger = new Mock<ILogger<TextProcessController>>();

            var sut = new TextProcessController(orderOptionsService.Object, mockOrderProcessApplicationService.Object, mockLogger.Object);

            // Act
            var result = sut.Post(textToOrder, orderOption);

            // Assert
            var objectResult = result.Result as ObjectResult;
            objectResult.StatusCode.Should().Be(expectedStatusCode);
            objectResult.Value.Should().Be(expectedMessageException);
        }


        [Theory, MemberData(nameof(PostStatisticsData))]
        public void Post_Statistics_ReturnsExpectedResult(string inputText, TextStatisticsDTO expectedResult)
        {
            // Arrange
            var orderOptionsService = new Mock<IOrderOptionsService>();

            var orderProcessApplicationService = new Mock<IOrderProcessApplicationService>();
            orderProcessApplicationService.Setup(x => x.GetStatistics(inputText)).Returns(expectedResult);

            var logger = new Mock<ILogger<TextProcessController>>();

            var sut = new TextProcessController(orderOptionsService.Object, orderProcessApplicationService.Object, logger.Object);

            // Act
            var result = sut.Post(inputText);

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>();
            (result.Result as OkObjectResult).Value.Should().Be(expectedResult);
        }

        [Theory, MemberData(nameof(PostException))]
        public void Post_Statistics_ThrowsAnException(Exception expectedException, int expectedStatusCode, string expectedMessageException)
        {
            // Arrange
            string textToAnalize = null;
            var orderOptionsService = new Mock<IOrderOptionsService>();

            var mockOrderProcessApplicationService = new Mock<IOrderProcessApplicationService>();
            mockOrderProcessApplicationService
                .Setup(x => x.GetStatistics(textToAnalize))
                .Throws(expectedException);

            var mockLogger = new Mock<ILogger<TextProcessController>>();

            var sut = new TextProcessController(orderOptionsService.Object, mockOrderProcessApplicationService.Object, mockLogger.Object);

            // Act
            var result = sut.Post(textToAnalize);

            // Assert
            var objectResult = result.Result as ObjectResult;
            objectResult.StatusCode.Should().Be(expectedStatusCode);
            objectResult.Value.Should().Be(expectedMessageException);
        }

        [Fact]
        public async Task Get_OrderOptions_ReturnsExpectedResult()
        {
            // Arrange
            var expectedResult = new List<string> { "option1", "option2" };
            var orderOptionsService = new Mock<IOrderOptionsService>();
            orderOptionsService.Setup(x => x.GetOrderOptions()).ReturnsAsync(expectedResult);
            var orderProcessApplicationService = new Mock<IOrderProcessApplicationService>();
            var logger = new Mock<ILogger<TextProcessController>>();
            var sut = new TextProcessController(orderOptionsService.Object, orderProcessApplicationService.Object, logger.Object);

            // Act
            var result = await sut.Get();

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>();
            (result.Result as OkObjectResult).Value.Should().Be(expectedResult);
        }

        [Fact]
        public async Task Get_OrderOptions_ThrowsAnException()
        {
            // Arrange
            int expectedStatusCode = StatusCodes.Status500InternalServerError;
            string expectedMessageException = "An error occurred while getting the options";
            var orderOptionsService = new Mock<IOrderOptionsService>();
            orderOptionsService.Setup(x => x.GetOrderOptions())
                .Throws(new Exception(expectedMessageException));

            var orderProcessApplicationService = new Mock<IOrderProcessApplicationService>();

            var logger = new Mock<ILogger<TextProcessController>>();
            var sut = new TextProcessController(orderOptionsService.Object, orderProcessApplicationService.Object, logger.Object);

            // Act
            var result = await sut.Get();

            // Assert
            var objectResult = result.Result as ObjectResult;
            objectResult.StatusCode.Should().Be(expectedStatusCode);
            objectResult.Value.Should().Be(expectedMessageException);
        }
    }
}
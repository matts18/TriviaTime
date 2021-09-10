using System;
using Xunit;
using Moq;
using TriviaTime.Controllers;
using TriviaTime.Services;
using TriviaTime.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TriviaTimeTests
{
    public class TriviaControllerTests
    {
        [Fact]
        public async Task GetQuestions_Returns_The_Correct_Amount_Of_Questions()
        {
            // Arrange
            int count = 5;
            var mockQuestionService = new Mock<ITriviaService>();
            mockQuestionService.Setup(service => service.GetQuestions(count))
                .ReturnsAsync(GetTestQuestions(count));
            var controller = new TriviaController(mockQuestionService.Object);

            // Act
            var actionResult = await controller.Get(count);

            // Assert
            var result = actionResult as OkObjectResult;
            var data = result.Value as TriviaQuestionResultsModel;
            Assert.Equal(count, data.Results.Count());
                    
        }

        [Fact]
        public async Task GetMultipleQuestions_Returns_400_For_Invalid_Question_Amount()
        {
            // Arrange
            int count = 11;
            int lowCount = 0;
            var mockQuestionService = new Mock<ITriviaService>();
            mockQuestionService.Setup(service => service.GetQuestions(count))
                .ReturnsAsync(GetTestQuestions(count));
            var controller = new TriviaController(mockQuestionService.Object);

            // Act
            var actionResult = await controller.Get(count);
            var actionResultLow = await controller.Get(lowCount);

            // Assert
            Assert.IsType<BadRequestObjectResult>(actionResult);
            Assert.IsType<BadRequestObjectResult>(actionResultLow);
            

        }

        private TriviaQuestionResultsModel GetTestQuestions(int count)
        {
            var questions = new List<TriviaQuestionModel>();
            for(int i = 0; i < count; i++)
            {
                questions.Add(new TriviaQuestionModel());
            }
            var resultsModel = new TriviaQuestionResultsModel() { Results = questions };
            return resultsModel;
        }
    }
}

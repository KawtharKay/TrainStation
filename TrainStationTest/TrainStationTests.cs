using Application.Commands;
using Application.Repositories;
using Moq;

namespace TrainStationTest
{
    public class TrainStationTests
    {
        [Fact]
        public void Return_True_If_Train_Exist()
        {
            // Arrange
            var mockRepository = new Mock<ITrainRepository>();
            mockRepository.Setup(a => a.IsExist("KK/001")).Returns(Task.FromResult(true));
           // var registerTrain = new RegisterTrain(mockRepository.Object);
        }
    }
}

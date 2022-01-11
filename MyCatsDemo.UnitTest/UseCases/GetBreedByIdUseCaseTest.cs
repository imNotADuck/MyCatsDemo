using System;
using System.Threading.Tasks;
using Moq;
using MyCatsDemo.Api.Contract;
using MyCatsDemo.Api.Service;
using MyCatsDemo.Api.UseCases;
using NUnit.Framework;

namespace MyCatsDemo.UnitTest.UseCases
{
    public class GetBreedByIdUseCaseTest : AbstractTest<GetBreedByIdUseCase>
    {
        private readonly Mock<ICatService> _mockICatsService = new Mock<ICatService>();
        protected override GetBreedByIdUseCase GetImp()
        {
            return new GetBreedByIdUseCase(
                _mockICatsService.Object);
        }

        [Test]
        public async Task CatBreedItemMapper_Test()
        {
            // Arrange
            var mockDataSet = new CatBreedDetailDto[]
            {
                new CatBreedDetailDto()
                {
                    url = "url-1",
                    breeds = new CatBreedDetailInfoDTO()[]
                    {
                        id = "breed-1",
                        description = "blabla",
                        name = "name"
                    },
                }
            };
            _mockICatsService.Setup(x => x.GetCatBreeds())
                .ReturnsAsync(mockDataSet);

            // Act
            var result = await Imp.Execute(null);

            // Assert
            Assert.AreEqual(mockDataSet.Length, result.Length);

            for (int i = 0; i < mockDataSet.Length; i++)
            {
                var mockItem = mockDataSet[i];
                var apiItem = result[i];

                Assert.AreEqual(mockItem.id, apiItem.Id);
                Assert.AreEqual(mockItem.name, apiItem.Name);
                Assert.AreEqual(mockItem.Image?.url, apiItem.ImageUrl);
            }
        }
    }
}
}

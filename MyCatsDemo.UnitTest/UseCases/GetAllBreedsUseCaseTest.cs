using System;
using System.Threading.Tasks;
using Moq;
using MyCatsDemo.Api.Contract;
using MyCatsDemo.Api.Service;
using MyCatsDemo.Api.UseCases;
using NUnit.Framework;

namespace MyCatsDemo.UnitTest.UseCases
{
    public class GetAllBreedUseCaseTest : AbstractTest<GetAllBreedsUseCase>
    {
        private readonly Mock<ICatService> _mockICatsService = new Mock<ICatService>();
        protected override GetAllBreedsUseCase GetImp()
        {
            return new GetAllBreedsUseCase(
                _mockICatsService.Object);
        }

        [Test]
        public async Task CatBreedItemMapper_Test()
        {
            // Arrange
            var mockDto = new CatBreedDto[]
            {
                new CatBreedDto()
                {
                    id = "cat-1",
                    name = "name-1",
                    Image = new CatBreedImageDTO()
                    {
                        url = "url-1"
                    }
                },
                new CatBreedDto()
                {
                    id = "cat-2",
                    name = "name-2",
                    Image = new CatBreedImageDTO()
                    {
                        url = "url-2"
                    }
                },
            };
            _mockICatsService.Setup(x => x.GetCatBreeds())
                .ReturnsAsync(mockDto);

            // Act
            var result = await Imp.Execute(null);

            // Assert
            Assert.AreEqual(mockDto.Length, result.Length);

            for (int i = 0; i < mockDto.Length; i++)
            {
                var mockItem = mockDto[i];
                var apiItem = result[i];

                Assert.AreEqual(mockItem.id, apiItem.Id);
                Assert.AreEqual(mockItem.name, apiItem.Name);
                Assert.AreEqual(mockItem.Image?.url, apiItem.ImageUrl);
            }
        }
    }
}

using System;
using System.Threading.Tasks;
using Moq;
using MyCatsDemo.Api.UseCases;
using MyCatsDemo.Models.Cat;
using MyCatsDemo.Services.Interfaces;
using MyCatsDemo.ViewModels;
using NUnit.Framework;

namespace MyCatsDemo.UnitTest.ViewModels
{
    public class CatDetailsViewModelTest : AbstractTest<CatDetailViewModel>
    {
        private Mock<IGetBreedByIdUseCase> _mockIGetBreedByIdUseCase;
        private Mock<INavigationService> _mockINavigationService;

        protected override CatDetailViewModel GetImp()
        {
            _mockIGetBreedByIdUseCase = new Mock<IGetBreedByIdUseCase>();
            _mockINavigationService = new Mock<INavigationService>();
            return new CatDetailViewModel(_mockIGetBreedByIdUseCase.Object, _mockINavigationService.Object);
        }

        [Test]
        public async Task ReloadDataSuccess_Test()
        {
            // Arrange
            var catData = new CatBreedDetail()
            {
                Description = "Description test",
                Name = "Name test"
            };

            _mockIGetBreedByIdUseCase.Setup(x => x.Execute(It.IsAny<IGetBreedByIdUseCase.Param>()))
                .ReturnsAsync(catData);

            // Act
            await Imp.LoadData();

            Assert.False(Imp.IsBusy);
            Assert.False(Imp.LoadingError);
            Assert.AreSame(catData, Imp.Cat);
        }

        [Test]
        public async Task ReloadDataFailed_Test()
        {
            // Arrange
            _mockIGetBreedByIdUseCase.Setup(x => x.Execute(It.IsAny<IGetBreedByIdUseCase.Param>()))
                .ThrowsAsync(new Exception());

            // Act
            await Imp.LoadData();

            Assert.False(Imp.IsBusy);
            Assert.True(Imp.LoadingError);
        }
    }
}

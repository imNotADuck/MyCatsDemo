using System;
using System.Linq;
using System.Threading.Tasks;
using MyCatsDemo.Api.Contract;
using MyCatsDemo.Api.Service;
using MyCatsDemo.Models.Cat;
using MyCatsDemo.Services.Interfaces;

namespace MyCatsDemo.Api.UseCases
{
    public interface IGetAllBreedsUseCase : IAsyncUseCase<object, CatBreedItem[]>
    {
    }

    public class GetAllBreedsUseCase : AsyncUseCase<object, CatBreedItem[]>, IGetAllBreedsUseCase
    {
        private readonly ICatService _catService;

        public GetAllBreedsUseCase(ICatService catService)
        {
           _catService = catService;
        }

        public override async Task<CatBreedItem[]> Execute(object obj)
        {
            var items = await _catService.GetCatBreeds();

            var result = items.Select(CatBreedItemMapper).ToArray();
            return result;
        }

        private CatBreedItem CatBreedItemMapper(CatBreedDto dto)
        {
            return new CatBreedItem()
            {
                Id = dto.id,
                Name = dto.name,
                ImageUrl = dto.Image?.url
            };
        }
    }
}

using System;
using System.Threading.Tasks;
using MyCatsDemo.Api.Contract;
using MyCatsDemo.Api.Service;
using MyCatsDemo.Models.Cat;
using MyCatsDemo.Services.Interfaces;

namespace MyCatsDemo.Api.UseCases
{
    public interface IGetBreedByIdUseCase : IAsyncUseCase<IGetBreedByIdUseCase.Param, CatBreedDetail>
    {
        public class Param
        {
            public string CatId { get; set; }
        }
    }

    public class GetBreedByIdUseCase : AsyncUseCase<IGetBreedByIdUseCase.Param, CatBreedDetail>, IGetBreedByIdUseCase
    {
        private readonly ICatService _catService;

        public GetBreedByIdUseCase(ICatService catService)
        {
            _catService = catService;
        }

        public override async Task<CatBreedDetail> Execute(IGetBreedByIdUseCase.Param args)
        {
            if (args.CatId == "abys")
            {
                throw new Exception("Failed on purpose");
            }
            var item = await _catService.GetCatBreedById(args.CatId);

            var result = CatBreedDetailMapper(item);
            return result;
        }

        private CatBreedDetail CatBreedDetailMapper(CatBreedDetailDto dto)
        {
            var breed = dto.breeds[0];
            return new CatBreedDetail()
            {
                Id = breed.id,
                Name = breed.name,
                Description = breed.description,
                ImageUrl = dto.url
            };
        }
    }
}

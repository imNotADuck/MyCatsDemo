using System;
using System.Threading.Tasks;
using MyCatsDemo.Api.Contract;

namespace MyCatsDemo.Api.Service
{
    public interface ICatService
    {
        Task<CatBreedDto[]> GetCatBreeds();

        Task<CatBreedDetailDto> GetCatBreedById(string id);
    }
}

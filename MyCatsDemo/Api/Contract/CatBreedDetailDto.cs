using System;
namespace MyCatsDemo.Api.Contract
{
    public class CatBreedDetailDto
    {
        public string url { get; set; }

        public CatBreedDetailInfoDTO[] breeds { get; set; }
    }

    public class CatBreedDetailInfoDTO
    {
        public string id { get; set; }

        public string name { get; set; }

        public string description { get; set; }
    }
}

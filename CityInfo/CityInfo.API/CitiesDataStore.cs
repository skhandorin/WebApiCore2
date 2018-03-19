using CityInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "Shbfsb fbsf ibf ew."
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "Gdhjbfejhbfe fek fe kewewkjnf jfknjew."
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Paris",
                    Description = "Qclefn fnslk nfelfnbf ew."
                }
            };
        }
    }
}

using CityInfo.API.Services;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace CityInfo.API.Controllers
{
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        private ICityInfoRepository _cityInfoRepository;

        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            //return Ok(CitiesDataStore.Current.Cities);
            var cityEntities = _cityInfoRepository.GetCities();

            var results = Mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities);

            return Ok(results);

            //var results = new List<CityWithoutPointsOfInterestDto>();
            //foreach (var cityEntity in cityEntities)
            //{
            //    results.Add(new CityWithoutPointsOfInterestDto()
            //    {
            //        Id = cityEntity.Id,
            //        Description = cityEntity.Description,
            //        Name = cityEntity.Name
            //    });
            //}
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointsOfInterest = false)
        {
            var city = _cityInfoRepository.GetCity(id, includePointsOfInterest);

            if (city == null)
                return NotFound();

            if (includePointsOfInterest)
            {
                //var cityResult = new CityDto()
                //{
                //    Id = city.Id,
                //    Name = city.Name,
                //    Description = city.Description
                //};

                //foreach (var poi in city.PointsOfInterest)
                //{
                //    cityResult.PointsOfInterest.Add(
                //        new PointOfInterestDto()
                //        {
                //            Id = poi.Id,
                //            Name = poi.Name,
                //            Description = poi.Description
                //        });
                //}

                var cityResult = Mapper.Map<CityDto>(city);

                return Ok(cityResult);
            }

            //var cityWithoutPointsOfInterestResult = new CityWithoutPointsOfInterestDto()
            //{
            //    Id = city.Id,
            //    Name = city.Name,
            //    Description = city.Description
            //};

            var cityWithoutPointsOfInterestResult = Mapper.Map<CityWithoutPointsOfInterestDto>(city);

            return Ok(cityWithoutPointsOfInterestResult);

            //var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            //if (cityToReturn == null)
            //    return NotFound();

            //return Ok(cityToReturn);

        }
    }
}

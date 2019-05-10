using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SehirRehberi.API.Data;
using SehirRehberi.API.Dtos;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Controllers
{
    [Route("api/Cities")]
    public class CitiesController : Controller
    {
        private IAppRepository _appRepository;
        private IMapper _mapper;
        public CitiesController(IAppRepository appRepository,IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

        public ActionResult GetCities()
        {
            var cities = _appRepository.GetCities();
            var citiesToReturn = _mapper.Map<List<CityForListDto>>(cities);
              // .Select(c => new CityForListDto { Description=c.Description,Name=c.Name,Id=c.Id,PhotoUrl=c.Photos.FirstOrDefault(p=>p.IsMain==true).Url}).ToList();
            return Ok(citiesToReturn);
        }

        [HttpGet]
        [Route("detail")]
        public ActionResult GetCity(int id)
        {
            var city = _appRepository.GetCity(id);
            var citiesToReturn = _mapper.Map<CityForDetailDto>(city);
            return Ok(citiesToReturn);
        }

        [HttpGet]
        [Route("getPhotosByCity")]
        public ActionResult GetPhotosByCity(int cityId)
        {
            var photos = _appRepository.GetPhotosByCity(cityId);
            return Ok(photos);
        }

        [HttpPost]
        [Route("addCity")]
        public ActionResult Add([FromBody]City City)
        {
            _appRepository.Add(City);
            _appRepository.SaveAll();
            return Ok(City);
        }
    }
}
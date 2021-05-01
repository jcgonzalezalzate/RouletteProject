namespace RouletteProject.ApiRest.Controllers
{
    using Application.Interfaces;
    using Domain.Entities;
    using Domain.Entities.DTO;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    [ApiController]
    [Route("[controller]")]
    public class RouletteController : ControllerBase
    {
        protected readonly IRouletteApplication RouletteApplication;

        public RouletteController(IRouletteApplication rouletteAplication)
        {
            RouletteApplication = rouletteAplication;
        }

        [HttpPost]
        [Route("Create")]
        public GenericResponse<Guid> Create()
        {
            return RouletteApplication.Create();
        }

        [HttpPut]
        [Route("OpenRoulette")]
        public GenericResponse<bool> OpenRoulette(Guid id)
        {
            return RouletteApplication.OpenRoulette(id);
        }
        
        [HttpPut]
        [Route("CloseRoulette")]
        public GenericResponse<Roulette> CloseRoulette(Guid id)
        {
            return RouletteApplication.CloseRoulette(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public GenericResponse<List<Roulette>> GetAll()
        {
            return RouletteApplication.GetAll();
        }
    }
}

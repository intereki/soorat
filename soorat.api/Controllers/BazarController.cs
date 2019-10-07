using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using soorat.api.Data.Dtos.Bazar;
using soorat.api.Data.Interfaces;
using soorat.api.Models;

namespace soorat.api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]

    public class BazarController : ControllerBase
    {
        private readonly IBazar _repo;
        private readonly IMapper _mapper;
        public BazarController(IBazar repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bazars = await _repo.GetAll();

            var bazarsToReturn = _mapper.Map<IEnumerable<Bazar>>(bazars);

            return Ok(bazarsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var bazar = await _repo.Get(id);

            var bazarToReturn = _mapper.Map<Bazar>(bazar);

            return Ok(bazarToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BazarToAdd bazarToAdd)
        {
            Bazar personel = _mapper.Map<Bazar>(bazarToAdd);
            
            _repo.Add(personel);

            if (await _repo.SaveAllAsync())
                return NoContent();
            
            throw new Exception($"افزودن با مشکل مواجه شد");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, BazarToAdd bazarToAdd)
        {
            var bazarFromRepo = await _repo.Get(id);

            _mapper.Map(bazarToAdd, bazarFromRepo);

            if (await _repo.SaveAllAsync())
                return NoContent();
            
            throw new Exception($"به روز رسانی  {id} با مشکل مواجه شد");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var bazarFromRepo = await _repo.Get(id);

            _repo.Delete(bazarFromRepo);

            if (await _repo.SaveAllAsync())
                return NoContent();
            
            throw new Exception($"حذف {id} با مشکل مواجه شد");
        }

    }
}
using Microsoft.AspNetCore.Mvc;
using PerfilBackend.Models;
using PerfilBackend.Data;
using PerfilBackend.Dtos;
using AutoMapper;
using System.Collections.Generic;
using System;

namespace PerfilBackend.Controllers
{
    [Route("api/Perfiles")]
    [ApiController]
    public class PerfilesController : ControllerBase
    {
        private readonly IPerfilRepo _repository;
        private readonly IMapper _mapper;

        public PerfilesController(IPerfilRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("getPerfiles", Name = "GetPerfiles")]
        public ActionResult<IEnumerable<PerfilReadDto>> GetPerfiles()
        {
            Console.WriteLine("--> opteniendo perfiles..");
            var perfilItem = _repository.GetAllPerfiles();

            return Ok(_mapper.Map<IEnumerable<PerfilReadDto>>(perfilItem));
        }
        [HttpGet("getPerfil/{id}", Name = "GetPerfilById")]
        public ActionResult<PerfilReadDto> GetPerfilById(int id)
        {
            var perfilItem = _repository.GetPerfilById(id);
            if (perfilItem != null)
            {
                return Ok(_mapper.Map<PerfilReadDto>(perfilItem));
            }
            return NotFound();
        }

        [HttpPost("createPerfil")]
        public ActionResult<PerfilReadDto> CreatePerfil(PerfilCreateDto perfilCre)
        {
            var perfilModel = _mapper.Map<Perfil>(perfilCre);
            _repository.CreatePerfil(perfilModel);
            _repository.SaveChanges();

            var perfilReadDto = _mapper.Map<PerfilReadDto>(perfilModel);


            return CreatedAtRoute(nameof(GetPerfilById), new { Id = perfilReadDto.Id }, perfilReadDto);
        }
    }
}

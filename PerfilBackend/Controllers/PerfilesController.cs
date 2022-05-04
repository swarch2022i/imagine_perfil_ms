using Microsoft.AspNetCore.Mvc;
using PerfilBackend.Models;
using PerfilBackend.Data;
using PerfilBackend.Dtos;
using AutoMapper;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace PerfilBackend.Controllers
{
    [Route("api/perfiles")]
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
            Console.WriteLine("--> opteniendo perfiles.. 2");
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

        [HttpGet("getPerfilByIdUsuario/{idUsuario}")]
        public ActionResult<PerfilReadDto> GetPerfilBydUsuario(String idUsuario)
        {
            var perfilItem = _repository.GetPerfilByIdUsuario(idUsuario);
            if (perfilItem != null)
            {
                return Ok(_mapper.Map<PerfilReadDto>(perfilItem));
            }
            return NotFound();
        }

        [HttpPost("createPerfil")]
        public ActionResult<PerfilReadDto> CreatePerfil(PerfilCreateDto perfilCre)
        {
            perfilCre.NumfollowBy = 0;
            perfilCre.Numfollowers = 0;
            var perfilModel = _mapper.Map<Perfil>(perfilCre);
            _repository.CreatePerfil(perfilModel);
            _repository.SaveChanges();

            var perfilReadDto = _mapper.Map<PerfilReadDto>(perfilModel);


            return CreatedAtRoute(nameof(GetPerfilById), new { Id = perfilReadDto.Id }, perfilReadDto);
        }

        [HttpPut("putPerfil/{idUsuario}")]
        public ActionResult PutPerfil(string idUsuario,PerfilCreateDto perf)
        {
            var perfilItem = _repository.GetPerfilByIdUsuario(idUsuario);

            if(perfilItem == null){
                return BadRequest();
            }
            Console.WriteLine("-->se encontro al perfil");
            perfilItem.IdImagenPerfil = perf.IdImagenPerfil;
            perfilItem.Nombre = perf.Nombre;
            perfilItem.Texto = perf.Texto;
            perfilItem.NumfollowBy = perf.NumfollowBy;
            perfilItem.Numfollowers = perf.Numfollowers;
            _repository.UpdatePerfil(perfilItem);
            _repository.SaveChanges();
            var perfilReadDto = _mapper.Map<PerfilReadDto>(perfilItem);
            return CreatedAtRoute(nameof(GetPerfilById), new { Id = perfilReadDto.Id }, perfilReadDto);
        }

        [HttpDelete("deletePerfil/{id}")]
        public ActionResult DeletePerfil(int id)
        {
            var perf = _repository.GetPerfilById(id);
            if(perf != null){
                _repository.DeletePerfil(perf);
                _repository.SaveChanges();
                return Ok(_mapper.Map<PerfilReadDto>(perf));
            }
            return NotFound();
        }
    }
}

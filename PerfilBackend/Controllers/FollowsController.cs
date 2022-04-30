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
    [Route("api/follows")]
    [ApiController]
    public class FollowsController : ControllerBase
    {
        private readonly IFollowsRepo _repository;
        private readonly IMapper _mapper;

        public FollowsController(IFollowsRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("getAllFollows", Name = "AllFollows")]
        public ActionResult<IEnumerable<FollowsReadDto>> GetFollows()
        {
            Console.WriteLine("--> opteniendo Follows.. 1");
            var follItem = _repository.GetAllFollows();

            return Ok(_mapper.Map<IEnumerable<FollowsReadDto>>(follItem));
        }
        
        [HttpGet("getFollows/{id}", Name = "GetFollowsById")]
        public ActionResult<FollowsReadDto> GetPerfilById(int id)
        {
            var follItem = _repository.GetFollowsByid(id);
            if (follItem != null)
            {
                return Ok(_mapper.Map<FollowsReadDto>(follItem));
            }
            return NotFound();
        }

        [HttpGet("getAllFollowersById")]
        public ActionResult<IEnumerable<FollowsReadDto>> GetFollowersById(string id)
        {
            Console.WriteLine("--> opteniendo Follows.. 2");
            var follItem = _repository.GetAllFollowersByid(id);
            return Ok(_mapper.Map<IEnumerable<FollowsReadDto>>(follItem));
        }

        [HttpGet("getAllFollowsById")]
        public ActionResult<IEnumerable<FollowsReadDto>> GetFollowsById(string id)
        {
            Console.WriteLine("--> opteniendo Follows.. 3");
            var follItem = _repository.GetAllFollowsByid(id);
            return Ok(_mapper.Map<IEnumerable<FollowsReadDto>>(follItem));
        }

        [HttpPost("createFollow")]
        public ActionResult<FollowsReadDto> CreatePerfil(FollowsCreateDto foll)
        {
            var follModel = _mapper.Map<Follows>(foll);
            _repository.CreateFollows(follModel);
            _repository.SaveChanges();

            var perfilReadDto = _mapper.Map<PerfilReadDto>(follModel);


            return CreatedAtRoute(nameof(GetPerfilById), new { Id = perfilReadDto.Id }, perfilReadDto);
        }

        [HttpDelete("deleteFollows/{id}")]
        public ActionResult<IEnumerable<FollowsReadDto>> deleteFollows(int id)
        {
            Console.WriteLine("-->Usuario a sido borrado");
             var follItem = _repository.GetFollowsByid(id);
             if(follItem != null){
                _repository.DeleteFollows(follItem);
                _repository.SaveChanges();
                return Ok(_mapper.Map<IEnumerable<FollowsReadDto>>(follItem));
             }
            return NotFound();;
        }
        
    }
}
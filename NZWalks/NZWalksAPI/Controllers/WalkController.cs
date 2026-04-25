using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalkController(IMapper mapper,IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

       
        [HttpPost]
        public async Task<IActionResult> CreateWalk(AddWalkRequestDTO addWalkRequestDTO)
        {
            // DTO -> Domain
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDTO);

            // Save and capture returned domain model
            walkDomainModel = await walkRepository.CreateWalkAsync(walkDomainModel);

            // Domain -> Response DTO
            var walkDto = mapper.Map<WalkDTO>(walkDomainModel);

            return Ok(walkDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetWalks()
        {
            var walksdomain = await walkRepository.GetAllWalksAsync();
            return Ok(walksdomain);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetWalksByID([FromRoute] Guid id)
        {
            var domainresponse = await walkRepository.GetWalkByIdAsync(id);

            if(domainresponse==null)
            {
                return NotFound();
            }

            var response = mapper.Map<WalkDTO>(domainresponse);
            //Map domain to dto 
            return Ok(response);


        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkById([FromRoute]Guid id,UpdateWalkRequestDTO updateWalkRequestDTO)
        {
            //Map dto to domain 

            var walkdomain = mapper.Map<Walk>(updateWalkRequestDTO);

            //call repo method 

            var walkdetails = await  walkRepository.UpdateWalkAsync(id, walkdomain);

            if(walkdetails==null)
            {
                return NotFound();
            }

            //Convert domain response to dto

            var response = mapper.Map<Walk>(walkdetails);

            return Ok(response);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWalkById(Guid id)
        {
            var result = await walkRepository.DeleteWalk(id);
            if(result==null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}

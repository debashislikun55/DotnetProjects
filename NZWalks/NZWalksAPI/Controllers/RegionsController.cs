using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _dbcontext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext nZWalksDbContext,IRegionRepository regionRepository,
            IMapper mapper)
        {
            _dbcontext=nZWalksDbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var query = _dbcontext.Region;
            //Console.WriteLine(query);
            //var result = query.ToList();


            //APplying DTO 

            //Fetch data using domain modell
            var domaindata = await regionRepository.GetAllAsync();

            //var regions = new List<RegionsDTO>();

            //convert back to dto 
            //foreach(var region in domaindata)
            //{
            //    regions.Add(new RegionsDTO()
            //    {
            //        Id=region.Id,
            //        name=region.name,
            //        code=region.code
            //    });
            //}
          //  var result = regions.ToList();

            var regions = mapper.Map<List<RegionsDTO>>(domaindata);
            return Ok(regions);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetRegionById(Guid id)
        {
            //Find method only takes the primary key 
            //var region = _dbcontext.Region.Find(id);

            //var region = _dbcontext.Region.FirstOrDefault(x => x.Id == id);
            //if(region==null)
            //{
            //    return NotFound();
            //}



            //Using DTO 

            //fetch data by domain model
            var region = await regionRepository.GetRegionByIDAsync(id);
            if (region == null)
            {
                return NotFound();
            }

            //convert to dto 

            //var regiondto = new RegionsDTO
            //{
            //    Id = region.Id,
            //    code = region.code,
            //    name=region.name
            //};

            var regiondto = mapper.Map<RegionsDTO>(region);


            
            return Ok(regiondto);
        }

        [HttpPost]
        [Route("Createregion")]
        public async Task<IActionResult> CreateRegion([FromBody]AddRegionrequest request)
        {
            //got the request in dto 

            //convert the dto into domain model 

            //Region region = new Region();
            //region.Id = new Guid();
            //region.name = request.name;
            //region.code = request.code;
            //region.RegionImageUrl = request.RegionImageUrl;


            var region= mapper.Map<Region>(request);

            ////Add the data 
            await regionRepository.AddRegionAsync(region);

            ////save 
            //await _dbcontext.SaveChangesAsync();

            //convert back the domain into dto 

            //var regiondtoresponse = new RegionsDTO();

            //regiondtoresponse.code = region.code;
            //regiondtoresponse.name = region.name;
            //regiondtoresponse.Id = region.Id;

            var regiondtoresponse = mapper.Map<RegionsDTO>(region);



            //return the dto 

            return CreatedAtAction(nameof(GetRegionById), new { id = regiondtoresponse.Id }, regiondtoresponse);

        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute]Guid id, [FromBody] AddRegionrequest request)
        {
            //convert the dto into domain model
            var region = new Region
            {
                code = request.code,
                name = request.name,
                RegionImageUrl = request.RegionImageUrl
            };

            //Place the value from dto into model using repository
            var updatedRegion = await regionRepository.UpdateRegionAsync(id, region);
            if(updatedRegion == null)
            {
                return NotFound();
            }

            //return the response in dto
            RegionsDTO result = new RegionsDTO()
            {
                Id = updatedRegion.Id,
                code = updatedRegion.code,
                name = updatedRegion.name
            };

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> RemoveRegion([FromRoute]Guid id)
        {
            var region = await _dbcontext.Region.FirstOrDefaultAsync(x => x.Id == id);
            if(region==null)
            {
                return NotFound();
            }

            _dbcontext.Region.Remove(region);
            await _dbcontext.SaveChangesAsync();

            return Ok(
                new RegionsDTO()
                {
                    Id = region.Id,
                    name=region.name,
                    code=region.code
                }
                );


        }
    }
}

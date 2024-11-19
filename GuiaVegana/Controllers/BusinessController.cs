using AutoMapper;
using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Entities;
using GuiaVegana.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuiaVegana.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessRepository _businessRepository;
        private readonly IMapper _mapper;

        public BusinessController(IBusinessRepository businessRepository, IMapper mapper)
        {
            _businessRepository = businessRepository;
            _mapper = mapper;
        }

        // GET: api/Business
        [HttpGet]
        public IActionResult GetAllBusinesses()
        {
            var businesses = _businessRepository.GetAllBusinesses();
            var businessDtos = _mapper.Map<IEnumerable<BusinessDTO>>(businesses);
            return Ok(businessDtos);
        }

        // GET: api/Business/{id}
        [HttpGet("{id}")]
        public IActionResult GetBusinessById(int id)
        {
            var business = _businessRepository.GetBusinessById(id);
            if (business == null)
            {
                return NotFound(new { Message = "Business not found." });
            }
            var businessDto = _mapper.Map<BusinessDTO>(business);
            return Ok(businessDto);
        }

        // GET: api/Business/plant-based
        [HttpGet("plant-based")]
        public IActionResult GetPlantBasedBusinesses()
        {
            var businesses = _businessRepository.GetPlantBasedBusinesses();
            var businessDtos = _mapper.Map<IEnumerable<BusinessDTO>>(businesses);
            return Ok(businessDtos);
        }

        // GET: api/Business/gluten-free
        [HttpGet("gluten-free")]
        public IActionResult GetGlutenFreeBusinesses()
        {
            var businesses = _businessRepository.GetGlutenFreeBusinesses();
            var businessDtos = _mapper.Map<IEnumerable<BusinessDTO>>(businesses);
            return Ok(businessDtos);
        }

        // GET: api/Business/open
        [HttpGet("open")]
        public IActionResult GetBusinessesOpenNow()
        {
            var currentTime = DateTime.Now;
            var businesses = _businessRepository.GetBusinessesOpenAt(currentTime);
            var businessDtos = _mapper.Map<IEnumerable<BusinessDTO>>(businesses);
            return Ok(businessDtos);
        }

        // GET: api/Business/filter
        [HttpGet("filter")]
        public IActionResult GetBusinessesByFilter(
            [FromQuery] IEnumerable<Rating>? ratings,
            [FromQuery] IEnumerable<DeliveryType>? deliveries,
            [FromQuery] IEnumerable<BusinessType>? businessTypes,
            [FromQuery] IEnumerable<Zone>? zones)
        {
            var businesses = _businessRepository.GetAllBusinesses();

            if (ratings != null && ratings.Any())
                businesses = businesses.Where(b => ratings.Contains(b.Rating));

            if (deliveries != null && deliveries.Any())
                businesses = businesses.Where(b => deliveries.Contains(b.Delivery));

            if (businessTypes != null && businessTypes.Any())
                businesses = businesses.Where(b => businessTypes.Contains(b.BusinessType));

            if (zones != null && zones.Any())
                businesses = businesses.Where(b => zones.Contains(b.Zone));

            var businessDtos = _mapper.Map<IEnumerable<BusinessDTO>>(businesses);
            return Ok(businessDtos);
        }

        // POST: api/Business
        [HttpPost]
        public IActionResult CreateBusiness([FromBody] BusinessToCreateDTO businessToCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid business data." });
            }

            var business = _mapper.Map<Business>(businessToCreateDto);
            _businessRepository.AddBusiness(business);

            var createdBusinessDto = _mapper.Map<BusinessDTO>(business);
            return CreatedAtAction(nameof(GetBusinessById), new { id = createdBusinessDto.Id }, createdBusinessDto);
        }

        // PUT: api/Business
        [HttpPut]
        public IActionResult UpdateBusiness([FromBody] BusinessDTO businessDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid business data." });
            }

            var business = _mapper.Map<Business>(businessDto);
            _businessRepository.UpdateBusiness(business);

            return NoContent();
        }

        // DELETE: api/Business/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBusiness(int id)
        {
            var business = _businessRepository.GetBusinessById(id);
            if (business == null)
            {
                return NotFound(new { Message = "Business not found." });
            }

            _businessRepository.DeleteBusiness(id);
            return NoContent();
        }
    }
}

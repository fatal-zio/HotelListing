using AutoMapper;
using HotelListing.IRepository;
using HotelListing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelListing.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HotelController> _logger;
        private readonly IMapper _mapper;

        public HotelController(IUnitOfWork unitOfWork, ILogger<HotelController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotels()
        {
            try
            {
                var countries = await _unitOfWork.Hotels.GetAll();
                return Ok(_mapper.Map<IList<HotelDto>>(countries));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving countries. Method: {nameof(GetHotels)}. Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotel(int id)
        {
            try
            {
                var hotel = await _unitOfWork.Hotels.Get(o => o.Id == id, new List<string> { "Country" });
                return Ok(_mapper.Map<HotelDto>(hotel));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving countries. Method: {nameof(GetHotel)}. Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }
    }
}

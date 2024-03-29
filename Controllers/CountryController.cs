﻿using AutoMapper;
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
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _unitOfWork.Countries.GetAll();
                return Ok(_mapper.Map<IList<CountryDto>>(countries));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving countries. Method: {nameof(GetCountries)}. Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountry(int id)
        {
            try
            {
                var country = await _unitOfWork.Countries.Get(o => o.Id == id, new List<string> { "Hotels" });
                return Ok(_mapper.Map<CountryDto>(country));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving countries. Method: {nameof(GetCountry)}. Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }
    }
}

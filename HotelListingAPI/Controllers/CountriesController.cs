﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListingAPI.Data;
using HotelListingAPI.Models.Country;
using AutoMapper;
using HotelListingAPI.Contracts;

namespace HotelListingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountriesRepository _countriesRepository;

        public CountriesController(IMapper mapper,ICountriesRepository countriesRepository)
        {
            this._mapper = mapper;
            this._countriesRepository = countriesRepository;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryDetail>>> GetCountries()
        {
          if (_countriesRepository == null)
          {
              return NotFound();
          }
          var countries = await _countriesRepository.GetAllAsync();
            var records = _mapper.Map<List<GetCountryDetail>>(countries);
            return Ok(records);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDetails>> GetCountry(int id)
        {
            var country = await _countriesRepository.GetDetails(id);

            if (_countriesRepository == null)
          {
              return NotFound();
          }

            if (country == null)
            {
                return NotFound();
            }

            var countryDto = _mapper.Map<CountryDetails>(country);

            return Ok(countryDto);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDetail updateCountryDetail)
        {
            if (id != updateCountryDetail.Id)
            {
                return BadRequest();
            }

            var country = await _countriesRepository.GetAsync(id);
            if(country == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCountryDetail,country);

            try
            {
                await _countriesRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDetail createCountryDetail)
        {
          if (_countriesRepository == null)
          {
              return Problem("Entity set 'HotelListingDbContext.Countries'  is null.");
          }
            var country = _mapper.Map<Country>(createCountryDetail);

            await _countriesRepository.AddAsync(country);

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            if (_countriesRepository == null)
            {
                return NotFound();
            }
            var country = await _countriesRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            await _countriesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countriesRepository.Exists(id);
        }
    }
}

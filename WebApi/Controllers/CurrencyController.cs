﻿using Core.DTOs;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CurrencyController : BaseApiController
    {

        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService service)
        {
            _currencyService = service;
        }

        [HttpGet("filtered")]
        
        public async Task<List<CurrencyDTO>> GetFiltered([FromQuery] FilterCurrencyModel filter)
        {
            var currency = await _currencyService.GetFiltered(filter);
            return (currency);
        }

        [HttpPost("/add")]
       
        public async Task<CurrencyDTO> Add([FromBody] CreateCurrencyModel model)
        {
            
            return (await _currencyService.Add(model));
        }




    }
}
using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Book;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    
    public class HomeController : BaseController
    {
        private readonly IBookService _bookservice;
        public HomeController(IBookService bookservice)
        {
            _bookservice = bookservice;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookservice.GetAll());
        }

        [HttpPost]
        [Route("CreateBook")]
        public async Task<IActionResult> Create([FromBody] BookCreateDto bookCreateDto)
        {
            await _bookservice.CreateAsync(bookCreateDto);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateBook/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] BookUpdateDto bookUpdateDto)
        {
            await _bookservice.UpdateAsync(id,bookUpdateDto);
            return Ok();
        }

        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> Search([FromQuery] string search)
        {
            return Ok(await _bookservice.GetAllByConditionAsync(search));
        }

        [HttpGet]
        [Route("Archive")]
        public async Task<IActionResult> Archive(int id)
        {
            await _bookservice.ArchiveAsync(id);
            return Ok();
            
        }

    }
}

using ECommerce.Api.Search.Interfaces;
using ECommerce.Api.Search.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService serachService;

        public SearchController(ISearchService serachService)
        {
            this.serachService = serachService;
        }

        [HttpPost]
        public async Task<IActionResult> SerachAsync(SearchTerm term)
        {
            var result = await serachService.SearchAsync(term.CustomerId);
            if (result.IsSuccess)
            {
                return Ok(result.SerachResults);
            }
            return NotFound();
        }
    }
}

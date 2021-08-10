using DataService.Models.Entities;
using DataService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relax_app.Controllers
{
    [Authorize]
    [Route("sounds")]
    [ApiController]
    public class SoundsController : ControllerBase
    {
        public ISoundService _soundService;

        public SoundsController(ISoundService soundService)
        {
            _soundService = soundService;
        }

        [HttpGet("")]
        public IActionResult Get([FromQuery] int page = 1, [FromQuery] int size = 20)
        {
            List<Sound> sounds = _soundService.Get().Skip((page - 1) * size).Take(size).ToList();
            return Ok(new {
                total = _soundService.Count(),
                page = page,
                size = size,
                data = sounds,
            });
        }

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using kol2.Models.DTO;
using kol2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace kol2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicianController : Controller
    {
        private readonly IService _service;
        public MusicianController(IService service) {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMusicianInfo(int id) {
            var musician = await _service.GetMusicianById(id).FirstOrDefaultAsync();
            if (musician is null)
                return NotFound("Musician with provided id doesnt exist");

            return Ok(
                new MusicianInfo {
                    FirstName = musician.FirstName,
                    LastName = musician.LastName,
                    Nickname = musician.Nickname,
                    Tracks = await _service.GetMusicianTracksById(id)
                        .Select(e => new TrackDTO {
                            Duration = e.Track.Duration,
                            IdMusicAlbum = e.Track.IdMusicAlbum,
                            TrackName = e.Track.TrackName
                        })
                        .OrderBy(e => e.Duration).ToListAsync()
                }
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusician(int id) {
            var musician = await _service.GetMusicianById(id).FirstOrDefaultAsync();
            if (musician is null)
                return NotFound("Musician with provided id doesnt exist");

            if (!await _service.GetMusicianTracksById(id).AllAsync(e => e.Track.IdMusicAlbum == null))
                return BadRequest("Cannot delete given musician because he has tracks on released albums");

            try {
                await _service.DeleteMusician(id);
            } catch (Exception e) {
                return Problem("Something went wrong with deleting musician");
            }

            return NoContent();
        }
    }
}
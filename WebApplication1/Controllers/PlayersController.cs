using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhuiAPIs.Models;
using PhuiAPIs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhuiAPIs.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PlayersController : ControllerBase
  {
    private readonly PlayerService playerService;
    public PlayersController(PlayerService playerService)
    {
      this.playerService = playerService;
    }
    // GET: PlayersController
    [HttpGet]
    public ActionResult<List<Player>> Get()
    {
      return playerService.Get();
    }

    // GET: PlayersController/Details/5
    [HttpGet("{id:length(24)}", Name = "GetPlayer")]
    public ActionResult<Player> Get(string id)
    {
      var player = playerService.Get(id);

      if (player == null)
      {
        return NotFound();
      }

      return player;
    }

    [HttpPost]
    public ActionResult<Player> Create(Player player)
    {
      playerService.Create(player);

      return CreatedAtRoute("GetPlayer", new { id = player.Id.ToString() }, player);
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, Player playerIn)
    {
      var book = playerService.Get(id);

      if (book == null)
      {
        return NotFound();
      }

      playerService.Update(id, playerIn);

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var player = playerService.Get(id);

      if (player == null)
      {
        return NotFound();
      }

      playerService.Remove(player.Id);

      return NoContent();
    }
  }
}

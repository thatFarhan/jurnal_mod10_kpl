using Microsoft.AspNetCore.Mvc;

namespace Modul10_103022400083.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private static List<Game> games = new List<Game>
        {
            new Game{Nama = "Valorant", Developer = "Riot Games", TahunRilis = 2020, Genre = "FPS", Rating = 8.5, Platform = new List<string>{"PC"}, Mode = new List<string>{"Multiplayer"}, IsOnline = true, Harga = 0 },
            new Game{Nama = "GTA V", Developer = "Rockstar Games", TahunRilis = 2013, Genre = "Open World", Rating = 9.5, Platform = new List<string>{"PC", "PS4", "PS5", "Xbox"}, Mode = new List<string>{"Singleplayer", "Multiplayer"}, IsOnline = true, Harga = 300000 },
            new Game{Nama = "The Witcher 3", Developer = "CD Projekt Red", TahunRilis = 2015, Genre = "RPG", Rating = 9.7, Platform = new List<string>{"PC", "PS4", "PS5", "Xbox", "Switch"}, Mode = new List<string>{"Singleplayer"}, IsOnline = false, Harga = 250000 }
        };

        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get()
        {
            return Ok(games);
        }

        [HttpGet("{index}")]
        public IActionResult Get(int index)
        {
            int idx = index - 1;

            if (idx < 0 || idx > games.Count) return NotFound();

            var game = games[idx];

            return Ok(new
            {
                id = index,
                Nama = game.Nama,
                Developer = game.Developer,
                TahunRilis = game.TahunRilis,
                Genre = game.Genre,
                Rating = game.Rating,
                Platform = game.Platform,
                Mode = game.Mode,
                IsOnline = game.IsOnline,
                Harga = game.Harga
            });
        }

        [HttpPost]
        public IActionResult Post([FromBody] Game game)
        {
            games.Add(game);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Game game, int index)
        {
            int idx = index - 1;

            if (idx < 0 || idx > games.Count) return NotFound();

            games[idx] = game;
            return Ok();


        }

        [HttpDelete("idx")]
        public IActionResult Delete(int id)
        {
            int index = id - 1;
            if (index < 0 || index > games.Count) return NotFound();

            games.RemoveAt(index);
            return Ok();
        }
    }
}
using DataBaseDemo.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace DataBaseDemo.Controllers
{
    [ApiController]
    [Route("Test")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("AddStudent")]
        public IActionResult AddStudent(Student student)
        {
            using (MyDbContext context = new MyDbContext())
            {
                context.Database.EnsureCreated();
                context.Add(student);
                int rows = context.SaveChanges();
                if (rows > 0)
                {
                    return Ok(student);
                }
                else { return BadRequest(); }

            }
        }

        [HttpGet("GetStudent")]
        public IActionResult GetStudent()
        {
            using (MyDbContext context = new MyDbContext())
            {
                //context.Database.EnsureCreated();
                var sda = context.Students.ToList();
                
                    return Ok(sda);

            }
        }
    }
}
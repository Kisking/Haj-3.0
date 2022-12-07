using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hajó.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class BoatController : ControllerBase
    {
        [HttpGet]
        [Route("hajo/kerdesek")]
        public IActionResult függvénynév()
        {
            Models.HajosContext hajosContext = new Models.HajosContext();
            var lista = from x in hajosContext.Questions
                        select x.Question1;
            return Ok(lista);
        }

        [HttpGet]
        [Route("hajo/kerdesek/{id}")]
        public IActionResult f2(int id)
        {
            Models.HajosContext hajosContext = new Models.HajosContext();
            var lisa = from x in hajosContext.Questions
                       where x.QuestionId == id
                       select x;

            var lisa2 = hajosContext.Questions.Where(x => x.QuestionId == id);

            return Ok(lisa.FirstOrDefault());
        }

        [HttpGet]
        [Route("questions/{sorszám}")]
        public ActionResult M2(int sorszám)
        {
            Models.HajosContext hajosContext = new Models.HajosContext();
            var kérdés = (from x in hajosContext.Questions
                          where x.QuestionId == sorszám
                          select x).FirstOrDefault();

            if (kérdés == null) return BadRequest("Nincs ilyen sorszámú kérdés");

            return new JsonResult(kérdés);
        }
    }
}

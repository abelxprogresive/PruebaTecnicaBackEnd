using Prueba.Application;
using Prueba.WebApi.Model.Card;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Prueba.Repository;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Prueba.Domain;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using Prueba.Helpers;

namespace Prueba.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        public CardService CardService { get; }        



        public CardController(CardService cardService)
        {
            CardService = cardService;
        }

        public IConfiguration config { get; set; }

        [HttpGet]
        public IActionResult Get()
        {
             var listCards = CardService.ListCards();
             return Ok(listCards);
            
            
        }

        [HttpGet("{id}")]
        public IActionResult GetById(System.Guid id)
        {
            Card objCard = CardService.GetById(id);
            if (objCard == null)
            {
                return NotFound();
            }
            return Ok(objCard);


        }
        [DisableCors]
        [HttpPost]        
        public void Post([FromBody] CreateCardModel card)
        {
            CardService.Create(card.Name, card.Pan, card.Pin);
        }
        [DisableCors]
        [HttpPut("{id}")]
        public IActionResult Put(System.Guid id, [FromBody] Card card)
        {
            Card objCard = CardService.GetById(id);
            if (objCard==null)
            {
                return NotFound();
            }
            
            objCard.Amount = card.Amount + objCard.Amount;
            objCard.Pin = card.Pin;
            CardService.Update(objCard);
            return Ok(objCard);
        }




        [HttpGet("action/download")]
        public FileResult Download()
        {
           return File(Encoding.ASCII.GetBytes(CardService.CsvEncriptedFile()), "text/csv", "encriptedfile.csv");
        }
    }
}

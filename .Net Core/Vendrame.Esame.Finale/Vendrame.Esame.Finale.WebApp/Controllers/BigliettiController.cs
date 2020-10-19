using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vendrame.Esame.Finale.Models;
using Vendrame.Esame.Finale.Service;

namespace Vendrame.Esame.Finale.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BigliettiController : ControllerBase
    {
        private readonly IServiceBiglietto _serviceBiglietto;

        public BigliettiController(IServiceBiglietto serviceBiglietto)
        {
            _serviceBiglietto = serviceBiglietto;
        }

        // GET: api/Biglietti/5
        [HttpGet("{sigla}")]
        public IEnumerable<Biglietto> Get(string sigla)
        {
            return _serviceBiglietto.getBiglietto(sigla);
       }

        // POST: api/Biglietti
        [HttpPost]
        public void Post([FromBody] Biglietto b)
        {
            b.CreationDate = DateTime.Now;
            _serviceBiglietto.InsertBiglietto(b);
        }

        // PUT: api/Biglietti/5
        [HttpPut("{id}")]
        public void Put(int id)
        {
            _serviceBiglietto.UpdateBiglietto(id);
        }

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

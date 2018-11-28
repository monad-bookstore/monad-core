using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.API.Privileged
{
    /// <summary>
    ///     Svetainės darbuotojams prieinami metodai skirti kontroliuoti klientų duomenimis.
    ///     <remarks>
    ///         Prieigų roles privaloma nurodyti prie kiekvieno metodo.
    ///     </remarks>
    /// </summary>
    [Route("api/privileged/clients")]
    [ApiController]
    public class PrivilegedClientController : ControllerBase
    {
        private readonly BookstoreContext _context;
        private readonly IMapper _mapper;

        public PrivilegedClientController(BookstoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        ///     Metodas skirtas administratoriams ir vadybininkams klientų sąrašams gauti.
        ///     <returns>
        ///         Grąžina visus registruotus klientus.
        ///     </returns>
        /// </summary>
        [Authorize(Roles = "Administrator,Manager")]
        [Route("get")]
        public IQueryable<ClientDTO> FetchClientData()
        {
            // Naudojamas _mapper tam, kad pakeistų Client objektą į ClientDTO taip paslėpdamas nereikalingas reikšmes ir padeda išvengti 
            // galimų serializavimo problemų.
            return _context.Clients
                .Select(client => _mapper.Map<ClientDTO>(client));
        }

        /// <summary>
        ///     Metodas skirtas kliento duomenų keitimui.
        ///     <remarks>
        ///         Metodas prieinamas tik administratoriams ir vadybininkams.
        ///     </remarks>
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="modified">
        ///     POST metodu atsiųsti kliento pakeisti duomenys.
        ///     Administratorius ir vadybininkas gali pakeisti:
        ///         * Prieigos lygį.
        ///         * Vartotojo vardą.
        ///         * El. pašto adresą.
        /// </param>
        /// <returns>
        ///     Grąžina pakeistą objektą.
        /// </returns>
        [Authorize(Roles = "Administrator,Manager")]
        // {clientId} nurodo kad čia turi būti kažkokia reikšmė.
        [Route("modify/{clientId}")]
        [HttpPost]
        public IActionResult ModifyClientData(int clientId, ClientDTO modified)
        {
            Client modifying = _context.Clients
                .SingleOrDefault(c => c.Id == clientId);

            if (modifying == null)
                return BadRequest(new { message = "Klientas šiuo ID neregistruotas." });

            // POST metodu pateikti duomenys privalo sutapti su URL adrese esančiu kliento ID.
            if (modified.Id != clientId)
                return BadRequest(new { message = "Blogai pateikti kliento duomenys." });

            _context.Entry(modifying).CurrentValues.SetValues(modified);
            // Pereinama pro visas reikšmes kurios yra null ir pažymėtos kaip pakeistos tada tos reikšmės yra pažymimos kaip nepakeistos, kad neįrašytų null reikšmių į DB.
            // Šitas leidžia POST metodu siųsti tik Id ir norimą pakeisti reikšmę, todėl nereikia rūpintis apie kitas.
            foreach (var property in _context.Entry(modifying).Properties.Where(c => c.CurrentValue == null && c.IsModified))
                property.IsModified = false;

            // Atnaujinamas UpdatedAt į dabartinę datą.
            // Dėl tvarkos šito reiktų kiekvienai keičiamai lentelėj, kurioj tik yra UpdatedAt atributas.
            modifying.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return Ok(modifying);
        }
    }
}
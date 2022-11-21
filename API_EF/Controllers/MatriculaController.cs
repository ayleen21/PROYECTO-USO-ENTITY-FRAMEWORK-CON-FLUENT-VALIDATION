using API_EF.DTOS;
using API_EF.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly EFTRANSITOContext _EFTRANSITOContext;

        public MatriculaController(EFTRANSITOContext EFTRANSITOContext)
        {
            _EFTRANSITOContext = EFTRANSITOContext;
        }
        // GET: api/<MatriculaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatriculaDTO>>> Get()
        {
            try
            {
                var matricula = await _EFTRANSITOContext.Matricula.Select(x =>
                new MatriculaDTO
                {
                    Id = x.Id,
                    NumeroV = x.NumeroV,
                    FechaExpedicion = x.FechaExpedicion,
                    ValidoHasta = x.ValidoHasta,
                    Activo = x.Activo
                }).ToListAsync();
                if (matricula == null)
                {
                    return NotFound();
                }
                else
                {
                    return matricula;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        // GET api/<MatriculaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MatriculaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MatriculaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MatriculaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

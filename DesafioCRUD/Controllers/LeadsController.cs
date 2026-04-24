using DesafioCRUD.Dominio.Dominio;
using DesafioCRUD.DTO.Leads;
using DesafioCRUD.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly LeadService _leadService;

        public LeadsController(LeadService leadService)
        {
            _leadService = leadService;
        }

        // GET: api/leads
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var leads = await _leadService.ListarLeadsAsync();

            var dtos = leads.Select(l => new LeadDto(
                l.Id,
                l.Name,
                l.Email,
                l.Status,
                l.CreatedAt,
                l.UpdatedAt,
                l.Tasks.Count
            ));

            return Ok(dtos);
        }

        // GET: api/leads/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var lead = await _leadService.BuscarLeadPorIdAsync(id);
            if (lead == null) return NotFound();

            var dto = new LeadDto(
                lead.Id,
                lead.Name,
                lead.Email,
                lead.Status,
                lead.CreatedAt,
                lead.UpdatedAt,
                lead.Tasks.Count
            );

            return Ok(dto);
        }

        // POST: api/leads
        [HttpPost]
        public async Task<IActionResult> Create(LeadCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var lead = new Lead
            {
                Name = dto.Name,
                Email = dto.Email,
                Status = dto.Status ?? LeadStatus.New,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _leadService.CriarLeadAsync(lead);
            return Ok();
        }

        // PUT: api/leads/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LeadUpdateDto dto)
        {
            var lead = await _leadService.BuscarLeadPorIdAsync(id);
            if (lead == null) return NotFound();

            lead.Name = dto.Name;
            lead.Email = dto.Email;
            lead.Status = dto.Status;
            lead.UpdatedAt = DateTime.UtcNow;

            await _leadService.AtualizarLeadAsync(lead);
            return Ok();
        }

        // DELETE: api/leads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _leadService.RemoverLeadAsync(id);
            return Ok();
        }

    }
}

using API.Application.Interfaces;
using API.Controllers.Core;
using API.Domain.Entities.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : BaseApiController
    {
        private readonly IClientsService _clientsService;
        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }

        [HttpPost]
        [Route("GetAllData")]
        public async Task<ActionResult> GetAllData([FromBody] FilterData model)
        {
            try
            {
                var result = await _clientsService.GetAllData(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Insert")]
        public async Task<ActionResult> Create([FromBody] Clients model)
        {
            try
            {
                model.CreatedBy = UserEmail;
                var result = await _clientsService.Create(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] Clients model)
        {
            try
            {
                model.UpdatedBy = UserEmail;
                var result = await _clientsService.Update(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetById{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _clientsService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete{recordId}")]
        public async Task<ActionResult> Delete(Guid recordId)
        {
            try
            {
                Clients model = new Clients();
                model.UpdatedBy = UserEmail;
                model.RecordId = recordId;
                var result = await _clientsService.Delete(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

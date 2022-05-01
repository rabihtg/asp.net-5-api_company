using Microsoft.AspNetCore.Mvc;
using PersonalProjectClassLibrary.DataServices;
using PersonalProjectClassLibrary.Dto;
using System;
using System.Threading.Tasks;

namespace PersonalProjectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressData _data;

        public AddressesController(IAddressData data)
        {
            _data = data;
        }

        [HttpPost("{employeeId}")]
        public async Task<IActionResult> InsertAddress(Guid employeeId,InsertAddressDto addressDto)
        {
            await _data.InsertAddress(employeeId ,addressDto);

            return Ok();
        }


        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteAddress(Guid employeeId, DeleteAddressDto addressDto)
        {
            await _data.DeleteAddress(employeeId, addressDto);

            return Ok();
        }
    }
}

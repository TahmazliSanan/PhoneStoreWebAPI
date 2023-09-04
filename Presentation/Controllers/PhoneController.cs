﻿using DTOLayer.Dtos;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Abstracts;

namespace Presentation.Controllers
{
    [Route("api/phone")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneService _phoneService;

        public PhoneController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        [HttpPost]
        [Route("addphone")]
        public async Task<IActionResult> CreatePhoneAsync([FromForm] PhoneDto phoneDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (phoneDto.ImageFile != null)
                    {
                        var extension = Path.GetExtension(phoneDto.ImageFile.FileName);
                        var newImageName = Guid.NewGuid() + extension;
                        var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos/phone/", newImageName);
                        var stream = new FileStream(location, FileMode.Create);
                        phoneDto.ImageFile.CopyTo(stream);
                        phoneDto.ImagePath = newImageName;
                    }

                    await _phoneService.CreateAsync(phoneDto);
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception exception)
            {
                return Problem(exception.Message);
            }
        }

        [HttpGet]
        [Route("showallphones")]
        public async Task<IActionResult> GetAllPhonesAsync()
        {
            try
            {
                var phoneList = await _phoneService.GetAllAsync();
                return Ok(phoneList);
            }
            catch (Exception exception)
            {
                return Problem(exception.Message);
            }
        }

        [HttpGet]
        [Route("phonedetails/{id}")]
        public async Task<IActionResult> GetPhoneAsync([FromBody] int id)
        {
            try
            {
                var phone = await _phoneService.GetByIdAsync(id);
                return Ok(phone);
            }
            catch (Exception exception)
            {
                return Problem(exception.Message);
            }
        }

        [HttpPut]
        [Route("editphone")]
        public async Task<IActionResult> UpdatePhoneAsync([FromForm] PhoneDto phoneDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (phoneDto.ImageFile != null)
                    {
                        var extension = Path.GetExtension(phoneDto.ImageFile.FileName);
                        var newImageName = Guid.NewGuid() + extension;
                        var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos/phone/", newImageName);
                        var stream = new FileStream(location, FileMode.Create);
                        phoneDto.ImageFile.CopyTo(stream);
                        phoneDto.ImagePath = newImageName;
                    }

                    await _phoneService.UpdateAsync(phoneDto);
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception exception)
            {
                return Problem(exception.Message);
            }
        }

        [HttpDelete]
        [Route("removephone/{id}")]
        public async Task<IActionResult> DeletePhoneAsync([FromBody] int id)
        {
            try
            {
                var isDeleted = await _phoneService.GetByIdAsync(id);
                if (isDeleted == null)
                {
                    return NotFound("Phone is not found!");
                }
                
                await _phoneService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception exception)
            {
                return Problem(exception.Message);
            }
        }
    }
}
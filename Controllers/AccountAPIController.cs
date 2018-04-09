using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using LmycAPI.Models;
using Microsoft.Extensions.Configuration;
using LmycAPI.Models.AccountViewModels;
using LmycAPI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace LmycAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/AccountAPI")]
    public class AccountAPIController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public AccountAPIController(
            UserManager<ApplicationUser> userManager,
            IEmailSender emailSender,
            ILogger<AccountAPIController> logger)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _logger = logger;
        }

        // POST api/AccountAPI/Register
        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                AddressStreet = model.AddressStreet,
                AddressCity = model.AddressCity,
                AddressProvince = model.AddressProvince,
                AddressPostalCode = model.AddressPostalCode,
                AddressCountry = model.AddressCountry,
                MobileNumber = model.MobileNumber,
                SailingExperience = model.SailingExperience
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest();
            }

            await _userManager.AddToRoleAsync(user, "Member");
            _logger.LogInformation("User created a new account with password.");

            return Ok();
        }
    }
}
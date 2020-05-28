using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using BuyerService.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuyerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerManager _iBuyerManager;

        public BuyerController(IBuyerManager iBuyerManager)
        {
            _iBuyerManager = iBuyerManager;
        }
        /// <summary>
        /// Edit Buyer Profile
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("EditProfile")]
        public async Task<IActionResult> EditBuyerProfile(BuyerData buyer)
        {
            return Ok(await _iBuyerManager.EditBuyerProfile(buyer));

        }
        /// <summary>
        /// Get Buyer Profile
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Profile/{bid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBuyerProfile(int bid)
        {
            BuyerData buyer = await _iBuyerManager.GetBuyerProfile(bid);
            if (buyer == null)
                return Ok("Invalid User");
            else
            {
                return Ok(buyer);
            }

        }
    }
}
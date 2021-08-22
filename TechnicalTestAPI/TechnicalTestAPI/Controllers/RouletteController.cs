using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTest.DTO;
using TechnicalTestAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechnicalTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private IService ServiceInstance { get; set; }
        private IConfiguration AppConfiguration { get; set; }

        public RouletteController(IService service, IConfiguration configuration)
        {
            this.ServiceInstance = service;
            this.AppConfiguration = configuration;

        }

        [HttpGet("CreateRoulette")]
        public async Task<ActionResult<Guid>> CreateRoulette()
        {
            try
            {
                var newRoulette = await this.ServiceInstance.Create(Convert.ToInt32(this.AppConfiguration[""]));
                return Ok(newRoulette);
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
        }


        [HttpPost("OpenRoulette")]
        public async Task<ActionResult> OpenRoulette(Rulette item)
        {
            try
            {
                item.State = Common.RouletteStatus.Open;
                this.ServiceInstance.Update(item);
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
        }

        [HttpPost("BetToRoulette")]
        public async Task<ActionResult> BetNumberToRoulette(Bet betItem)
        {
            if(Request.Headers!=null && Request.Headers.Count!=0)
            {
                String userData = Request.Headers["Authorization"];
                String bettingAmount = Request.Headers["BettingAmount"];
                if (userData != null && bettingAmount != null)
                {
                    var bettingResult = await this.ServiceInstance.BetToRoulette(betItem);
                    return Ok(bettingResult);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost("GetAllRoulette")]
        public async Task<ActionResult> GetRoulette()
        {
            try
            {
                var items=await this.ServiceInstance.GetRulettes();
                return Ok(items);
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
        }

    }
}

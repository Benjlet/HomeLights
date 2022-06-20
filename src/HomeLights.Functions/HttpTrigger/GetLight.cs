﻿using HueManatee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Threading.Tasks;

namespace HomeLights.Functions
{
    public class GetLight
    {
        private readonly BridgeClient _hueManateeClient;

        public GetLight(BridgeClient hueManateeClient)
        {
            _hueManateeClient = hueManateeClient;
        }

        [FunctionName("GetLight")]
        [ProducesResponseType(typeof(OkObjectResult), 200)]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "lights/{id}")] HttpRequest req, string id)
        {
            var response = await _hueManateeClient.GetLightData(id);
            return new OkObjectResult(response);
        }
    }
}

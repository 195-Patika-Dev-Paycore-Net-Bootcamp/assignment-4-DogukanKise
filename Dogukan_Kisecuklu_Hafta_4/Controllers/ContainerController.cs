using AutoMapper;
using Data.Model.Concrete;
using Dogukan_Kisecuklu_Hafta_3.Util;
using Microsoft.AspNetCore.Mvc;
using Service.Containers.Abstract;
using System.Collections.Generic;

namespace Dogukan_Kisecuklu_Hafta_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IContainerService containerService;

        public ContainerController(IContainerService containerService, IMapper mapper)
        {
            this.containerService = containerService;

        }
        [HttpGet("GetAll")]
        public List<List<Container>> GetAll([FromQuery] int n, int vehicleId)
        {
            var response = containerService.GetAll().Response;
            KMeans kMeans = new KMeans();
            return kMeans.Cluster(response, n, vehicleId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    public class OrderDetailController : Controller
    {
        private readonly ILogger<OrderDetailController> _logger;

        public OrderDetailController(ILogger<OrderDetailController> logger)
        {
            _logger = logger;
        }

      
      
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contoso.Application.Instructors.Queries;
using Contoso.Web.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InstructorsController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{instructorId}")]
        public Task<IActionResult> Get(int instructorId) =>
            _mediator.Send(new GetInstructorById(instructorId))
                .ToActionResult();
    }
}

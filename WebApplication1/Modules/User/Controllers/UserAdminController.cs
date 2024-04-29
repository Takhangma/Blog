﻿using System.Net;
using CourseWork.Common.Exceptions;
using CourseWork.Modules.User.Dtos;
using CourseWork.Modules.User.Entity;
using CourseWork.Modules.User.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Modules.User.Controller
{

    [ApiExplorerSettings(GroupName = "admin")] //Provides metadata about the API Explorer group that an action belongs to.
    [Tags("Users")]
    [Route("api/admin/user")]
    [ApiController]
    public class UserAdminsController : ControllerBase
    {
        private readonly UserService _userService;
        public UserAdminsController(UserService userService)
        {
            _userService = userService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(UserCreateDto incomingData)
        {
            try
            {
                var result = await _userService.CreateUser(incomingData);

                HttpContext.Items["CustomMessage"] = "User Created Successfully";

                return Created("", result);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
﻿using Application.Commands.Users.DeleteUser;
using Application.Commands.Users.RegisterNewUser;
using Application.Commands.Users.UpdateUser;
using Application.Dto;
using Application.Query.Users.GetAllUsers;
using Application.Query.Users.LoginUser;
using Application.Validators.GuidValidator;
using Application.Validators.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Errors.Model;

namespace Grupparbete_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthUserController : ControllerBase
    {
        // public static User user = new();
        private readonly IConfiguration _configuration;
        internal readonly IMediator _mediator;
        private readonly UserValidator _userValidator;
        private readonly GuidValidator _guidValidator;

        //In order go gain access to Appsetings and inject configuration we have to create constructor
        public AuthUserController(IConfiguration configuration, IMediator mediator, UserValidator userValidator, GuidValidator guidValidator)
        {
            _configuration = configuration;
            _mediator = mediator;
            _userValidator = userValidator;
            _guidValidator = guidValidator;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDto newUser)
        {

            var userValidator = _userValidator.Validate(newUser);

            if (!userValidator.IsValid)
            {
                return BadRequest(userValidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediator.Send(new RegisterUserCommand(newUser)));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> GetToken([FromBody] UserDto userToLogin)
        {
            var inputValidation = _userValidator.Validate(userToLogin);

            if (!inputValidation.IsValid)
            {
                return BadRequest(inputValidation.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                string token = await _mediator.Send(new LoginUserQuery(userToLogin));

                return Ok(token);
            }
            catch (UnauthorizedException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getAllUsers"), Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllUsersQuery()));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        [Route("updateUserPassword/{updatedUserId}"), Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto updatedUser, Guid updatedUserId)
        {
            // Validate updatedUser, Guid updatedUserId
            var validatedUpdatedUser = _userValidator.Validate(updatedUser);
            var validatedUpdatedUserId = _guidValidator.Validate(updatedUserId);

            //Error Handling
            if (!validatedUpdatedUser.IsValid)
            {
                return BadRequest(validatedUpdatedUser.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            if (!validatedUpdatedUserId.IsValid)
            {
                return BadRequest(validatedUpdatedUserId.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            //Try Catch
            try
            {
                return Ok(await _mediator.Send(new UpdateUserByIdCommand(updatedUserId, updatedUser)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleteUser/{userToDeleteId}"), Authorize]
        public async Task<IActionResult> DeleteUser(Guid userToDeleteId)
        {
            // Validate Guid birdToDeleteId
            var validateUserToDeleteId = _guidValidator.Validate(userToDeleteId);
            //Error Handling
            if (!validateUserToDeleteId.IsValid)
            {
                return BadRequest(validateUserToDeleteId.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            //Try Catch
            try
            {
                return Ok(await _mediator.Send(new DeleteUserByIdCommand(userToDeleteId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

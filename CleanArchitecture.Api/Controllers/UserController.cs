using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ExceptionServices;

namespace CleanArchitecture.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllAsync()
    {
        var users = await _userService.GetAllAsync();

        //if (users == null || !users.Any())
        //{
        //    return NotFound("Nenhum usuário encontrado");
        //}

        return Ok(users);
    }

    [HttpGet("{id:int}", Name = "GetUserById")]
    public async Task<ActionResult<UserDTO>> GetByIdAsync(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user == null)
            return NotFound("Usuário não encontrado");

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserDTO>> CreateAsync([FromBody] UserDTO userDto)
    {
        var userExist = (await _userService.GetAllAsync()).FirstOrDefault(u => u.Email == userDto.Email);

        if (userExist != null)
            return Conflict("Email já cadastrado");

        var user = await _userService.AddAsync(userDto);

        return CreatedAtRoute("GetUserById", new { id = user.Id }, user);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateAsync(int id, [FromBody] UserDTO userDto)
    {
        if (id != userDto.Id)
            return BadRequest("Id inválido.");

        var userUpdated = await _userService.UpdateAsync(userDto);

        if (userUpdated == null)
            return NotFound("Usuário não encontrado");

        return Ok(userUpdated);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user == null)
            return NotFound("Usuário não encontrado");

        await _userService.DeleteAsync(id);
        return NoContent();
    }
}
using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetAllAsync();

    Task<UserDTO?> GetByIdAsync(int id);

    Task<UserDTO> AddAsync(UserDTO userDto);

    Task<UserDTO> UpdateAsync(UserDTO userDto);

    Task DeleteAsync(int id);
}
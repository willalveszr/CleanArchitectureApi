using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDTO>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserDTO>>(users);
    }

    public async Task<UserDTO?> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return _mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO> AddAsync(UserDTO userDto)
    {
        var user = _mapper.Map<User>(userDto);

        // 2️⃣ Adiciona a entidade no banco (gera Id automaticamente)
        await _userRepository.AddAsync(user);

        // 3️⃣ Converte de volta para DTO, agora com Id preenchido
        return _mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO> UpdateAsync(UserDTO userDto)
    {
        var existUser = await _userRepository.GetByIdAsync(userDto.Id);

        if (existUser == null)
            return null;

        _mapper.Map(userDto, existUser);
        await _userRepository.UpdateAsync(existUser);

        return _mapper.Map<UserDTO>(existUser);
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        /*
        if (user == null)
            throw new KeyNotFoundException("User not found");
        */
        await _userRepository.DeleteAsync(id);
    }
}
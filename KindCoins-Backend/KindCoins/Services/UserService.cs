﻿using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }

    public async Task<UserResponse> SaveAsync(User user)
    {
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
            return new UserResponse(user);
        }
        catch (Exception e)
        {
            return new UserResponse($"An error occurred while saving the category: {e.Message}");
        }
    }
    
    public async Task<UserResponse> UpdateAsync(int id, User user)
    {
        var existingUser = await _userRepository.FindByIdAsync(id);
        if (existingUser == null)
            return new UserResponse("Category not found.");
        existingUser.FirstName = user.FirstName;
        try
        {
            _userRepository.Update(existingUser);
            await _unitOfWork.CompleteAsync();
            return new UserResponse(existingUser);
        }
        catch (Exception e)
        {
            return new UserResponse($"An error occurred while updating the user: {e.Message}");
        }
    }
    public async Task<UserResponse> DeleteAsync(int id)
    {
        var existingUser = await _userRepository.FindByIdAsync(id);
        if (existingUser == null)
            return new UserResponse("Category not found.");
        try
        {
            _userRepository.Remove(existingUser);
            await _unitOfWork.CompleteAsync();
            return new UserResponse(existingUser);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new UserResponse($"An error occurred while deleting the user: {e.Message}");
        }
    }


}
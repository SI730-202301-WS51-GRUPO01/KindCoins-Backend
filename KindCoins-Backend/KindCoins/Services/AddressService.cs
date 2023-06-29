using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Services;

public class AddressService: IAddressService
{
    private readonly IAddressRepository _addressRepository;
    private readonly IUnitOfWork _unitOfWork;

    public async Task<IEnumerable<Address>> ListAsync()
    {
        return await _addressRepository.ListAsync();
    }
    
    public AddressService(IAddressRepository addressRepository, IUnitOfWork unitOfWork)
    {
        _addressRepository = addressRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<AddressResponse> SaveAsync(Address address)
    {
        try
        {
            await _addressRepository.AddAsync(address);
            await _unitOfWork.CompleteAsync();

            return new AddressResponse(address);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new AddressResponse($"An error occurred when saving the address: {ex.Message}");
        }
    }

    public async Task<AddressResponse> UpdateAsync(int id, Address address)
    {
        var existingAddress = await _addressRepository.FindByIdAsync(id);
        if (existingAddress == null) return new AddressResponse("Address not found");

        existingAddress.AddressName = address.AddressName;
        existingAddress.Reference = address.Reference;
        try
        {
            _addressRepository.Update(existingAddress);
            await _unitOfWork.CompleteAsync();

            return new AddressResponse(existingAddress);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new AddressResponse($"An error occurred when updating the address: {ex.Message}");
        }
    }

    public async Task<AddressResponse> DeleteAsync(int id)
    {
        var existingAddress = await _addressRepository.FindByIdAsync(id);
        if (existingAddress == null) return new AddressResponse("Address not found");
        try
        {
            _addressRepository.Remove(existingAddress);
            await _unitOfWork.CompleteAsync();

            return new AddressResponse(existingAddress);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new AddressResponse($"An error occurred when deleting the address: {ex.Message}");
        }
    }
}
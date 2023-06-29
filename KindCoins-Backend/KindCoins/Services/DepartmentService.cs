using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Services;

public class DepartmentService
{
     private readonly IDepartmentRepository _departmentRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public async Task<IEnumerable<Department>> ListAsync()
    {
        return await _departmentRepository.ListAsync();
    }
    
    public DepartmentService(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork)
    {
        _departmentRepository = departmentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<DepartmentResponse> SaveAsync(Department department)
    {
        try
        {
            await _departmentRepository.AddAsync(department);
            await _unitOfWork.CompleteAsync();

            return new DepartmentResponse(department);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new DepartmentResponse($"An error occurred when saving the department: {ex.Message}");
        }
    }

    public async Task<DepartmentResponse> UpdateAsync(int id, Department department)
    {
        var existingDepartment = await _departmentRepository.FindByIdAsync(id);
        if (existingDepartment == null) return new DepartmentResponse("Department not found");

        existingDepartment.DepartmentName = department.DepartmentName;
        
        try
        {
            _departmentRepository.Update(existingDepartment);
            await _unitOfWork.CompleteAsync();

            return new DepartmentResponse(existingDepartment);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new DepartmentResponse($"An error occurred when updating the department: {ex.Message}");
        }
    }

    public async Task<DepartmentResponse> DeleteAsync(int id)
    {
        var existingDepartment = await _departmentRepository.FindByIdAsync(id);
        if (existingDepartment == null) return new DepartmentResponse("Department not found");
        try
        {
            _departmentRepository.Remove(existingDepartment);
            await _unitOfWork.CompleteAsync();

            return new DepartmentResponse(existingDepartment);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new DepartmentResponse($"An error occurred when deleting the department: {ex.Message}");
        }
    }
}
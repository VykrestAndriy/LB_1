using CarWashManager.BusinessLogic.Contracts;
using CarWashManager.BusinessLogic.Dtos;
using CarWashManager.DataAccess.Entities;
using CarWashManager.DataAccess.Repositories.Wash;

namespace CarWashManager.BusinessLogic.Services;

public class WashService : IWashService
{
    private readonly IWashRepository _washRepository;

    public WashService(IWashRepository washRepository)
    {
        _washRepository = washRepository;
    }

    public async Task<IReadOnlyList<WashDto>> Get()
    {
        var washes = await _washRepository.Get();
        if (washes == null)
            return new List<WashDto>();

        return washes.Select(e => new WashDto(
            washId: e.WashId,
            washType: e.WashType,
            serviceType: e.ServiceType,
            serviceName: e.ServiceName,
            amount: e.Amount,
            washTime: e.WashTime)).ToList().AsReadOnly();
    }

    public async Task<WashDto> Get(string washId)
    {
        var wash = await _washRepository.Get(washId);
        if (wash == null)
            return WashDto.Default;

        return new WashDto(
            washId: wash.WashId,
            washType: wash.WashType,
            serviceType: wash.ServiceType,
            serviceName: wash.ServiceName,
            amount: wash.Amount,
            washTime: wash.WashTime);
    }

    public async Task Add(WashDto wash)
    {
        if (wash == WashDto.Default)
            return;

        await _washRepository.Create(new WashEntity
        {
            WashId = wash.WashId,
            WashType = wash.WashType,
            ServiceType = wash.ServiceType,
            ServiceName = wash.ServiceName,
            Amount = wash.Amount,
            WashTime = DateTime.UtcNow
        });
    }

    public async Task Update(WashDto wash)
    {
        if (wash == WashDto.Default)
            return;

        await _washRepository.Update(new WashEntity
        {
            WashId = wash.WashId,
            WashType = wash.WashType,
            ServiceType = wash.ServiceType,
            ServiceName = wash.ServiceName,
            Amount = wash.Amount,
            WashTime = DateTime.UtcNow
        });
    }

    public async Task Remove(string washId)
    {
        if (string.IsNullOrEmpty(washId))
            throw new ArgumentNullException(nameof(washId));

        await _washRepository.Delete(washId);
    }
}

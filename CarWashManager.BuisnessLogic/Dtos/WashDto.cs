using CarWashManager.DataAccess.Entities;

namespace CarWashManager.BusinessLogic.Dtos;

public class WashDto : IEquatable<WashDto>
{
    public static readonly WashDto Default
        = new WashDto(string.Empty, WashType.FullService, ServiceType.ExteriorWash, string.Empty, decimal.Zero, DateTime.MinValue);

    public string WashId { get; }
    public WashType WashType { get; }
    public ServiceType ServiceType { get; }
    public string ServiceName { get; }
    public decimal Amount { get; }
    public DateTime WashTime { get; }

    public WashDto(string washId, WashType washType, ServiceType serviceType, string serviceName, decimal amount, DateTime washTime)
    {
        WashId = washId;
        WashType = washType;
        ServiceType = serviceType;
        ServiceName = serviceName;
        Amount = amount;
        WashTime = washTime;
    }

    public bool Equals(WashDto? other)
    {
        if (other == null)
            return false;

        return WashId == other.WashId && WashType == other.WashType && ServiceType == other.ServiceType
            && ServiceName == other.ServiceName && Amount == other.Amount && WashTime == other.WashTime;
    }

    public override int GetHashCode()
    {
        return (WashId.GetHashCode() + WashType.GetHashCode() + ServiceType.GetHashCode()
            + ServiceName.GetHashCode() + Amount.GetHashCode() + WashTime.GetHashCode()) * 45;
    }
}

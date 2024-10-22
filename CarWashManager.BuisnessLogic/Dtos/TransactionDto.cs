using CarWashManager.DataAccess.Entities;

namespace CarWashManager.BusinessLogic.Dtos;

public class TransactionDto : IEquatable<TransactionDto>
{
    public static readonly TransactionDto Default
        = new TransactionDto(string.Empty, string.Empty, TransactionType.Unsuccessfully, decimal.Zero, DateTime.MinValue);

    public string TransactionId { get; }
    public string WashId { get; init; } // Изменено на WashId
    public TransactionType Type { get; init; }
    public decimal Amount { get; }
    public DateTime TransactionTime { get; } // Переименовано для ясности

    public TransactionDto(string transactionId, string washId, TransactionType type, decimal amount, DateTime transactionTime)
    {
        TransactionId = transactionId;
        WashId = washId; // Изменено на WashId
        Type = type;
        Amount = amount;
        TransactionTime = transactionTime; // Переименовано для ясности
    }

    public bool Equals(TransactionDto? other)
    {
        if (other == null)
            return false;

        return TransactionId == other.TransactionId && WashId == other.WashId && Type == other.Type
            && Amount == other.Amount && TransactionTime == other.TransactionTime; // Переименовано для ясности
    }

    public override int GetHashCode()
    {
        return (TransactionId.GetHashCode() + WashId.GetHashCode() + Type.GetHashCode()
            + Amount.GetHashCode() + TransactionTime.GetHashCode()) * 45; // Переименовано для ясности
    }
}

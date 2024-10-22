using CarWashManager.BusinessLogic.Contracts;
using CarWashManager.BusinessLogic.Dtos;
using CarWashManager.DataAccess.Entities;
using CarWashManager.DataAccess.Repositories.Transaction;

namespace CarWashManager.BusinessLogic.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IWashRepository _washRepository;

    public TransactionService(ITransactionRepository transactionRepository, IWashRepository washRepository)
    {
        _transactionRepository = transactionRepository;
        _washRepository = washRepository;
    }

    public async Task<IReadOnlyList<TransactionDto>> Get()
    {
        var transactions = await _transactionRepository.Get();
        if (transactions == null)
            return new List<TransactionDto>();

        return transactions.Select(e => new TransactionDto(
            e.TransactionId, e.WashId, e.Type, e.Amount, e.TransactionTime)).ToList().AsReadOnly();
    }

    public async Task<TransactionDto> Get(string transactionId)
    {
        var transaction = await _transactionRepository.Get(transactionId);
        if (transaction == null)
            return TransactionDto.Default;

        return new TransactionDto(
            transaction.TransactionId, transaction.WashId, transaction.Type, transaction.Amount, transaction.TransactionTime);
    }

    public async Task<IReadOnlyList<TransactionDto>> GetTodayTransactions()
    {
        var transactions = await _transactionRepository.Get(t => t.TransactionTime.Date == DateTime.UtcNow.Date);
        if (transactions == null)
            return new List<TransactionDto>();

        return transactions.Select(e => new TransactionDto(
            e.TransactionId, e.WashId, e.Type, e.Amount, e.TransactionTime)).ToList().AsReadOnly();
    }

    public async Task Create(TransactionDto transaction)
    {
        if (transaction != TransactionDto.Default)
        {
            var wash = await _washRepository.Get(transaction.WashId);

            if (wash == null)
                throw new ArgumentNullException($"Wash not found by id={transaction.WashId}");

            await _transactionRepository.Create(new TransactionEntity
            {
                TransactionId = transaction.TransactionId,
                WashId = transaction.WashId,
                Type = transaction.Type,
                Amount = transaction.Amount,
                TransactionTime = transaction.TransactionTime
            });

            switch (transaction.Type)
            {
                case TransactionType.Successfully:
                    wash.Amount += transaction.Amount;
                    break;
                case TransactionType.Unsuccessfully:
                    wash.Amount -= transaction.Amount;
                    break;
            }

            await _washRepository.Update(wash);
        }
    }

    public async Task Remove(string transactionId)
    {
        if (string.IsNullOrEmpty(transactionId))
            throw new ArgumentNullException(nameof(transactionId));

        await _transactionRepository.Delete(transactionId);
    }
}

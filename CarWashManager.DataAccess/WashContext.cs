using CarWashManager.DataAccess.Entities;

namespace CarWashManager.DataAccess;

public class CarWashContext
{
    public ICollection<WashEntity> CarWashes { get; }
    public ICollection<TransactionEntity> Transactions { get; }

    public CarWashContext()
    {
        CarWashes = new List<WashEntity>()
        {
            new WashEntity
            {
                OrderId = "1",
                WashType = WashType.FullService,
                CarModel = "Toyota Corolla",
                LicensePlate = "ABC123",
                Price = 50.0m,
                OrderTime = DateTime.Now
            },
            new WashEntity
            {
                OrderId = "2",
                WashType = WashType.ExteriorOnly,
                CarModel = "Honda Civic",
                LicensePlate = "XYZ789",
                Price = 30.0m,
                OrderTime = DateTime.Now
            },
            new WashEntity
            {
                OrderId = "3",
                WashType = WashType.InteriorOnly,
                CarModel = "Ford Focus",
                LicensePlate = "JKL456",
                Price = 40.0m,
                OrderTime = DateTime.Now
            }
        };

        Transactions = new List<TransactionEntity>()
        {
            new TransactionEntity
            {
                TransactionId = "1",
                WashId = "1",
                TransactionType = TransactionType.Success,
                Amount = 50.0m,
                DateTime = DateTime.Now
            },
            new TransactionEntity
            {
                TransactionId = "2",
                WashId = "2",
                TransactionType = TransactionType.Success,
                Amount = 30.0m,
                DateTime = DateTime.Now
            },
            new TransactionEntity
            {
                TransactionId = "3",
                WashId = "3",
                TransactionType = TransactionType.Success,
                Amount = 40.0m,
                DateTime = DateTime.Now
            }
        };
    }
}

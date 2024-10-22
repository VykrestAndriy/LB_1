namespace CarWashManager.DataAccess.Entities;

public class CarWashManager
{
    public string WashId { get; init; }
    public WashType WashType { get; set; }
    public DishType DishType { get; set; }
    public string DishName { get; set; }
    public decimal Amount { get; set; }
    public DateTime OrderTime { get; set; }
}
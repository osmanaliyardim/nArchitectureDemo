using Core.Persistance.Repositories;

namespace Domain.Entities;

public class Model : Entity<Guid>
{
    public Guid BrandId { get; set; }

    public Guid FuelId { get; set; }

    public Guid TransmissionId { get; set; }

    public string Name { get; set; }

    public decimal DailyPrice { get; set; }

    public decimal MonthlyPrice { get { return ((DailyPrice * 0.95m) * 30); } }

    public decimal YearlyPrice { get { return ((DailyPrice * 0.92m) * 365); } }

    public string ImageUrl { get; set; }

    // Navigation Props
    public virtual Brand? Brand { get; set; }

    public virtual Fuel? Fuel { get; set; }

    public virtual Transmission? Transmission { get; set; }

    public virtual ICollection<Car>? Cars { get; set; }

    public Model()
    {
        Cars = new HashSet<Car>();
    }

    public Model(Guid id, Guid brandId, Guid fuelId, Guid transmissionId, string name, decimal dailyPrice, string imageUrl) : this()
    {
        Id = id;
        BrandId = brandId;
        FuelId = fuelId;
        TransmissionId = transmissionId;
        Name = name;
        DailyPrice = dailyPrice;
        ImageUrl = imageUrl;
    }
}
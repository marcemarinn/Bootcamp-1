namespace Core.Entities;

public class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; }

    public string Brand { get; set; }

    public virtual ICollection<ProductRequest> ProductsRequest { get; set; } = new List<ProductRequest>();
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

}

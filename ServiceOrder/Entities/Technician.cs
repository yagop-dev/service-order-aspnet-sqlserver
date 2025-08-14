namespace ServiceOrder.Entities
{
    public class Technician
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ServiceOrders> ServiceOrders { get; set; } = new List<ServiceOrders>();
    }
}

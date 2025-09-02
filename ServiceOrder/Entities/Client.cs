using ServiceOrder.Entities.ServiceOrder;

namespace ServiceOrder.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public ICollection<ServiceOrders> ServiceOrders { get; set; } = new List<ServiceOrders>();

    }
}

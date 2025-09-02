namespace ServiceOrder.Entities.ServiceOrder
{
    public enum ServiceOrderStatus
    {
        Pending = 0,
        Open = 1,
        InProgress = 2,
        Closed = 3,
        Canceled = 4,
    }
    public enum ServiceOrderDepartment
    {
        Infraestructure = 0,
        Microcomputing = 1,
        HR = 2,
        Judicial = 3,
        Financial = 4,
    }
    public enum ServiceOrderType
    {
        Software = 0,
        Hardware = 1,
        Access = 2,
        Network = 3,
        Acessories = 4,
        Improvements = 5,
        Bugs = 6,
    }
}

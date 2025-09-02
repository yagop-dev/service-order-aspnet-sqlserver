namespace ServiceOrder.DTOs
{
    public class LoginRequest()
    {
        public string Email { get; set; } = "";
    }
    public class ClientLoginResponse()
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Telephone { get; set; }
        public string Email { get; set; }
    }

    public class ClientRegisterResponse()
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Telephone { get; set; }
        public string Email { get; set; }
    }


    public class TechnicianRegisterResponse()
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; }
        public int Registration { get; set; }
    }
}

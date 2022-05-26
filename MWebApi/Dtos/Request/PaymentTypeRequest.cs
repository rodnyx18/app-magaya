namespace MWebApi.Dtos.Request
{
    public class PaymentTypeRequest
    {
        public int Id { get; set; }
        public string Type { get; set; } = default!;
    }
}

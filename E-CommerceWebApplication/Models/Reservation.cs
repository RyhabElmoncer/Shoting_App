namespace E_CommerceWebApplication.Models
{
    public class Reservation

    {
     public int id {  get; set; }
        public string name { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public DateTime date { get; set; }
        public bool IsValidated { get; set; }
    }
}

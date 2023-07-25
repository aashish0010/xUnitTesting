namespace UnitTestingMVC.Models
{

    public class Register : RegisterRequest
    {
        public DateTime CreateDate = DateTime.Now;
    }
    public class RegisterRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
        public bool IsAgreeToTerms { get; set; }
    }
}

namespace _03.Telephony.Models
{
    using _03.Telephony.Models.Interfaces;
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            return $"Dialing... {number}";
        }
    }
}
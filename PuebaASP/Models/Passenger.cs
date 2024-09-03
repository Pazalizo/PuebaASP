namespace PuebaASP.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public int Document {  get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        
        public int LuggageId { get; set; }
        public Luggage Luggage { get; set; }
    }
}

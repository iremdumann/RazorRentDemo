using System.ComponentModel.DataAnnotations;

namespace RazorRentDemo.Model
{
    public class Reservation
    {
        public int Id { get; set; }//EF > DB

        [Required, StringLength(50), Display(Name = "Customer Name")]
        public string CustomerName { get; set; }//UI
        public DateTime Start { get; set; }//now
        public DateTime End { get; set; }//pass
        public int TotalPrice { get; set; }
        
        public Car Car { get; set; }//with id

    }
}

using SQLite;

namespace PromoBox.Models
{
    public class Book
    {
        
        [PrimaryKey]
        public int Id { get; set;  }
        public string BookName { get; set; }
        public string BookReview { get; set; }

        public override string ToString()
        {
            return this.BookName + "(" + "My Review: " + this.BookReview +  ")";
        }
    }
}

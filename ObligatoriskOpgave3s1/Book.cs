namespace ObligatoriskOpgave3s1
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Price { get; set; }

        public void ValidateTitle()
        {
            if (Title == null)
            {
                throw new ArgumentNullException("Book has to have a title");
            }
            if (Title.Length < 3)
            {
                throw new ArgumentException("Title has to have at least three characters");
            }
        }
        public void ValidatePrice()
        {
            if (Price < 1 || Price > 1200)
            {
                throw new ArgumentOutOfRangeException("Price have to be between 1 and 1200");
            }

        }
        public override string ToString()
        {
            return $"Id {Id} Name {Title} Price {Price}" + base.ToString();
        }
    }
}
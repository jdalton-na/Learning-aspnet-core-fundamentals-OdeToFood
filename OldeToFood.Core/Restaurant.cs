namespace OldeToFood.Core
{
    public partial class Restaurant
    {

        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string? Location { get; set; }
        public CuisineType Cuisine { get; set; }

    }
}
namespace NZWalksAPI.Models.DTO
{
    public class RegionsDTO
    {
        public Guid Id { get; set; }

        public string code { get; set; }

        public string name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}

namespace NZWalksAPI.Models.DTO
{
    public class WalkDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double lengthinkms { get; set; }

        public Guid DifficultyId { get; set; }

        public Guid RegionId { get; set; }


    }
}

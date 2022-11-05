namespace HMS.DTO.Room
{
    public record RoomDto
    {
        public int Id { get; init; }

        public string RoomNumber { get; set; }
    }
}

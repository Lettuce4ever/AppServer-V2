using System.ComponentModel.DataAnnotations;

namespace AppServerGal.DTO
{
    public class CardDTO
    {
        public int CardId { get; set; }
        public byte[]? CardImage { get; set; }
        public string? CardDescription { get; set; }
        public string? Rules { get; set; }
    }
}

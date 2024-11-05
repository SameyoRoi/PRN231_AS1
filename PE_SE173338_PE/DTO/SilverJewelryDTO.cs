using BO;
using System.ComponentModel.DataAnnotations;

namespace PE_SE173338_PE.DTO
{
    public class SilverJewelryDTO
    {
        public string SilverJewelryId { get; set; } = "0";

        public string SilverJewelryName { get; set; } = null!;

        public string? SilverJewelryDescription { get; set; }

        public decimal? MetalWeight { get; set; }

        public decimal? Price { get; set; }

        public int? ProductionYear { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CategoryId { get; set; }

        public virtual CategoryDTO? Category { get; set; }
    }
}

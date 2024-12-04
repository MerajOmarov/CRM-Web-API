namespace Domen.DTOs._read_DTOs
{
    public  class GetProductDetailedDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Barcode { get; set; }
        public string Videocard { get; set; }
        public string OperatingSystem { get; set; }
        public string Screen { get; set; }
        public string Prosessor { get; set; }
        public double Price { get; set; }
    }
}

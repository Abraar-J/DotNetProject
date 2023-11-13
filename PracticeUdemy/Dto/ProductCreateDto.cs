namespace PracticeUdemy.Dto
{
    public class ProductCreateDto
    {
        public string productname { get; set; }

        public string product_description { get; set; }

        public int product_price { get; set; }

        public Guid catagoryid { get; set; }
    }
}

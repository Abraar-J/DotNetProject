namespace PracticeUdemy.Dto
{
    public class UpdatePoductDto
    {
        public string productname { get; set; }

        public string product_description { get; set; }

        public int product_price { get; set; }

        public Guid catagoryid { get; set; }
    }
}

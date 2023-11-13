using PracticeUdemy.Models;

namespace PracticeUdemy.Dto
{
    public class ProductNavigationalDto
    {
        public Guid id { get; set; }

        public string productname { get; set; }

        public string product_description { get; set; }

        public int product_price { get; set; }

      //  public Guid catagoryid { get; set; }
        //navigational property

        public Catagory Catagory { get; set; }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FFCG.G4.Webshop.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<ProductViewModel> Products()
        {
            return GetMockProducts();
        }

        public class ProductViewModel
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
            public string Image { get; set; }
            public string Description { get; set; }
        }

        public IEnumerable<ProductViewModel> GetMockProducts()
        {
            var tv = new ProductViewModel()
            {
                Name = "100 inch TV",
                Id = Guid.NewGuid().ToString(),
                Category = "Electronics",
                Price = 29999,
                Description = "This TV is ginormous.",
                Image =
                    "http://4k.com/wp-content/uploads/2015/12/samsung-ue50ju6400-smart-tv-tp_7191224521174070653f.jpg"
            };

            var laptop = new ProductViewModel()
            {
                Name = "Macbook Pro",
                Id = Guid.NewGuid().ToString(),
                Category = "Electronics",
                Price = 18499,
                Description = "A suitable laptop for all your development needs.",
                Image =
                    "http://store.storeimages.cdn-apple.com/4662/as-images.apple.com/is/image/AppleInc/aos/published/images/M/AC/MACBOOKPRO/MACBOOKPRO?wid=1200&hei=630&fmt=jpeg&qlt=95&op_sharpen=0&resMode=bicub&op_usm=0.5,0.5,0,0&iccEmbed=0&layer=comp&.v=jBFkr3"
            };

            var fircone = new ProductViewModel()
            {
                Name = "Kotte",
                Id = Guid.NewGuid().ToString(),
                Category = "Misc",
                Price = 10,
                Description = "You never know when you may need it!",
                Image = "http://tyda.se/img/5518d369c26bdde7f13221c5e2325673.jpg"
            };

            var chips = new ProductViewModel()
            {
                Name = "Chips",
                Id = Guid.NewGuid().ToString(),
                Category = "Food",
                Price = 20,
                Description = "The best thing in the history of ever.",
                Image = "http://lantchips.se/wp-content/uploads/2016/02/lantchips-graddfil-200g-2016-v1-350x453.jpg"
            };

            var phone = new ProductViewModel()
            {
                Name = "iPhone 7",
                Id = Guid.NewGuid().ToString(),
                Category = "Electronics",
                Price = 6999,
                Description = "Now completely without a headphone jack.",
                Image =
                    "https://www.tele2.se/shop/media/catalog/product/cache/1/image/700x580/9df78eab33525d08d6e5fb8d27136e95/a/p/apple-iphone-7_black_front_8.png"
            };

            return new List<ProductViewModel>()
            {
                tv,
                laptop,
                fircone,
                chips,
                phone
            };
        }
    }
}

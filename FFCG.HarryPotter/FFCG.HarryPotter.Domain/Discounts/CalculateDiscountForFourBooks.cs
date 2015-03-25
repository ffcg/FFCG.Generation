using System.Collections.Generic;
using System.Linq;

namespace FFCG.HarryPotter.Domain.Discounts
{
    public class CalculateDiscountForFourBooks : ICalculateDiscountForBooks
    {
        public decimal Calculate(List<Book> books)
        {
            var currentValue = books.Sum(x => x.Price);

            if (books.Count != 4) return 0;
           
            return currentValue * 0.2m;
        }
    }
}
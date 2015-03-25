using System.Collections.Generic;
using System.Linq;

namespace FFCG.HarryPotter.Domain.Discounts
{
    public class CalculateDiscountForTwoBooks : ICalculateDiscountForBooks
    {
        public decimal Calculate(List<Book> books)
        {
            var currentValue = books.Sum(x => x.Price);

            if (books.Count != 2) return 0;
            return currentValue * 0.05m;
        }
    }
}
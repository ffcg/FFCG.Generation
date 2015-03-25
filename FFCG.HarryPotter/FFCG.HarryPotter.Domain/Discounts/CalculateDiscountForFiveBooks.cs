using System.Collections.Generic;
using System.Linq;

namespace FFCG.HarryPotter.Domain.Discounts
{
    public class CalculateDiscountForFiveBooks : ICalculateDiscountForBooks
    {
        public decimal Calculate(List<Book> books)
        {
            var currentValue = books.Sum(x => x.Price);

            if (books.Count != 5) return 0;

            return currentValue * 0.25m;
        }
    }
}
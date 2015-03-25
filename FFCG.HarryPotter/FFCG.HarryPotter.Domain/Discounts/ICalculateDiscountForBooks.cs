using System.Collections.Generic;

namespace FFCG.HarryPotter.Domain.Discounts
{
    public interface ICalculateDiscountForBooks
    {
        decimal Calculate(List<Book> books);
    }
}
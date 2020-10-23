using Agility.Web.eCommerce.API.Models;

namespace Agility.Web.eCommerce.Taxes
{
    public interface ITaxCalculator
    {
        Tax CalculateTaxAmount(Order order);

        long CalculateTaxAmount(OrderItem orderItem);
    }
}

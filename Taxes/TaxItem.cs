namespace Agility.Web.eCommerce.Taxes
{
    public class TaxItem
    {
        /// <summary>
        /// Gets or sets the order item ID.
        /// </summary>
        public int OrderItemID { get; set; } = 0;

        /// <summary>
        /// Gets or sets the tax amount, in minor units. Ecommerce.Data.Models is TaxValueMinorUnits not TaxAmountMinorUnits. 
        /// </summary>
        public long TaxValueMinorUnits { get; set; } = 0;

        /// <summary>
        /// Gets or sets the tax rate applied to the order item,
        /// in minor units.
        /// </summary>
        public int TaxRateMinorUnits { get; set; } = 0;

        /// <summary>
        /// Gets or sets the tax rate's finance key to the order item
        /// </summary>
        public string TaxRateFinanceKey { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ticket ID.
        /// </summary>
        public int TicketID { get; set; } = 0;

        /// <summary>
        /// Gets or sets the ticket variant measure ID.
        /// </summary>
        public int TicketVariantMeasureID { get; set; } = 0;

        public string Title { get; set; }
    }
}

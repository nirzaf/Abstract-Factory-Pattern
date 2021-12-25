using Abstract_Factory_Pattern.Business.Models.Commerce;
using Abstract_Factory_Pattern.Business.Models.Commerce.Invoice;
using Abstract_Factory_Pattern.Business.Models.Commerce.Summary;
using Abstract_Factory_Pattern.Business.Models.Shipping;
using Abstract_Factory_Pattern.Business.Models.Shipping.Factories;

namespace Abstract_Factory_Pattern.Business
{
    public class AustraliaPurchaseProviderFactory : IPurchaseProviderFactory
    {
        public IInvoice CreateInvoice(Order order)
        {
            return new GSTInvoice();
        }

        public ShippingProvider CreateShippingProvider(Order order)
        {
            var shippingProviderFactory = new StandardShippingProviderFactory();

            return shippingProviderFactory.GetShippingProvider(order.Sender.Country);
        }

        public ISummary CreateSummary(Order order)
        {
            return new CsvSummary();
        }
    }
}

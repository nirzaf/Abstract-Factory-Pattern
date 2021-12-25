using Abstract_Factory_Pattern.Business.Models.Commerce;
using Abstract_Factory_Pattern.Business.Models.Commerce.Invoice;
using Abstract_Factory_Pattern.Business.Models.Commerce.Summary;
using Abstract_Factory_Pattern.Business.Models.Shipping;

namespace Abstract_Factory_Pattern.Business
{
    public interface IPurchaseProviderFactory
    {
        ShippingProvider CreateShippingProvider(Order order);
        IInvoice CreateInvoice(Order order);
        ISummary CreateSummary(Order order);
    }
}

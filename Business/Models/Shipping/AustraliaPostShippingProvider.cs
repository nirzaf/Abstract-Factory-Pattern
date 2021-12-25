using Abstract_Factory_Pattern.Business.Models.Commerce;
using System;

namespace Abstract_Factory_Pattern.Business.Models.Shipping
{
    public class AustraliaPostShippingProvider : ShippingProvider
    {
        private readonly string clientId;
        private readonly string secret;

        public AustraliaPostShippingProvider(
            string clientId,
            string secret,
            ShippingCostCalculator shippingCostCalculator,
            CustomsHandlingOptions customsHandlingOptions,
            InsuranceOptions insuranceOptions)
        {
            this.clientId = clientId;
            this.secret = secret;
            
            ShippingCostCalculator = shippingCostCalculator;
            CustomsHandlingOptions = customsHandlingOptions;
            InsuranceOptions = insuranceOptions;
        }

        public override string GenerateShippingLabelFor(Order order)
        {
            var shippingId = GetShippingId();

            if (order.Recipient.Country != order.Sender.Country)
            {
                throw new NotSupportedException("International shipping not supported");
            }

            var shippingCost = ShippingCostCalculator.CalculateFor(order.Recipient.Country,
                order.Sender.Country,
                order.TotalWeight);

            return $"Shipping Id: {shippingId} {Environment.NewLine}" +
                    $"To: {order.Recipient.To} {Environment.NewLine}" +
                    $"Order total: {order.Total} {Environment.NewLine}" +
                    $"Tax: {CustomsHandlingOptions.TaxOptions} {Environment.NewLine}" +
                    $"Shipping Cost: {shippingCost}";
        }

        private string GetShippingId()
        {
            // Invoke API with API Key

            return $"AUS-{Guid.NewGuid()}";
        }
    }
}

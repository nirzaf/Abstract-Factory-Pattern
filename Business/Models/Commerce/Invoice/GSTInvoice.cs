using System.Text;

namespace Abstract_Factory_Pattern.Business.Models.Commerce.Invoice
{
    public class GSTInvoice : IInvoice
    {
        public byte[] GenerateInvoice()
        {
            return 
                Encoding
                .Default
                .GetBytes("Hello world from a GST Invoice");
        }
    }
}

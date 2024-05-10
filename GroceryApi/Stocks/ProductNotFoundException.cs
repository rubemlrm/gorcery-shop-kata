namespace GroceryApi.Stocks
{
    public class ProductNotFoundExceptionException : System.Exception
    {
        public ProductNotFoundExceptionException() { }
        public ProductNotFoundExceptionException(string message) : base(message) { }
        public ProductNotFoundExceptionException(string message, System.Exception inner) : base(message, inner) { }
        protected ProductNotFoundExceptionException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}

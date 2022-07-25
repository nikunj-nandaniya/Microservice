namespace Web.Common
{
    public class APIBase
    {
        public static string ProductAPIBase { get; set; }

        public enum ApiType
        { 
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}

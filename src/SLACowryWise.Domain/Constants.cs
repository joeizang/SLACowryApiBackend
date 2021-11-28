namespace SLACowryWise.Domain
{
    public static class Constants
    {
        public static string ContentTypeAppJson { get; } = "application/json";
        public static string ContentTypeFormUrlEnc { get; } = "application/x-www-form-urlencoded";
        
        public static int MAXDURATIONDAYS = 180;
        public static int MINDURATIONDAYS = 30;
    }
}
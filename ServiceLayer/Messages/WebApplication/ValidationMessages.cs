namespace ServiceLayer.Messages.WebApplication
{
    public static class ValidationMessages
    {
        public static string NullOrEmptyMessage(string propName)
        {
            return $"{propName} is required!"; 
        }
        public static string MaxLengthMessage(string propName, int maxLength)
        {
            return $"{propName} length can not be more than {maxLength} characters!"; 
        }
        public static string GreaterThanMessage(string propName, int min)
        {
            return $"{propName} must be greater than {min}!"; 
        }
        public static string LessThanMessage(string propName, int max)
        {
            return $"{propName} must be less than {max}!"; 
        }
    }
}

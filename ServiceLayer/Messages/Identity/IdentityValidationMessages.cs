namespace ServiceLayer.Messages.Identity
{
    public static class IdentityValidationMessages
    {
        public static string InvalidEmailAddressMessage()
        {
            return $"Invalid Email Address!";
        }
        public static string ComparePasswordsMessage()
        {
            return $"Passwords does not match!";
        }
    }
}

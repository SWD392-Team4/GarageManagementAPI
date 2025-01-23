namespace GarageManagementAPI.Shared.Constant.Authentication
{
    public static class UserErrorMessages
    {
        // Username Errors
        public const string UsernameRequired = "The username is required.";
        public const string UsernameTooShort = "The username must be at least 5 characters long.";
        public const string UsernameTooLong = "The username must not exceed 25 characters.";

        // Name Errors
        public const string FirstNameRequired = "The first name is required.";
        public const string LastNameRequired = "The last name is required.";

        // Email Errors
        public const string EmailRequired = "The email address is required.";
        public const string EmailInvalid = "The provided email address is invalid.";

        // Password Errors
        public const string PasswordRequired = "The password is required.";
        public const string PasswordTooShort = "The password must be at least 10 characters long.";
        public const string PasswordTooLong = "The password must not exceed 50 characters.";
        public const string PasswordMissingUppercase = "The password must contain at least one uppercase letter.";
        public const string PasswordMissingLowercase = "The password must contain at least one lowercase letter.";
        public const string PasswordMissingDigit = "The password must contain at least one number.";
        public const string PasswordMissingSpecialCharacter = "The password must contain at least one special character (e.g., !, ?, *, .).";

        // Confirm Password Errors
        public const string ConfirmPasswordRequired = "The confirmation password is required.";
        public const string ConfirmPasswordMismatch = "The confirmation password does not match the password.";

        // Phone Number Errors
        public const string PhoneNumberRequired = "The phone number is required.";
        public const string PhoneNumberInvalid = "The phone number is invalid. Ensure it is a valid Vietnamese phone number.";

        // Role Errors
        public const string RoleRequired = "The user role is required.";
        public const string RoleInvalid = "The provided user role is invalid.";
    }
}

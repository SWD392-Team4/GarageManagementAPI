using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.Constant.Authentication
{
    public static class UserErrors
    {
        //User
        public const string UserExisted = "The provided user with email {0}, username {1} and phonenumber {2} is already existed.";

        // Username Errors
        public const string UsernameRequired = "The username is required.";
        public const string UsernameTooShort = "The username must be at least 5 characters long.";
        public const string UsernameTooLong = "The username must not exceed 25 characters.";
        public const string UsernameContainSpecialCharacter = " The username can not contain special character.";

        // Name Errors
        public const string FirstNameRequired = "The first name is required.";
        public const string LastNameRequired = "The last name is required.";

        // Email Errors
        public const string EmailRequired = "The email address is required.";
        public const string EmailAlreadyConfirmed = "This email is already confirmed.";
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

        //Current Password Errors
        public const string CurrentPasswordRequired = "The current password is required.";

        // Phone Number Errors
        public const string PhoneNumberRequired = "The phone number is required.";
        public const string PhoneNumberInvalid = "The phone number is invalid. Ensure it is a valid Vietnamese phone number.";

        // Role Errors
        public const string RoleRequired = "The user role is required.";
        public const string RoleInvalid = "The provided user role is invalid.";
        public const string DoNotHavePermission = "You are not authorized to create users with this role.";

        //WorkplaceId errors
        public const string WorkplaceIdRequired = " The user work place type required.";

        //CitizenIdentification errors
        public const string CitizenIdentificationRequied = "The employee citizen identification is requied.";
        public const string CitizenIdentificationInvalid = "The employee citizen identification is invalid. Ensure it is a valid Vietnamese citizen identification.";

        //employee existed
        public const string EmployeeExisted = "The employee with citizen identification {0} existed.";

        //NotFoundErrors
        public const string UserNotFoundWithEmail = "Can not found user with email {0}.";
        public const string UserNotFoundWithUsername = "Can not found user with username {0}.";
        public const string UserNotFoundWithId = "Can not found user with id {0}.";

        //UnauthorizeUser
        public const string ConfirmEmailRequired = "Email not confirmed.";


        //Token
        public const string TokenConfirmEmailRequired = "Token use for confirm email is required.";
        public const string TokenResetPasswordRequired = "Token use for reset password is required.";


        //Wrong enpoint to create customer
        public const string InvalidEndpoint = "The endpoint used is incorrect for creating a customer. Please verify the URL and try again.";
        public static ErrorsResult GetUnAuthorizedToCreateUserErrors()
        {
            return new()
            {
                Code = nameof(DoNotHavePermission),
                Description = DoNotHavePermission,
            };
        }

        public static ErrorsResult GetUserNotFoundWithEmailError(string email)
        {
            return new()
            {
                Code = nameof(UserNotFoundWithEmail),
                Description = string.Format(UserNotFoundWithEmail, email),
            };
        }

        public static ErrorsResult GetUserNotFoundWithUsernameError(string username)
        {
            return new()
            {
                Code = nameof(UserNotFoundWithUsername),
                Description = string.Format(UserNotFoundWithUsername, username),
            };
        }

        public static ErrorsResult GetConfirmEmailRequiredError()
        {
            return new()
            {
                Code = nameof(ConfirmEmailRequired),
                Description = ConfirmEmailRequired
            };
        }

        public static ErrorsResult GetEmailAlreadyConfirmedError()
        {
            return new()
            {
                Code = nameof(EmailAlreadyConfirmed),
                Description = EmailAlreadyConfirmed
            };
        }

        public static ErrorsResult GetUserExistedError(string email, string userName, string phoneNumber)
        {
            return new()
            {
                Code = nameof(UserExisted),
                Description = string.Format(UserExisted, email, userName, phoneNumber)
            };
        }

        public static ErrorsResult GetInvalidEndpointError()
        {
            return new()
            {
                Code = nameof(InvalidEndpoint),
                Description = InvalidEndpoint
            };
        }

        public static ErrorsResult GetEmployeeExistedError(string citizenIdentification)
        {
            return new()
            {
                Code = nameof(EmployeeExisted),
                Description = string.Format(EmployeeExisted, citizenIdentification)
            };
        }

        public static ErrorsResult GetUserNotFoundWithIdError()
        {
            return new()
            {
                Code = nameof(UserNotFoundWithId),
                Description = UserNotFoundWithId
            };
        }
    }
}

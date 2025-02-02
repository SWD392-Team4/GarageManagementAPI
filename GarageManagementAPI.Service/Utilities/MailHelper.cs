namespace GarageManagementAPI.Service.Utilities
{
    public class MailHelper
    {
        public static string ConfirmEmailTemplate(string url)
        {
            return $@"
                <!DOCTYPE html>
                <html lang=""en"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Confirm Your Email</title>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            background-color: #f4f4f4;
                            margin: 0;
                            padding: 20px;
                            text-align: center;
                        }}
                        .email-container {{
                            max-width: 600px;
                            background: #ffffff;
                            padding: 20px;
                            border-radius: 8px;
                            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                            margin: auto;
                        }}
                        h2 {{
                            color: #333;
                        }}
                        p {{
                            font-size: 16px;
                            color: #555;
                        }}
                        .button {{
                            display: inline-block;
                            padding: 10px 20px;
                            font-size: 16px;
                            color: #ffffff;
                            background: #007bff;
                            text-decoration: none;
                            border-radius: 5px;
                            margin-top: 20px;
                        }}
                        .button:hover {{
                            background: #0056b3;
                        }}
                    </style>
                </head>
                <body>
                    <div class=""email-container"">
                        <h2>Welcome to Our Service!</h2>
                        <p>Thank you for signing up. Please confirm your email by clicking the button below.</p>
                        <a href=""{url}"" class=""button"">Confirm Email</a>
                        <p>If you did not request this, please ignore this email.</p>
                    </div>
                </body>
                </html>";
        }
        public static string ForgotPasswordTemplate(string url)
        {
            return $@"
                <!DOCTYPE html>
                <html lang=""en"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Reset Your Password</title>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            background-color: #f4f4f4;
                            margin: 0;
                            padding: 20px;
                            text-align: center;
                        }}
                        .email-container {{
                            max-width: 600px;
                            background: #ffffff;
                            padding: 20px;
                            border-radius: 8px;
                            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                            margin: auto;
                        }}
                        h2 {{
                            color: #333;
                        }}
                        p {{
                            font-size: 16px;
                            color: #555;
                        }}
                        .button {{
                            display: inline-block;
                            padding: 10px 20px;
                            font-size: 16px;
                            color: #ffffff;
                            background: #dc3545;
                            text-decoration: none;
                            border-radius: 5px;
                            margin-top: 20px;
                        }}
                        .button:hover {{
                            background: #b02a37;
                        }}
                    </style>
                </head>
                <body>
                    <div class=""email-container"">
                        <h2>Password Reset Request</h2>
                        <p>We received a request to reset your password. Click the button below to set a new password:</p>
                        <a href=""{url}"" class=""button"">Reset Password</a>
                        <p>If you did not request this, please ignore this email.</p>
                        <p>For security reasons, this link will expire in 5 hours.</p>
                    </div>
                </body>
                </html>";
        }
    }
}

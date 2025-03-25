using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.Extension;

using System.Text;

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

        public static string ConfirmEmailEmployeeTemplate(string fullName, string username, string password, string url)
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
                        <h2>Welcome {fullName} to Our Team!</h2>
                        <p>Here is your account.</p>
                        <p>username: <strong>{username}</strong></p>
                        <p>password: <strong>{password}</strong></p>
                        <p>To use this account please confirm your account by clicking the button below.</p>
                        <a href=""{url}"" class=""button"">Confirm Email</a>
                        <p>If you did not request this, please ignore this email.</p>
                    </div>
                </body>
                </html>";
        }

        public static string InfoAppointmentTemplate(string verfifyCode, Workplace garage, DateTimeOffset appointmentDateTime, IEnumerable<AppointmentDetail> appointmentDetails, IEnumerable<AppointmentDetailPackage> appointmentDetailPackages)
        {
            StringBuilder html = new StringBuilder();
            html.Append("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n  <head>\r\n    <meta charset=\"UTF-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <title>Document</title>\r\n  </head>\r\n  <body>");
            html.Append("<div class=\"email-container\">");
            html.Append($"<p>Mã lịch hẹn: <strong>{verfifyCode}</strong></p>\r\n        <p>Ngày giờ dự kiến: <strong>{ToVietnameseDateTimeFormat(appointmentDateTime)}</strong></p>");
            html.Append($"<p>Tại garage: {garage.Name} tại địa chỉ {garage.Address}, {garage.Province}, {garage.District}, {garage.Ward}.</p>");
            var earliestCreationDate = appointmentDetails.Any() ? appointmentDetails.Min(ad => ad.CreateAt) : DateTimeOffset.MaxValue;
            var newlyAddedDetails = appointmentDetails.Where(ad => ad.Status == AppointmentDetailStatus.Pending && ad.CreateAt > earliestCreationDate).ToList();

            // Show notification about newly added services if any exist
            if (newlyAddedDetails.Any())
            {
                html.Append("<div style=\"background-color: #ffffd0; padding: 15px; border-left: 4px solid #ffcc00; margin: 15px 0;\">");
                html.Append("<h3 style=\"color: #cc8800; margin-top: 0;\">Dịch vụ mới được thêm vào</h3>");
                html.Append("<p>Các dịch vụ sau đây đã được thêm vào cuộc hẹn của bạn:</p>");
                html.Append("<ul>");
                foreach (var detail in newlyAddedDetails)
                {
                    html.Append($"<li>{detail.ServiceHistory.Service.ServiceName} - {(detail.PackageHistoryId != null ? 0 : detail.ServiceHistory.Price):N0} VNĐ</li>");
                }
                html.Append("</ul>");

                // Add confirmation action buttons - UPDATED TO MATCH API ENDPOINTS
                html.Append("<div style=\"margin-top: 20px; padding: 15px; border-top: 1px solid #eee;\">");
                html.Append("<p style=\"font-weight: bold;\">Bạn có muốn xác nhận các dịch vụ mới này không?</p>");

                // Get all detail IDs for the links
                var allDetailIds = string.Join(",", newlyAddedDetails.Select(d => d.Id));

                // Direct API links section
                html.Append("<div style=\"margin-top: 15px; display: flex; flex-wrap: wrap; justify-content: center; gap: 10px;\">");

                // Confirm all link - Uses the exact endpoint format from your controller
                html.Append($"<a href=\"https://turbotrack-amdehbb2gfdbgucf.southeastasia-01.azurewebsites.net/api/workplaces/{garage.Id}/appointments/{appointmentDetails.First().AppointmentId}/details/email/confirm/({allDetailIds})\" " +
                            "style=\"display: inline-block; background-color: #28a745; color: white; text-decoration: none; " +
                            "padding: 10px 20px; border-radius: 4px; font-weight: bold;\">" +
                            "Xác nhận tất cả dịch vụ</a>");

                // Reject all link - Uses the exact endpoint format from your controller
                html.Append($"<a href=\"https://turbotrack-amdehbb2gfdbgucf.southeastasia-01.azurewebsites.net/api/workplaces/{garage.Id}/appointments/{appointmentDetails.First().AppointmentId}/details/email/reject/({allDetailIds})\" " +
                            "style=\"display: inline-block; background-color: #dc3545; color: white; text-decoration: none; " +
                            "padding: 10px 20px; border-radius: 4px; font-weight: bold;\">" +
                            "Từ chối tất cả dịch vụ</a>");

                html.Append("</div>");

                // Individual confirmation links section (optional)
                html.Append("<div style=\"margin-top: 20px;\">");
                html.Append("<p style=\"font-size: 14px;\">Hoặc xác nhận/từ chối từng dịch vụ:</p>");
                html.Append("<div style=\"display: flex; flex-wrap: wrap; justify-content: center; gap: 10px;\">");

                foreach (var detail in newlyAddedDetails)
                {
                    // Confirm single service link
                    html.Append($"<a href=\"https://turbotrack-amdehbb2gfdbgucf.southeastasia-01.azurewebsites.net/api/workplaces/{garage.Id}/appointments/{detail.AppointmentId}/details/email/confirm/({detail.Id})\" " +
                                "style=\"display: inline-block; background-color: #28a745; color: white; text-decoration: none; " +
                                "padding: 8px 12px; border-radius: 4px; margin-bottom: 5px; font-size: 12px;\">" +
                                $"✓ {detail.ServiceHistory.Service.ServiceName}</a>");

                    // Reject single service link
                    html.Append($"<a href=\"https://turbotrack-amdehbb2gfdbgucf.southeastasia-01.azurewebsites.net/api/workplaces/{garage.Id}/appointments/{detail.AppointmentId}/details/email/reject/({detail.Id})\" " +
                                "style=\"display: inline-block; background-color: #dc3545; color: white; text-decoration: none; " +
                                "padding: 8px 12px; border-radius: 4px; margin-bottom: 5px; font-size: 12px;\">" +
                                $"✗ {detail.ServiceHistory.Service.ServiceName}</a></br>");
                }

                html.Append("</div>");
                html.Append("</div>");

                // Add an explanatory message
                html.Append("<p style=\"font-size: 12px; color: #666; margin-top: 15px;\">" +
                            "Nhấn vào các liên kết phía trên để xác nhận hoặc từ chối các dịch vụ. " +
                            "Hoặc gọi đến số <strong>0343663841</strong> để được hỗ trợ trực tiếp.</p>");

                html.Append("</div>");
                html.Append("</div>");
            }
            decimal totalPrice = 0;
            if (appointmentDetailPackages.Any())
            {
                html.Append("<h3>Danh sách gói dịch vụ:</h3>\r\n    <ul>");
                foreach (var package in appointmentDetailPackages)
                {
                    html.Append($"<li>{package.PackageHistory.PackageName} - {package.PackageHistory.PackagePrice:N0} VNĐ</li>");
                    totalPrice += package.PackageHistory.PackagePrice;
                }
                html.Append("</ul>");
            }

            html.Append("<h3>Danh sách dịch vụ:</h3>\r\n    <ul>");
            foreach (var appointmentDetail in appointmentDetails)
            {
                html.Append($"<li>{appointmentDetail.ServiceHistory.Service.ServiceName} - {(appointmentDetail.PackageHistoryId != null ? 0 : appointmentDetail.ServiceHistory.Price):N0} VNĐ</li>");
                if (appointmentDetail.AppointmentReplacementParts.Any())
                {
                    html.Append("<ul>");
                    foreach (var part in appointmentDetail.AppointmentReplacementParts)
                    {
                        html.Append($"<li>{part.ProductHistory.Product.ProductName} - {part.ProductHistory.ProductPrice:N0} VNĐ</li>");
                        totalPrice += part.ProductHistory.ProductPrice;
                    }
                    html.Append("</ul>");
                }
                totalPrice += appointmentDetail.PackageHistoryId.HasValue ? 0 : appointmentDetail.ServiceHistory.Price;
            }
            html.Append("</ul>");

            html.Append($"<h3>Tổng chi phí dự kiến: <strong>{totalPrice:N0} VNĐ</strong></h3>");

            html.Append($"<h3>Nếu bạn muốn hủy lịch hẹn:</h3>\r\n  <p>\r\n        <strong>Cách 1:</strong> Sử dụng mã hủy lịch:\r\n        <span style=\"background: #eee; padding: 5px; font-weight: bold\"\r\n          >{verfifyCode}</span\r\n        >\r\n        tại trang web của chúng tôi.\r\n      </p>\r\n      <p>\r\n        <strong>Cách 2:</strong> Gọi hotline:\r\n        <strong>0343663841</strong> và cung cấp mã lịch hẹn.\r\n      </p>\r\n\r\n      <p style=\"color: #666; font-style: italic\">\r\n        Lưu ý: Vui lòng hủy lịch trước {ToVietnameseDateTimeFormat(appointmentDateTime)}, sau khoảng thời gian này vui lòng gọi đến hotline để có thể hủy.\r\n      </p>\r\n    </div>");
            html.Append("</body></html>");

            return html.ToString();
        }

        public static string InfoAppointmentAfterConfirmationTemplate(string verifyCode, Workplace garage, DateTimeOffset appointmentDateTime, IEnumerable<AppointmentDetail> appointmentDetails, IEnumerable<AppointmentDetailPackage> appointmentDetailPackages, AppointmentStatus appointmentStatus, User? user = null, string? cancellationReason = null)
        {
            StringBuilder html = new StringBuilder();
            html.Append("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n  <head>\r\n    <meta charset=\"UTF-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <title>Document</title>\r\n  </head>\r\n  <body>");
            html.Append("<div class=\"email-container\">");
            html.Append($"<p>Mã lịch hẹn: <strong>{verifyCode}</strong></p>\r\n        <p>Ngày giờ dự kiến: <strong>{ToVietnameseDateTimeFormat(appointmentDateTime)}</strong></p>");


            if (user != null && appointmentStatus.Equals(AppointmentStatus.Approved))
            {
                html.Append($"<p>Đây là lịch hẹn của bạn sau khi đã được xác nhận bởi {user.LastName} {user.FirstName}</p>");
                html.Append($"<p>Tại garage: {garage.Name} tại địa chỉ {garage.Address}, {garage.Province}, {garage.District}, {garage.Ward}.</p>");
                html.Append($"<p>Đây là các dịch vụ của bạn sau khi được xác nhận lại, các gói dịch vụ sau khi được xác nhận.</p>");

                // Get the earliest creation date to identify original services
                var earliestCreationDate = appointmentDetails.Any() ? appointmentDetails.Min(ad => ad.CreateAt) : DateTimeOffset.MaxValue;
                var newlyAddedDetails = appointmentDetails.Where(ad => ad.Status == AppointmentDetailStatus.Pending && ad.CreateAt > earliestCreationDate).ToList();

                // Show notification about newly added services if any exist
                if (newlyAddedDetails.Any())
                {
                    html.Append("<div style=\"background-color: #ffffd0; padding: 15px; border-left: 4px solid #ffcc00; margin: 15px 0;\">");
                    html.Append("<h3 style=\"color: #cc8800; margin-top: 0;\">Dịch vụ mới được thêm vào</h3>");
                    html.Append("<p>Các dịch vụ sau đây đã được thêm vào cuộc hẹn của bạn:</p>");
                    html.Append("<ul>");
                    foreach (var detail in newlyAddedDetails)
                    {
                        html.Append($"<li>{detail.ServiceHistory.Service.ServiceName} - {(detail.PackageHistoryId != null ? 0 : detail.ServiceHistory.Price):N0} VNĐ</li>");
                    }
                    html.Append("</ul>");

                    // Add confirmation action buttons - UPDATED TO MATCH API ENDPOINTS
                    html.Append("<div style=\"margin-top: 20px; padding: 15px; border-top: 1px solid #eee;\">");
                    html.Append("<p style=\"font-weight: bold;\">Bạn có muốn xác nhận các dịch vụ mới này không?</p>");

                    // Get all detail IDs for the links
                    var allDetailIds = string.Join(",", newlyAddedDetails.Select(d => d.Id));

                    // Direct API links section
                    html.Append("<div style=\"margin-top: 15px; display: flex; flex-wrap: wrap; justify-content: center; gap: 10px;\">");

                    // Confirm all link - Uses the exact endpoint format from your controller
                    html.Append($"<a href=\"https://turbotrack-amdehbb2gfdbgucf.southeastasia-01.azurewebsites.net/api/workplaces/{garage.Id}/appointments/{appointmentDetails.First().AppointmentId}/details/email/confirm/({allDetailIds})\" " +
                                "style=\"display: inline-block; background-color: #28a745; color: white; text-decoration: none; " +
                                "padding: 10px 20px; border-radius: 4px; font-weight: bold;\">" +
                                "Xác nhận tất cả dịch vụ</a>");

                    // Reject all link - Uses the exact endpoint format from your controller
                    html.Append($"<a href=\"https://turbotrack-amdehbb2gfdbgucf.southeastasia-01.azurewebsites.net/api/workplaces/{garage.Id}/appointments/{appointmentDetails.First().AppointmentId}/details/email/reject/({allDetailIds})\" " +
                                "style=\"display: inline-block; background-color: #dc3545; color: white; text-decoration: none; " +
                                "padding: 10px 20px; border-radius: 4px; font-weight: bold;\">" +
                                "Từ chối tất cả dịch vụ</a>");

                    html.Append("</div>");

                    // Individual confirmation links section (optional)
                    html.Append("<div style=\"margin-top: 20px;\">");
                    html.Append("<p style=\"font-size: 14px;\">Hoặc xác nhận/từ chối từng dịch vụ:</p>");
                    html.Append("<div style=\"display: flex; flex-wrap: wrap; justify-content: center; gap: 10px;\">");

                    foreach (var detail in newlyAddedDetails)
                    {
                        // Confirm single service link
                        html.Append($"<a href=\"https://turbotrack-amdehbb2gfdbgucf.southeastasia-01.azurewebsites.net/api/workplaces/{garage.Id}/appointments/{detail.AppointmentId}/details/email/confirm/({detail.Id})\" " +
                                    "style=\"display: inline-block; background-color: #28a745; color: white; text-decoration: none; " +
                                    "padding: 8px 12px; border-radius: 4px; margin-bottom: 5px; font-size: 12px;\">" +
                                    $"✓ {detail.ServiceHistory.Service.ServiceName}</a>");

                        // Reject single service link
                        html.Append($"<a href=\"https://turbotrack-amdehbb2gfdbgucf.southeastasia-01.azurewebsites.net/api/workplaces/{garage.Id}/appointments/{detail.AppointmentId}/details/email/reject/({detail.Id})\" " +
                                    "style=\"display: inline-block; background-color: #dc3545; color: white; text-decoration: none; " +
                                    "padding: 8px 12px; border-radius: 4px; margin-bottom: 5px; font-size: 12px;\">" +
                                    $"✗ {detail.ServiceHistory.Service.ServiceName}</a>");
                    }

                    html.Append("</div>");
                    html.Append("</div>");

                    // Add an explanatory message
                    html.Append("<p style=\"font-size: 12px; color: #666; margin-top: 15px;\">" +
                                "Nhấn vào các liên kết phía trên để xác nhận hoặc từ chối các dịch vụ. " +
                                "Hoặc gọi đến số <strong>0343663841</strong> để được hỗ trợ trực tiếp.</p>");

                    html.Append("</div>");
                    html.Append("</div>");
                }

                decimal totalPrice = 0;
                if (appointmentDetailPackages.Any())
                {
                    html.Append("<h3>Danh sách gói dịch vụ:</h3>\r\n    <ul>");
                    foreach (var package in appointmentDetailPackages)
                    {
                        html.Append($"<li>{package.PackageHistory.PackageName} - {package.PackageHistory.PackagePrice:N0} VNĐ</li>");
                        totalPrice += package.PackageHistory.PackagePrice;
                    }
                    html.Append("</ul>");
                }

                html.Append("<h3>Danh sách dịch vụ:</h3>\r\n    <ul>");
                foreach (var appointmentDetail in appointmentDetails)
                {
                    html.Append($"<li>{appointmentDetail.ServiceHistory.Service.ServiceName} - {(appointmentDetail.PackageHistoryId != null ? 0 : appointmentDetail.ServiceHistory.Price):N0} VNĐ</li>");
                    if (appointmentDetail.AppointmentReplacementParts.Any())
                    {
                        html.Append("<ul>");
                        foreach (var part in appointmentDetail.AppointmentReplacementParts)
                        {
                            html.Append($"<li>{part.ProductHistory.Product.ProductName} - {part.ProductHistory.ProductPrice:N0} VNĐ</li>");
                            totalPrice += part.ProductHistory.ProductPrice;
                        }
                        html.Append("</ul>");
                    }
                    totalPrice += appointmentDetail.PackageHistoryId.HasValue ? 0 : appointmentDetail.ServiceHistory.Price;
                }
                html.Append("</ul>");

                html.Append($"<h3>Tổng chi phí dự kiến: <strong>{totalPrice:N0} VNĐ</strong></h3>");

                html.Append($"<h3>Nếu bạn muốn hủy lịch hẹn:</h3>\r\n  <p>\r\n        <strong>Cách 1:</strong> Sử dụng mã hủy lịch:\r\n        <span style=\"background: #eee; padding: 5px; font-weight: bold\"\r\n          >{verifyCode}</span\r\n        >\r\n        tại trang web của chúng tôi.\r\n      </p>\r\n      <p>\r\n        <strong>Cách 2:</strong> Gọi hotline:\r\n        <strong>0343663841</strong> và cung cấp mã lịch hẹn.\r\n      </p>\r\n\r\n      <p style=\"color: #666; font-style: italic\">\r\n        Lưu ý: Vui lòng hủy lịch trước {ToVietnameseDateTimeFormat(appointmentDateTime)}, sau khoảng thời gian này vui lòng gọi đến hotline để có thể hủy.\r\n      </p>\r\n    </div>");

            }
            else if (user != null && appointmentStatus.Equals(AppointmentStatus.Rejected))
            {
                html.Append($"<p>Đây là lịch hẹn của bạn sau khi đã bị từ chối bởi nhân viên {user.LastName} {user.FirstName}</p>");
                if (!string.IsNullOrWhiteSpace(cancellationReason) && !cancellationReason.Equals("none"))
                    html.Append($"<p>Lý do hủy: {cancellationReason}</p>");

            }
            else if (appointmentStatus.Equals(AppointmentStatus.Cancelled))
            {
                html.Append($"<p>Bạn đã hủy lịch hẹn thành công</p>");

                if (!string.IsNullOrWhiteSpace(cancellationReason) && !cancellationReason.Equals("none"))
                    html.Append($"<p>Lý do hủy: {cancellationReason}</p>");
            }

            html.Append("</body></html>");

            return html.ToString();
        }

        public static string AppointmentCompletedTemplate(string verifyCode, Workplace garage, DateTimeOffset appointmentDateTime,
    IEnumerable<AppointmentDetail> appointmentDetails, IEnumerable<AppointmentDetailPackage> appointmentDetailPackages,
    DateTimeOffset? completedTime = null)
        {
            StringBuilder html = new StringBuilder();
            html.Append("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n  <head>\r\n    <meta charset=\"UTF-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <title>Appointment Completed</title>\r\n    <style>\r\n      body {\r\n        font-family: Arial, sans-serif;\r\n        line-height: 1.6;\r\n        margin: 0;\r\n        padding: 0;\r\n        color: #333;\r\n      }\r\n      .email-container {\r\n        max-width: 600px;\r\n        margin: 0 auto;\r\n        padding: 20px;\r\n        border: 1px solid #ddd;\r\n        border-radius: 5px;\r\n      }\r\n      .header {\r\n        background-color: #28a745;\r\n        color: white;\r\n        padding: 15px;\r\n        text-align: center;\r\n        border-radius: 5px 5px 0 0;\r\n        margin-bottom: 20px;\r\n      }\r\n      .header h1 {\r\n        margin: 0;\r\n        font-size: 24px;\r\n      }\r\n      .section {\r\n        margin-bottom: 20px;\r\n        padding-bottom: 20px;\r\n        border-bottom: 1px solid #eee;\r\n      }\r\n      .section-title {\r\n        font-weight: bold;\r\n        margin-bottom: 10px;\r\n        color: #28a745;\r\n      }\r\n      .summary-box {\r\n        background-color: #f8f9fa;\r\n        padding: 15px;\r\n        border-radius: 5px;\r\n        margin-bottom: 20px;\r\n      }\r\n      .total-price {\r\n        font-size: 18px;\r\n        font-weight: bold;\r\n        margin-top: 15px;\r\n        text-align: right;\r\n      }\r\n      .footer {\r\n        margin-top: 30px;\r\n        text-align: center;\r\n        color: #666;\r\n        font-size: 14px;\r\n      }\r\n      .contact {\r\n        background-color: #f8f9fa;\r\n        padding: 15px;\r\n        border-radius: 5px;\r\n        margin-top: 20px;\r\n      }\r\n      .completed-badge {\r\n        display: inline-block;\r\n        background-color: #28a745;\r\n        color: white;\r\n        padding: 5px 10px;\r\n        border-radius: 3px;\r\n        font-weight: bold;\r\n        margin-bottom: 15px;\r\n      }\r\n      .feedback-button {\r\n        display: inline-block;\r\n        background-color: #007bff;\r\n        color: white;\r\n        padding: 10px 20px;\r\n        text-decoration: none;\r\n        border-radius: 5px;\r\n        font-weight: bold;\r\n        margin-top: 15px;\r\n      }\r\n    </style>\r\n  </head>\r\n  <body>");

            html.Append("<div class=\"email-container\">");

            // Header section
            html.Append("<div class=\"header\">");
            html.Append("<h1>Dịch Vụ Đã Hoàn Thành</h1>");
            html.Append("</div>");

            // Appointment information
            html.Append("<div class=\"section\">");
            html.Append("<div class=\"completed-badge\">HOÀN THÀNH</div>");
            html.Append("<p>Kính gửi Quý khách,</p>");
            html.Append("<p>Chúng tôi xin thông báo rằng dịch vụ xe của Quý khách đã được hoàn thành.</p>");

            // Summary box with key appointment details
            html.Append("<div class=\"summary-box\">");
            html.Append($"<p><strong>Mã lịch hẹn:</strong> {verifyCode}</p>");
            html.Append($"<p><strong>Thời gian hoàn thành:</strong> {ToVietnameseDateTimeFormat(completedTime ?? DateTimeOffset.UtcNow.SEAsiaStandardTime())}</p>");
            html.Append($"<p><strong>Garage:</strong> {garage.Name}</p>");
            html.Append($"<p><strong>Địa chỉ:</strong> {garage.Address}, {garage.Province}, {garage.District}, {garage.Ward}</p>");
            html.Append("</div>");
            html.Append("</div>");

            // Services and packages provided
            decimal totalPrice = 0;

            // Packages section
            if (appointmentDetailPackages.Any())
            {
                html.Append("<div class=\"section\">");
                html.Append("<div class=\"section-title\">GÓI DỊCH VỤ ĐÃ CUNG CẤP</div>");
                html.Append("<ul>");
                foreach (var package in appointmentDetailPackages)
                {
                    html.Append($"<li>{package.PackageHistory.PackageName} - {package.PackageHistory.PackagePrice:N0} VNĐ</li>");
                    totalPrice += package.PackageHistory.PackagePrice;
                }
                html.Append("</ul>");
                html.Append("</div>");
            }

            // Services section
            if (appointmentDetails.Any())
            {
                html.Append("<div class=\"section\">");
                html.Append("<div class=\"section-title\">DỊCH VỤ ĐÃ THỰC HIỆN</div>");
                html.Append("<ul>");
                foreach (var appointmentDetail in appointmentDetails)
                {
                    html.Append($"<li>{appointmentDetail.ServiceHistory.Service.ServiceName} - {(appointmentDetail.PackageHistoryId != null ? 0 : appointmentDetail.ServiceHistory.Price):N0} VNĐ</li>");

                    if (appointmentDetail.AppointmentReplacementParts.Any())
                    {
                        html.Append("<ul>");
                        foreach (var part in appointmentDetail.AppointmentReplacementParts)
                        {
                            html.Append($"<li>{part.ProductHistory.Product.ProductName} - {part.ProductHistory.ProductPrice:N0} VNĐ</li>");
                            totalPrice += part.ProductHistory.ProductPrice;
                        }
                        html.Append("</ul>");
                    }

                    if (appointmentDetail.PackageHistoryId == null)
                        totalPrice += appointmentDetail.ServiceHistory.Price;
                }
                html.Append("</ul>");
                html.Append("</div>");
            }

            // Total price
            html.Append($"<div class=\"total-price\">Tổng chi phí: <span style=\"color: #28a745;\">{totalPrice:N0} VNĐ</span></div>");

            // Feedback request
            html.Append("<div class=\"section\">");
            html.Append("<div class=\"section-title\">ĐÁNH GIÁ DỊCH VỤ</div>");
            html.Append("<p>Chúng tôi rất mong nhận được phản hồi của Quý khách về trải nghiệm dịch vụ vừa qua. Đánh giá của Quý khách sẽ giúp chúng tôi cải thiện chất lượng phục vụ.</p>");
            html.Append($"<a href=\"https://tbturbotrack.netlify.app/feedback/{verifyCode}\" class=\"feedback-button\">Đánh giá ngay</a>");
            html.Append("</div>");

            // Contact information
            html.Append("<div class=\"contact\">");
            html.Append("<div class=\"section-title\">LIÊN HỆ VỚI CHÚNG TÔI</div>");
            html.Append("<p>Nếu Quý khách có bất kỳ thắc mắc nào, vui lòng liên hệ với chúng tôi:</p>");
            html.Append("<p><strong>Hotline:</strong> 0343663841</p>");
            html.Append("</div>");

            // Footer
            html.Append("<div class=\"footer\">");
            html.Append("<p>Cảm ơn Quý khách đã sử dụng dịch vụ của chúng tôi.</p>");
            html.Append($"<p>&copy; {DateTime.Now.Year} {garage.Name}. Tất cả các quyền được bảo lưu.</p>");
            html.Append("</div>");

            html.Append("</div>");
            html.Append("</body></html>");

            return html.ToString();
        }

        public static string ToVietnameseDateTimeFormat(DateTimeOffset dateTime)
        {

            // Format the date part
            string datePart = dateTime.ToString("dd/MM/yyyy");

            // Format the time part
            string timePart = dateTime.ToString("HH:mm");

            // Determine if it's morning or afternoon/evening
            string timeOfDay = dateTime.Hour < 12 ? "sáng" : "chiều";

            // Combine the parts
            return $"{datePart} vào lúc {timePart} {timeOfDay}";
        }
    }
}

# WINDOWS SERVICE HOURLY MAIL SENDER

This project provides a Windows Service that sends emails on an hourly schedule. It is designed to automate email notifications or reports without requiring manual intervention. The service can be configured to send messages to specified recipients, making it useful for system administrators, report automation, or scheduled reminders.

## Features

- Runs as a background Windows Service
- Sends emails automatically every hour
- Configurable email content, subject, and recipients
- Logs service activity for monitoring and troubleshooting
- Can be customized to fetch dynamic content for emails

## Getting Started

### Prerequisites

- Windows operating system
- .NET Framework (version depends on your implementation, e.g., .NET Framework 4.7.2 or above)
- SMTP server details (host, port, credentials) for sending emails

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/ASWIN-SENTHILKUMAR2006/WINDOWS-SERVICE-HOURLY-MAIL-SENDER-.git
   ```

2. **Open the solution in Visual Studio.**

3. **Configure SMTP settings:**
   - Edit the `App.config` or relevant configuration file to provide your SMTP server details and email settings.

4. **Build the solution.**

5. **Install the Windows Service:**
   - Open Command Prompt as Administrator.
   - Navigate to the output directory (e.g., `bin\Release`).
   - Use `sc.exe` or `installutil.exe` to install the service:
     ```bash
     installutil WINDOWS_SERVICE_HOURLY_MAIL_SENDER.exe
     ```
   - Start the service from the Services management console or using:
     ```bash
     net start "WINDOWS_SERVICE_HOURLY_MAIL_SENDER"
     ```

## Configuration

Edit the configuration file (e.g., `App.config`) to set:
- SMTP server address and port
- Sender email address and password
- Recipient email addresses
- Email subject and body template
- Logging preferences

## Usage

Once installed and started, the Windows Service will send emails every hour as per the configuration. Check the service logs for information about sent emails and errors.

## Logging & Troubleshooting

- Log files are created in the specified log directory.
- Service activity, errors, and email status are recorded for easy monitoring.

## Customization

- You can modify the service code to fetch dynamic email content (e.g., database queries, API calls).
- Adjust the schedule by editing the timer interval in the source code if you need a different frequency.

## Contributing

Contributions are welcome! Please open issues or pull requests for improvements or bug fixes.

## License

This project is licensed under the MIT License.

---

**Author**: [ASWIN-SENTHILKUMAR2006](https://github.com/ASWIN-SENTHILKUMAR2006)

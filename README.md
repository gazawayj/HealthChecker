# MAUI Health Log

This project is a personal exploration into the capabilities of **.NET MAUI** for cross-platform development, focusing on how **Google Gemini** and data from smart health peripherals might converge to revolutionize health diagnostics.

## Project Overview

The MAUI Health Log is designed to create a detailed, minute-by-minute health log by integrating:

* **User input:** Direct user-provided information about their health status and activities.
* **Smart peripheral data:** Health readings (e.g., heart rate, blood pressure, glucose levels) collected from wearable devices and other smart health gadgets.
* **Google Gemini:** Leveraging Google Gemini's advanced AI capabilities to process and interpret the combined data, approximating future diagnostic methodologies.

This project serves as a forward-looking exercise to understand how AI-driven analysis of real-time health data could contribute to more accurate and personalized health diagnoses in the very near future.

## Features

* **Cross-Platform Compatibility:** Built with .NET MAUI, the application is intended to run seamlessly across various platforms, including iOS, Android, Windows, and macOS.
* **Data Integration:** Ability to input and integrate health data from multiple sources.
* **Minute-by-Minute Logging:** Provides a granular view of health trends and events throughout the day.
* **Gemini-Powered Insights:** Utilizes Google Gemini for intelligent analysis and preliminary diagnostic approximations based on the collected health data.

## Getting Started

### Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/download) (latest version recommended)
* [Visual Studio](https://visualstudio.microsoft.com/downloads/) with MAUI workload installed (or Visual Studio Code with C# Dev Kit and MAUI extensions)

### Installation

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/gazawayj/MauiHealthLog.git]
    cd MauiHealthLog
    ```
2.  **Restore NuGet packages:**
    ```bash
    dotnet restore
    ```
3.  **Configure Google Gemini API Key:**
    * Obtain an API key from the [Google AI Studio](https://aistudio.google.com/).
    * You will need to securely store and access this key within your application. (Consider using user secrets for development and environment variables for production.)

### Running the Application

To run the application on a specific platform:

* **Android:**
    ```bash
    dotnet build -t:Run -f net8.0-android
    ```
* **iOS:**
    ```bash
    dotnet build -t:Run -f net8.0-ios
    ```
* **Windows:**
    ```bash
    dotnet build -t:Run -f net8.0-windows
    ```
* **macOS (Mac Catalyst):**
    ```bash
    dotnet build -t:Run -f net8.0-maccatalyst
    ```

---

## Contributing

This is a personal learning project, so contributions are not actively sought at this time. However, feel free to fork the repository and experiment once functionality is added!

---

## License

MIT License

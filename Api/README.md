
![Flickr Logo](https://combo.staticflickr.com/pw/images/flickr_logo_dots.svg)

# **Flickr.Api**

Flickr.Api is a lightweight API client built in **ASP.NET Core** for interacting with the **Flickr Photo API**. This service allows you to search, fetch, and display images using Flickr's RESTful endpoints.

---

## **What is Flickr?**

Flickr is an image and video hosting web site, web services suite, and online community platform. In addition to being a popular site for users to share personal photographs and video clips, the service is widely used as a photo repository.

Read the official Flickr API documentation at [Flickr Developer API](https://www.flickr.com/services/developer/api/) or check out the source code and experiment with it.

---

## **Project Status**

**Current Version:** `1.0.0`

This version is production-ready, featuring:
- API Endpoint for searching photos (`api/Photos/search`)
- Clean error handling and logging
- Unit tests for core functionalities

---

## **Features**

- Search photos based on criteria like tags, text, date range, and more.
- Strongly-typed response models for deserialization.
- Configurable via **appsettings.json**.
- Production-ready exception handling middleware.

---

## **Prerequisites**

To run the project, ensure the following dependencies are installed:

- **[Visual Studio Code](https://code.visualstudio.com/)** or **[Visual Studio 2022](https://visualstudio.microsoft.com/vs/)**
- **[.NET 8 SDK](https://dotnet.microsoft.com/download#/current)** (Already included in Visual Studio 2022 v17.8)
- A valid **[Flickr API key](https://www.flickr.com/services/apps/create/apply/)**

---

## **Configuration**

### 1. **API Key Setup**
Set up your **Flickr API key** in `appsettings.json`:

```json
{
  "Flickr": {
    "ApiKey": "YOUR_FLICKR_API_KEY"
  }
}
```

### 2. **Running the API Locally**

1. Clone the repository:

   ```bash
   git clone https://github.com/your-repo-name.git
   cd Flickr.Api
   ```

2. Restore dependencies and build:

   ```bash
   dotnet restore
   dotnet build
   ```

3. Run the API:

   ```bash
   dotnet run
   ```

4. Open the Swagger UI to test the endpoints:

   Navigate to `https://localhost:7106/swagger` in your browser.

---

## **Endpoints**

| Endpoint                 | Description                             | Example Request                              |
|--------------------------|-----------------------------------------|---------------------------------------------|
| `GET /api/Photos/search` | Search for photos with optional params | `api/Photos/search?text=landscape&perPage=5` |

### **Supported Parameters**
| Parameter      | Description                      | Example Value            |
|----------------|----------------------------------|--------------------------|
| `text`        | Search for photos by text query  | `landscape`              |
| `tags`        | Search for specific tags         | `nature,travel`          |
| `minUploadDate` | Filter by minimum upload date   | `2024-01-01`             |
| `perPage`     | Number of photos per page        | `10`                     |
| `page`        | Page number                      | `1`                      |

---

## **Deployment Options**

### Docker Deployment

You can run this API in a Docker container:

1. Build the Docker image:

   ```bash
   docker build -t flickr-api:latest .
   ```

2. Run the container:

   ```bash
   docker run -d -p 7106:80 --name flickr-api flickr-api:latest
   ```

3. Access the API at `http://localhost:7106/swagger`.

---

## **Testing**

### **Unit Tests**

Unit tests are implemented using:
- **xUnit** for testing framework.
- **Moq** for mocking external dependencies.
- **FluentAssertions** for clean assertions.

To run tests:

```bash
cd tests/UnitTests
dotnet test
```

### **Test Coverage**

The following scenarios are covered:
1. Successful API response handling.
2. Malformed or invalid JSON response.
3. API errors like HTTP 500.

---

## **Contributors**

### Core Team

- [mcmdothub](https://github.com/mcmdothub) - **Design & Development**

---

## **Contributing**

We welcome contributions! To contribute:
1. Fork the repository.
2. Create a new branch.
3. Submit a pull request with a clear description of changes.

Feel free to create issues for bugs, enhancements, or feature suggestions.

---

## **Deployment Status**

| Environment | Status               | Quicklink                                                                                     |
|-------------|----------------------|----------------------------------------------------------------------------------------------|
| **Docker**  | ✅ Ready             | [![Docker Compose](https://img.shields.io/badge/-docker--compose.yml-2496ED?style=for-the-badge&logo=docker&logoColor=ffffff)](https://todo/docker-compose.yml)                                            |
| **Cloud**   | 🚧 In Progress       | Deployment to cloud environments is under development.                                       |

---

## **License**

This project is licensed under the **MIT License**.

---

## **Contact**

For any questions or feedback, feel free to contact us:
- **Email**: TODO
- **Website**: [mcmdothub](https://github.com/mcmdothub)

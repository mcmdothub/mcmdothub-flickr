
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

## Environment Variables

Create a `.env` file in the root directory with the following keys:
```
# Folder Structure:
# project-root/
# │
# ├── docker-compose.yml
# ├── Api/
# │   ├── src/
# │         ├── Flickr.Api/
# │                ├── .env
# │   ├── Dockerfile
# │   ├── Flickr.Api.sln
# │
# ├── Web/
# │   ├── src/
# │   		├── [Other HTML project files]
# │   ├── Dockerfile
# │   ├── package.json
```
```env
FLICKR_API_KEY=place_your_key_here
ALLOWED_ORIGINS=http://127.0.0.1:5500,http://localhost:5000,http://172.17.16.1:5000,https://your-production-url.com
```

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

## Running the Application with Docker

### Steps to Run:

1. **Ensure Docker Is Installed**:
   - Download and install Docker from [here](https://www.docker.com/products/docker-desktop).
   - Verify the installation by running the following command:
     ```bash
     docker --version
     ```

2. **Navigate to the Root Directory**:
   Make sure you're in the root directory where the `docker-compose.yml` file is located.

   ```bash
   cd project-root
   ```

3. **Build and Start the Containers**:
   Run the following command to build and start the containers:
   ```bash
   docker-compose up --build
   ```

4. **Access the Services**:
   - **API**: Open [http://localhost:8080/swagger/index.html](http://localhost:8080/swagger/index.html) to explore the API using Swagger.
   - **Frontend**: Open [http://localhost:8001](http://localhost:8001) to view the web application.

5. **Shut Down the Containers**:
   When you're done, shut down the containers using:
   ```bash
   docker-compose down
   ```

### Common Issues:

- **Port Already in Use**:
  If you encounter a port conflict, ensure no other application is using the ports defined in `docker-compose.yml`.

- **API Key Not Set**:
  If you get an error that the `FLICKR_API_KEY` is null, ensure your `.env` file is in the root directory and contains the correct key.

- **Debugging Logs**:
  View logs for containers using:
  ```bash
  docker logs <container_name>
  ```

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

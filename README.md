![Flickr Logo](https://combo.staticflickr.com/pw/images/flickr_logo_dots.svg)

# Flickr API and Web Application Documentation

Flickr is an image and video hosting platform that allows users to share and manage their photos. This project combines a **Flickr API** implementation and a frontend web application for interacting with Flickr's photo search functionality.

Read the official Flickr API docs here: [https://www.flickr.com/services/developer/api/](https://www.flickr.com/services/developer/api/).

---

## **Project Status**

**Current Version:** 1.0.0 (Production Ready)

---

## **Prerequisites**

To run and build the project, ensure you have the following tools installed:

- **Frontend Development**
  - Node.js v16+ [Download](https://nodejs.org/)
  - npm (Node Package Manager)
  - A modern browser (e.g., Chrome, Firefox)
- **Backend Development**
  - .NET 8 SDK [Download](https://dotnet.microsoft.com/download/dotnet/8.0)
  - Visual Studio Code or Visual Studio 2022
  - Docker (optional for container deployment)

---

## **Packages**

Below are the core packages used in this project:

| **Package**                                | **Purpose**                                                                                              |
|-------------------------------------------|----------------------------------------------------------------------------------------------------------|
| [@babel/core](https://github.com/babel/babel)              | JavaScript compiler for modern JS features                                                               |
| [AOS](https://michalsnik.github.io/aos/)                  | Animate On Scroll Library for UI animations                                                             |
| [copy-webpack-plugin](https://www.npmjs.com/package/copy-webpack-plugin)  | Copy files and directories with Webpack                                                                  |
| [css-loader](https://webpack.js.org/loaders/css-loader/)   | Interpret and resolve CSS imports and URLs                                                               |
| [file-loader](https://v4.webpack.js.org/loaders/file-loader/) | Manage static assets like images and emit URLs                                                           |
| [html-webpack-plugin](https://www.npmjs.com/package/html-webpack-plugin) | Simplify HTML file creation for Webpack                                                                  |
| [mini-css-extract-plugin](https://www.npmjs.com/package/mini-css-extract-plugin) | Extract CSS into separate files for production builds                                                   |
| [sass](https://github.com/sass/sass)                      | Compile SCSS/SASS files to standard CSS                                                                 |
| [style-loader](https://webpack.js.org/loaders/style-loader/) | Inject compiled CSS into the DOM                                                                        |
| [Webpack](https://webpack.js.org/)                        | JavaScript bundler for development and production builds                                                |
| [webpack-bundle-analyzer](https://www.npmjs.com/package/webpack-bundle-analyzer) | Visualize and analyze bundle size                                                                       |
| [rimraf](https://www.npmjs.com/package/rimraf)            | Cleanup installed node packages or folders                                                              |
| [.NET 8](https://dotnet.microsoft.com/download/dotnet/8.0)           | Backend technology to implement the Flickr API wrapper                                                  |
| [Docker](https://www.docker.com/)                         | Optional containerization for deploying the web and API project                                         |

---

## **Deployment Options**

| Platform | Documentation                      | Quicklink                                                                                                                                                       |
|----------|------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Docker   | [Docs](https://todo)               | [![Docker Compose](https://img.shields.io/badge/-docker--compose.yml-2496ED?style=for-the-badge&logo=docker&logoColor=ffffff)](https://todo/docker-compose.yml) |

---

## **How to Build and Run the Project**

### **1. Build and Run the Backend API**

1. Navigate to the API project root directory:

   ```bash
   cd Flickr.Api
   ```

2. Run the application using .NET CLI:

   ```bash
   dotnet build
   dotnet run
   ```

   The API will start on `https://localhost:7106`.

3. Test the API endpoints, for example:

   ```bash
   GET https://localhost:7106/api/Photos/search?text=landscape&page=1&perPage=10
   ```

### **2. Build and Run the Frontend Web Application**

1. Navigate to the `Flickr.Web` project folder:

   ```bash
   cd Flickr.Web
   ```

2. Install dependencies:

   ```bash
   npm install
   ```

3. Run the development server (Port `3000`):

   ```bash
   npm run dev
   ```

   The app will be available at `http://localhost:3000`.

4. Build for production:

   ```bash
   npm run build
   ```

---

## **Deploy Using Docker**

1. Build the Docker image:

   ```bash
   docker build -t flickr-web:latest ./Flickr.Web
   ```

2. Run the container:

   ```bash
   docker run -p 5000:80 flickr-web:latest
   ```

3. Access the web application:

   ```bash
   http://localhost:5000
   ```

---

## **Folder Structure**

```plaintext
├── Flickr.Api                # Backend API for interacting with Flickr
│   ├── Controllers           # API Controllers
│   ├── Services              # Flickr API Service
│   ├── Models                # Strongly-typed models
│   └── UnitTests             # Unit tests for the API
├── Flickr.Web                # Frontend Web Application
│   ├── src                   # Source files (JS, SCSS, assets)
│   ├── dist                  # Compiled output (Production)
│   ├── webpack.config.js     # Webpack configuration
│   └── package.json          # Project dependencies
├── README.md                 # Documentation file
└── docker-compose.yml        # Docker configuration
```

---

## **Contributors**

### **Core Team**
- [Cygni](https://cygni.se/) - Designer and Developer

---

## **Contributing**

We welcome contributions to improve this project! To contribute:

1. Fork the repository.
2. Create a new feature branch:

   ```bash
   git checkout -b feature/your-feature-name
   ```

3. Make your changes and commit them:

   ```bash
   git commit -m "Add your feature description"
   ```

4. Push your changes and create a Pull Request:

   ```bash
   git push origin feature/your-feature-name
   ```

---

## **Cloud Version**

The cloud-hosted version is currently **in progress**. Stay tuned for updates!

---

## **License**

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).

# File: 'docker-compose.yml'
#
# Folder Structure:
# project-root/
# │
# ├── Web/
# │   ├── src/
# │   		├── [Other HTML project files]
# │   ├── Dockerfile
# │   ├── package.json
#
# Use the official Node.js image as the base image

FROM node:18 AS build

# Set working directory inside the container
WORKDIR /app

# Copy package.json and package-lock.json
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of the application files
COPY . .

# Build the project
RUN npm run build

# Use a lightweight web server to serve the built files
FROM nginx:alpine AS production

# Set working directory inside the container
WORKDIR /usr/share/nginx/html

# Copy built files from the build stage
COPY --from=build /app/dist .

# Copy custom nginx configuration (if needed)
# COPY nginx.conf /etc/nginx/nginx.conf

# Expose the port the application will run on
EXPOSE 80

# Start the nginx server
CMD ["nginx", "-g", "daemon off;"]

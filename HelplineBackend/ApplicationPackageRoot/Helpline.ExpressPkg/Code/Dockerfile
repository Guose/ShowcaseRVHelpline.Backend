# Use the official Node.js image from the Docker Hub
# This is the base image that includes Node.js 20.17.0
FROM node:20.17.0-alpine

# Set the working directory inside the container
WORKDIR /usr/src/app

# Copy package.json and package-lock.json to the container
COPY package*.json ./

# Install the application's dependencies
RUN npm install

# Copy the rest of your application code to the container
COPY . .

# Expose the port your application will run on
EXPOSE 3001

# Set the environment variable for development
ENV NODE_ENV=development

# Define the command to run your application in development mode
CMD ["npm", "run", "dev"]
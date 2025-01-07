![Flickr Logo](https://combo.staticflickr.com/pw/images/flickr_logo_dots.svg)

# What is Flickr?

Flickr is an image and video hosting web site, web services suite, and online community platform. In addition to being a popular site for users to share personal photographs and video clips, the service is widely used as a photo repository.

Read the docs at [https://www.flickr.com/services/developer/api/](https://www.flickr.com/services/developer/api/) (work in progress) or just check out the code and play around.

## Status

Current Version 0.0.1

## Prerequisites

* [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

## Packages
* [@babel/core](https://github.com/babel/babel) - Babel is a compiler for writing next generation JavaScript
* [@babel/preset-env](https://babeljs.io/docs/babel-preset-env) - is a smart preset that allows you to use the latest JavaScript
* [AOS](https://michalsnik.github.io/aos/) - Animate On Scroll Library
* [babel-loader](https://github.com/babel/babel-loader) - Babel loader for webpack
* [copy-webpack-plugin](https://michalsnik.github.io/aos/) - Copy files and directories with webpack
* [css-loader](https://webpack.js.org/loaders/css-loader/) - The css-loader interprets @import and url() like import/require() and will resolve them
* [file-loader](https://v4.webpack.js.org/loaders/file-loader/) - The file-loader resolves import/require() on a file into a url and emits the file into the output directory.
* [html-webpack-plugin](https://michalsnik.github.io/aos/) - simplifies creation of HTML files to serve your webpack bundles
* [mini-css-extract-plugin](https://michalsnik.github.io/aos/) - This plugin extracts CSS into separate files. It creates a CSS file per JS file which contains CSS.
* [npm-check-updates](https://www.npmjs.com/package/npm-check-updates) - Check updates
* [rimraf](https://www.npmjs.com/package/rimraf) - Used to clean the installed node packages
* [sass](https://github.com/sass/sass) - Sass is an extension of CSS, adding nested rules, variables, mixins, selector inheritance, and more
* [sass-loader](https://www.npmjs.com/package/sass-loader) - Loads a Sass/SCSS file and compiles it to CSS.
* [style-loader](https://webpack.js.org/loaders/style-loader/) - Inject CSS into the DOM
* [Webpack](https://webpack.js.org/) - Bundle your script
* [webpack-bundle-analyzer](https://www.npmjs.com/package/webpack-bundle-analyzer) - Visualize size of webpack output files with an interactive zoomable treemap
* [webpack-cli](https://github.com/webpack/webpack-cli) - Provides the interface of options webpack uses in its configuration file
* [webpack-dev-server](https://webpack.js.org/configuration/dev-server/) - Used to quickly develop an application


## Deployment Options

| Platform | Documentation                      | Quicklink                                                                                                                                                       | 
| -------- |------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Docker   | [Docs](https://todo)               | [![Docker Compose](https://img.shields.io/badge/-docker--compose.yml-2496ED?style=for-the-badge&logo=docker&logoColor=ffffff)](https://todo/docker-compose.yml) |


## Build and run the Docker container:

  - Build the Docker image:
    ```bash
    docker build -t flickr-web:latest ./Flickr.Web
    ```
      

  - Run the container:
    ```bash
    docker run -p 5000:80 flickr-web:latest
    ```

  - Access the web application:
    ```bash
    http://localhost:5000
    ```

## Build for development
Run Dev Server (Port 3000)
```bash
npm run dev
```

## Build for production
```bash
npm run build
```

## Contributors

### Core Team and Founders

* [mcmdothub](https://github.com/mcmdothub) Designer

## Contributing

Please create issues to report bugs, suggest new functionalities, ask questions or just share your thoughts about the project. We will really appreciate your contribution, thanks.

## Cloud Version

In Progress

const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const CopyWebpackPlugin = require('copy-webpack-plugin');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');

module.exports = {
  mode: 'development', // Set the mode to development
  entry: {
    bundle: path.resolve(__dirname, 'src/index.js'), // Entry point for your app
  },
  output: {
    path: path.resolve(__dirname, 'dist'), // Output directory
    filename: '[name].js', // Output filename
    publicPath: '', // Base path for all assets
    clean: true, // Clean the dist folder before each build
  },
  devtool: 'source-map', // Generate source maps for debugging
  devServer: {
    static: {
      directory: path.resolve(__dirname, 'dist'), // Serve static files from dist
    },
    port: 5000, // Dev server port
    open: true, // Automatically open the browser
    hot: true, // Enable hot module replacement
    compress: true, // Enable Gzip compression
    historyApiFallback: {
      index: 'index.html', // Fallback to index.html for SPA routing
      disableDotRule: true, // Prevent resolving assets like bundle.js to index.html
    },
  },
  module: {
    rules: [
      {
        test: /\.scss$/, // Match SCSS files
        use: [
          MiniCssExtractPlugin.loader, // Extract CSS into separate files
          {
            loader: 'css-loader',
            options: {
              url: true, // Enable handling of URLs
              sourceMap: true, // Enable source maps
            },
          },
          'sass-loader', // Process SCSS files
        ],
      },
      {
        test: /\.(png|svg|jpg|jpeg|gif)$/i, // Match image files
        type: 'asset/resource', // Use Webpack's built-in asset/resource for images
        generator: {
          filename: 'assets/img/[name][ext]', // Copy images to assets/img in dist
        },
      },
      {
        test: /\.js$/, // Match JavaScript files
        exclude: /node_modules/, // Exclude node_modules
        use: {
          loader: 'babel-loader', // Use Babel to transpile JavaScript
          options: {
            presets: ['@babel/preset-env'], // Use preset-env for modern JavaScript
          },
        },
      },
    ],
  },
  plugins: [
    new CopyWebpackPlugin({
      patterns: [
        {
          from: path.resolve(__dirname, 'src/assets/img'), // Source assets folder
          to: path.resolve(__dirname, 'dist/assets/img'), // Output to dist/assets
        },
      ],
    }),
    new MiniCssExtractPlugin({
      filename: '[name].css', // Output CSS files to dist/styles
    }),
    new HtmlWebpackPlugin({
      title: 'Flickr Web App', // Title of the app
      filename: 'index.html', // Output HTML file name
      template: path.resolve(__dirname, 'src/index.html'), // Template file
      inject: 'body', // Inject scripts into the body
    }),
  ],
};

const path = require("path");
const FileManagerPlugin = require("filemanager-webpack-plugin");

module.exports = {
  entry: {
    web: "./src/web/index.ts"
  },
  module: {
    rules: [
      {
        test: /\.tsx?$/,
        use: "ts-loader",
        exclude: /node_modules/
      },
      {
        test: /\.html$/i,
        loader: "html-loader"
      }
    ]
  },
  plugins: [
    new FileManagerPlugin({
      onEnd: {
        copy: [
          {
            source: "./src/web/index.html",
            destination: path.resolve(__dirname, "public")
          }
        ]
      }
    })
  ],
  resolve: {
    extensions: [".tsx", ".ts", ".js", ".html"]
  },
  output: {
    filename: "[name].js",
    path: path.resolve(__dirname, "public")
  },
  target: "node"
};

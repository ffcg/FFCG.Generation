const path = require('path');

module.exports = {
  entry: {
    apiConsumer: './src/ConsumerApi/index.ts',
    webApi: './src/WebApi/index.ts',
    web: './src/Web/index.ts'
  },
  module: {
    rules: [
      {
        test: /\.tsx?$/,
        use: 'ts-loader',
        exclude: /node_modules/
      }
    ]
  },
  resolve: {
    extensions: [ '.tsx', '.ts', '.js' ]
  },
  output: {
    filename: '[name].js',
    path: path.resolve(__dirname, 'dist')
  },
  target: 'node'
};

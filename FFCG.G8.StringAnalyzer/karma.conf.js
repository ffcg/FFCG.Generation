module.exports = function(config) {
  config.set({
    basePath: "",
    frameworks: ["jasmine", "karma-typescript"],
    files: ["src/**/*.ts*"],
    preprocessors: {
      "**/*.ts": "karma-typescript"
    },
    karmaTypescriptConfig: {
      compilerOptions: {
        module: "CommonJS"
      },
      exclude: ["node_modules"]
    },
    exclude: [],
    reporters: ["progress"],
    port: 9876,
    colors: true,
    logLevel: config.LOG_INFO,
    autoWatch: true,
    browsers: ["ChromeHeadless"],
    singleRun: false,
    concurrency: Infinity
  });
};

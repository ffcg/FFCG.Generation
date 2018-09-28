/* Rename this to wallaby.js in order to use this as configuration for WallabyJS. We are calling it .template in 
order to get around wallaby.js being ignored in the .gitignore file. */

module.exports = function (wallaby) {
    return {
      files: [
        'src/**/*.ts*',
        '!src/**/*spec.ts',
        '!src/**/*test*.ts'
      ],
  
      tests: ['src/**/*spec.ts*', 'src/**/*test*.ts'],
  
      compilers: {
        '**/*.ts?(x)': wallaby.compilers.typeScript()
      },
      testFramework: 'jasmine',
      env: {
        type: "node",
      }
    };
};

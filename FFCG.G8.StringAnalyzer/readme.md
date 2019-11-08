**UPPGIFT**

Gör klart uppgiften Advent of Code 2015 Day 5: https://adventofcode.com/2015/day/5

**TESTER**

Om ni vill köra wallaby.js behöver ni skapa en fil i roten som heter wallaby.js med följande innehåll:

```
module.exports = function(wallaby) {
return {
files: ["src/**/*.ts*", "!src/**/*spec.ts", "!src/**/*test*.ts"],

    tests: ["src/**/*spec.ts*", "src/**/*test*.ts"],

    compilers: {
      "**/*.ts?(x)": wallaby.compilers.typeScript()
    },
    testFramework: "jasmine",
    env: {
      type: "node"
    }
};
};
```

Här är instruktionerna för att installera wallaby.js i Visual Studio Code:

https://wallabyjs.com/docs/intro/install.html#visual-studio-code

Om ni vill köra Karma kan behöver ni skapa en fil i roten som heter karma.conf.js med följande innehåll:

```
module.exports = function(config) {
config.set({
basePath: '',
frameworks: ['jasmine', 'karma-typescript'],
files: [
'src/**/*.ts*'
],
preprocessors: {
"\*_/_.ts": "karma-typescript"
},
karmaTypescriptConfig: {
compilerOptions: {
module: "CommonJS"
},
exclude: ["node_modules"]
},
exclude: [],
reporters: ['progress'],
port: 9876,
colors: true,
logLevel: config.LOG_INFO,
autoWatch: true,
browsers: ['ChromeHeadless'],
singleRun: false,
concurrency: Infinity
})
}
```

Denna konfiguratonsfil är redan incheckad. Ni behöver även klistra in följande beroenden i devDependencies i package.json:

    "karma": "^4.3.0",
    "karma-chrome-launcher": "^3.1.0",
    "karma-jasmine": "^2.0.1",
    "karma-typescript": "^4.1.1",

Följ instruktionerna här för att komma igång med Karma: http://karma-runner.github.io/4.0/intro/installation.html

**ÖVRIGT**

I FileUtilities.ts finns en metod ni kan använda för att få ut en lista på alla ord i uppgiften. Observera att den incheckade listan är den som jag fått tilldelad, men varje individ får en unik lista. Därför behöver ni klistra in era egna listor om ni vill mata in era svar på Advent of Code.

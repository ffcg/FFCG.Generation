var gulp = require('gulp')
var minify = require('gulp-minify')
var del = require('del')
var concat = require('gulp-concat')
var replace = require('gulp-token-replace')
var rename = require('gulp-rename')

gulp.task('clean', function() {
    return del(['dist/**/*', '!dist'])
})

gulp.task('scripts', function() {
    return gulp
            .src([
                'src/rules/textBaseRule.js',
                'src/rules/textCapitalizeRule.js',
                'src/rules/textConcatenationRule.js',
                'src/rules/textReplaceRule.js',
                'src/rules/textReverseRule.js',
                'src/textManipulator.js',
                'src/app.js'
            ])
            .pipe(concat('clientbundle.js'))
            .pipe(minify({
                ext: {
                    min: '.min.js'
                }
            }))
            .pipe(gulp.dest('dist'))
})

gulp.task('html', function() {
    return gulp
            .src(['src/index.base.html'])
            .pipe(replace({
                tokens: {
                   environmentName: '- DEV',
                   title: 'Super useful JS word replacer',
                   clientBundlePath: './clientbundle.min.js'
                }
            }))
            .pipe(rename('index.html'))
            .pipe(gulp.dest('dist'))
})

gulp.task('default', ['clean', 'scripts', 'html'])

gulp.task('watch', function() {
    gulp.watch(['src/**/*.js', 'src/index.base.html'], ['default'])
});

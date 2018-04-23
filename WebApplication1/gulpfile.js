/// <binding BeforeBuild='default' />
var gulp = require('gulp'),
    fs = require('fs'),
    less = require('gulp-less');
var concat = require('gulp-concat');
var ngAnnotate = require('gulp-ng-annotate');
var plumber = require('gulp-plumber');
var bytediff = require('gulp-bytediff');
var uglify = require('gulp-uglify');
var rename = require("gulp-rename");
const babel = require('gulp-babel');

    gulp.task('public', function () {
        return gulp.src(['App/Public/app.module.js',
            'App/Public/app.run.js',
            'App/Public/**.js',
            'App/Public/**/*.js'])
            .pipe(plumber())
            .pipe(babel({
                presets: ['env']
            }))
            .pipe(concat('public-app.js', { newLine: ';' }))
            .pipe(ngAnnotate({ add: true }))
            .pipe(plumber.stop())
            .pipe(gulp.dest('wwwroot/js/angular'));
    });
    gulp.task('admin', function () {
        return gulp.src(['App/Admin/admin-app.module.js',
            'App/Admin/**.js',
            'App/Admin/**/*.js'])
            .pipe(plumber())
            .pipe(babel({
                presets: ['env']
            }))
            .pipe(concat('admin-app.js', { newLine: ';' }))
            .pipe(ngAnnotate({ add: true }))
            .pipe(plumber.stop())
            .pipe(gulp.dest('wwwroot/js/angular'));
    });
    gulp.task('default',  ['public', 'admin', 'style']);

    gulp.task('style', function (){
        return gulp.src('Styles/style.less')
            .pipe(less())
            .pipe(gulp.dest('wwwroot/css'));
    });
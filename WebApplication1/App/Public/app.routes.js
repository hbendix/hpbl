angular.module("app").config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $locationProvider.hashPrefix('');
    $routeProvider
        .when('/', {
            templateUrl: '/home/feed',
            controller: 'feedController'
        })
        .when('/Portfolio', {
            templateUrl: '/home/portfolio',
            controller: 'portfolioController'
        })
        .when('/Pictures', {
            templateUrl: '/home/feed',
            controller: 'feedController'
        })
        .when('/About', {
            templateUrl: '/home/about',
            controller: 'aboutController'
        })
        .otherwise({ 
            redirectTo: '/feed' 
        });
}]); 
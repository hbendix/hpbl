angular.module("admin-app").config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $locationProvider.hashPrefix('');
    $routeProvider
        .when('/', {
            templateUrl: '/admin/imagecontrol',
            controller: 'imageCtrlController'
        })
        .when('/Images', {
            templateUrl: '/admin/imagecontrol',
            controller: 'imageCtrlController'
        })
        .when('/Admin', {
            templateUrl: '/admin/admincontrol',
            controller: 'adminCtrlController'
        });
}]); 
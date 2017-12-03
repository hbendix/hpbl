angular.module("app").config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $locationProvider.hashPrefix('');
    $routeProvider
        .when('/', {
            templateUrl: '/home/feed',
            controller: 'feedController'
        })
        .when('/blog', {
            templateUrl: '/home/blog',
            controller: 'blogController'
        })
        .when('/feed', {
            templateUrl: '/home/feed',
            controller: 'feedController'
        })
        .when('/about', {
            templateUrl: '/home/about',
            controller: 'aboutController'
        })
        .otherwise({ redirectTo: '/feed' })
}]); 


angular.module("app").controller('feedController', function feedController($scope, $http) {   
    $scope.images = {};
    $scope.getFeed = function () {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        $http.get('/home/GetFeed', config)
            .then(
            function (response) {
                $scope.images = response.data;
            });
    }
    $scope.open = function (Id) {
        $('#' + Id).toggleClass('openImageCard');                
        $('#text_' + Id).slideToggle();
        $('#info_' + Id).slideToggle();
    }
    $scope.loadMore = function () {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        $http.get('/home/GetFeed', config)
            .then(
            function (response) {
                $scope.images = $scope.images.concat(response.data);
            });
    }
    function init() {   
        $scope.getFeed();
    }
    init();
});

angular.module("app").controller('blogController', function blogController($scope, $http) {
    $scope.blogPosts = {};
    $scope.getFeed = function () {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        $http.get('/home/GetBlogFeed', config)
            .then(
            function (response) {
                $scope.blogPosts = response.data;
            });
    }
    function init() {
        $scope.getFeed();
    }
    init();
});

angular.module("app").controller('aboutController', function aboutController($scope, $http) {
    function init() {
    }
    init();
});
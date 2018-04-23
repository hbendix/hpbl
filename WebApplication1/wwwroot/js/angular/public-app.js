'use strict';

angular.module("app", ['ngRoute', 'infinite-scroll', 'ngAnimate']);;"use strict";

angular.module('app').run(["$rootScope", "$anchorScroll", function ($rootScope, $anchorScroll) {
    $rootScope.$on("$locationChangeSuccess", function () {
        $anchorScroll();
    });
}]);;"use strict";

angular.module("app").controller('appController', ["$scope", "$location", "$http", function feedController($scope, $location, $http) {
    $scope.selectedTab = "pictures";

    $location.path();

    switch ($location.path()) {
        case "/Pictures":
            $scope.selectedTab = "pictures";
            break;
        case "/Portfolio":
            $scope.selectedTab = "portfolio";
            break;
        case "/About":
            $scope.selectedTab = "about";
            break;
    }

    $scope.assignActiveTab = function (event) {
        switch (event) {
            case "pictures":
                $scope.selectedTab = "pictures";
                break;
            case "portfolio":
                $scope.selectedTab = "portfolio";
                break;
            case "about":
                $scope.selectedTab = "about";
                break;
        }
        console.log($scope.selectedTab);
    };

    function init() {
        if (!localStorage.noFirstVisit) {
            // show the element
            // and do the animation you want
            $('#firstTimeVisitModal').modal('show');

            // check this flag for escaping this if block next time
            localStorage.noFirstVisit = true;
        }
    }
    init();
}]);;'use strict';

angular.module("app").config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $locationProvider.hashPrefix('');
    $routeProvider.when('/', {
        templateUrl: '/home/feed',
        controller: 'feedController'
    }).when('/Portfolio', {
        templateUrl: '/home/portfolio',
        controller: 'portfolioController'
    }).when('/Pictures', {
        templateUrl: '/home/feed',
        controller: 'feedController'
    }).when('/About', {
        templateUrl: '/home/about',
        controller: 'aboutController'
    }).otherwise({
        redirectTo: '/feed'
    });
}]);;'use strict';

angular.module("app").controller('feedController', ["$scope", "$http", "feedService", function feedController($scope, $http, feedService) {
    $scope.images = {};

    $scope.getFeed = function () {
        var feed = feedService.getFeed();
        feed.then(function (result) {
            $scope.images = result;
        });
    };

    $scope.open = function (Id) {
        $('#' + Id).toggleClass('openImageCard');
        $('#text_' + Id).slideToggle();
        $('#info_' + Id).slideToggle();
    };

    $scope.loadMore = function () {
        var feed = feedService.getFeed();
        feed.then(function (result) {
            $scope.images = $scope.images.concat(result);
        });
    };

    function init() {
        $scope.getFeed();
    }

    init();
}]);;'use strict';

(function () {
    angular.module("app").factory('feedService', ["$http", function feedService($http) {
        var _toReturn = {};

        _toReturn.getFeed = function () {
            return $http({
                url: '/api/Feed/GetFeed',
                method: "GET"
            }).then(function (response) {
                return response.data;
            });
        };

        return _toReturn;
    }]);
})();;"use strict";

angular.module("app").controller('portfolioController', ["$scope", "$http", function portfolioController($scope, $http) {
    $scope.hello = "Portfolio";
    window.onbeforeunload = function () {
        window.scrollTo(0, 0);
    };
}]);
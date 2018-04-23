angular.module("app").controller('portfolioController', function portfolioController($scope, $http) {
    $scope.hello = "Portfolio";
    window.onbeforeunload = function() {
        window.scrollTo(0,0);
    };
});

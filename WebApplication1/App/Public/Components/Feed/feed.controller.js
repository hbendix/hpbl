angular.module("app").controller('feedController', function feedController($scope, $http, feedService) {   
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
    
});

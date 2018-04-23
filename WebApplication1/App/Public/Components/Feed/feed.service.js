(function(){ 
 angular.module("app").factory('feedService', function feedService($http) {   
        var _toReturn = {};

        _toReturn.getFeed = function () {
            return $http({ 
                url:'/api/Feed/GetFeed',
                method: "GET" 
            })
            .then(
            function (response) {
                return response.data;
            });
        };

        return _toReturn;
    })
})();

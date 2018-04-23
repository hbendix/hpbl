angular.module('app').run(function($rootScope, $anchorScroll) {
    $rootScope.$on("$locationChangeSuccess", function(){
        $anchorScroll();
    });
});
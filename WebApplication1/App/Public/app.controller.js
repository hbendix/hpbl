angular.module("app").controller('appController', function feedController($scope, $location, $http) {   
    $scope.selectedTab = "pictures";

    $location.path();

    switch($location.path()) {
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
});
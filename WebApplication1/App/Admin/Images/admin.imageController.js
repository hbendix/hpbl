angular.module("admin-app").controller('imageCtrlController', function ImageCtrlController($scope, $http) {
    $scope.images = {};
    $scope.showGet = true;
    $scope.showAdd = false;
    $scope.editImage = {};
    $scope.imageNo = 1;
    $scope.image = {};

    $scope.getImages = function () {
        $scope.showGet = true;
        $scope.showAdd = false;
        init();
    };

    $scope.addImages = function () {
        $scope.showGet = false;
        $scope.showAdd = true;
    };

    $scope.getNumber = function (num) {
        return new Array(num);
    };

    $scope.add = function (image) {
        image.taken = new Date();
        image.taken = $('#taken').val();
        var i = $.param(image);
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        };
        $http.post('/api/Admin/AddImage', i, config)
            .then(
            function (response) {
                $scope.image = {};
                console.log(response);
                $scope.getImages();
            });
    };

    $scope.edit = function (image) {
        $scope.editImage = image;
        console.log($scope.editImage);
        $('#editModal').modal('show');
    };

    $scope.save = function (image) {
        image.taken = new Date();
        image.taken = $('#editTaken').val();
        var i = $.param(image);
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        $http.put('/api/Admin/UpdateImage', i, config)
            .then(
            function (response) {
                $('#editModal').modal('hide');

            });
    };

    $scope.delete = function (image) {
        var i = $.param(image);
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        $http.post('/api/Admin/DeleteImage', i, config)
            .then(
            function (response) {
                console.log(response);
                init();
            });
    };

    function init() {
        $http.get('/api/Admin/GetImages')
            .then(
            function (response) {
                $scope.images = response.data;
            });
    }
    
    init();
});
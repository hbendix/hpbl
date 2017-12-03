angular.module("app").config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $locationProvider.hashPrefix('');
    $routeProvider
        .when('/', {
            
        })
        .when('/imageCtrl', {
            templateUrl: '/admin/imagecontrol',
            controller: 'imageCtrlController'
        })
        .when('/adminCtrl', {
            templateUrl: '/admin/admincontrol',
            controller: 'adminCtrlController'
        })
        .when('/blogCtrl', {
            templateUrl: '/admin/blogcontrol',
            controller: 'blogCtrlController'
        })
}]); 

angular.module("app").controller('adminCtrlController', function AdminCreateController($scope, $http) {
    $scope.admin = {};
    $scope.admins = {};
    $scope.add = false;
    $scope.manage = true;
    $scope.manageAdmin = function () {
        $scope.manage = true;
        $scope.add = false;
        $scope.getAllAdmins();
    }
    $scope.addAdmin = function () {
        $scope.manage = false;
        $scope.add = true;
    }
    $scope.createNewAdmin = function () {
        var admin = $.param($scope.admin);
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        $http.post('/admin/CreateAdmin', admin, config)
            .then(
            function (response) {
                console.log(response);
                if (response.data === "e") {
                    alert("Please fill in both fields yo!")
                }
                $scope.manageAdmin();
            });
    }
    $scope.deleteAdmin = function (admin) {
        var a = $.param(admin);
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        $http.post('/admin/DeleteAdmin', a, config)
            .then(
            function (response) {
                console.log(response);
                init();
            });
    }
    $scope.getAllAdmins = function () {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        $http.get('/admin/GetAllAdmins', config)
            .then(
            function (response) {
                $scope.admins = response.data;
                console.log(response);
            });
    }
    function init() {
        $scope.getAllAdmins();
    }
    init();
});
angular.module("app").controller('imageCtrlController', function ImageCtrlController($scope, $http) {
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
    }
    $scope.addImages = function () {
        $scope.showGet = false;
        $scope.showAdd = true;
    }
    $scope.getNumber = function (num) {
        return new Array(num);
    }
    $scope.add = function (image) {
        image.taken = new Date;
        image.taken = $('#taken').val();
        var i = $.param(image);
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        $http.post('/admin/AddImage', i, config)
            .then(
            function (response) {
                $scope.image = {};
                console.log(response);
                $scope.getImages();
            });
    }
    $scope.edit = function (image) {
        $scope.editImage = image;
        console.log($scope.editImage);
        $('#editModal').modal('show');
    }
    $scope.save = function (image) {
        image.taken = new Date;
        image.taken = $('#editTaken').val();
        var i = $.param(image);
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        $http.post('/admin/UpdateImage', i, config)
            .then(
            function (response) {
                $('#editModal').modal('hide');

            });
    }
    $scope.delete = function (image) {
        var i = $.param(image);
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        $http.post('/admin/DeleteImage', i, config)
            .then(
            function (response) {
                console.log(response);
                init();
            });
    }
    function init() {
        $http.get('/admin/GetAllImages')
            .then(
            function (response) {
                $scope.images = response.data;
            });
    }
    init();
});
angular.module("app").controller('blogCtrlController', function ImageCtrlController($scope, $http) {
    $scope.blogs = {};
    $scope.blog = {};
    $scope.manage = true;
    $scope.add = false;
    $scope.getBlogs = function () {
        $scope.manage = true;
        $scope.add = false;
        init();
    }
    $scope.addBlogs = function () {
        $scope.manage = false;
        $scope.add = true;
    }
    $scope.getNumber = function (num) {
        return new Array(num);
    }
    $scope.addBlog = function (blog) {
        blog.created = $('#created').val();
        var b = $.param(blog);
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        $http.post('/admin/CreateBlog', b, config)
            .then(
            function (response) {
                console.log(response);
                $scope.getImages();
            });
    }
    function init() {
        $http.get('/admin/GetAllBlogPosts')
            .then(
            function (response) {
                $scope.blogs = response.data;
                console.log($scope.blogs);
            });
    }
    init();
});
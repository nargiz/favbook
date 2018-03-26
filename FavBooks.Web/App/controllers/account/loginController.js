(function () {
    'use strict';
    FavBooksApp.controller('LoginController', LoginController);

    function LoginController($scope, $location, authService, ngAuthSettings) {

        $scope.viewModel = {
            userName: "",
            password: ""
        };

        $scope.message = "";

        $scope.login = _login;

        function _login() {

            authService.login($scope.viewModel).then(function (response) {

                $location.path('/home');

            },
                function (err) {
                    $scope.message = err.error_description;
                });
        };

    }

    LoginController.$inject = ['$scope', '$location', 'authService', 'ngAuthSettings'];
})();

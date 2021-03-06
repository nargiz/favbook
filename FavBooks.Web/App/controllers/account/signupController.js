﻿(function () {
    'use strict';
    FavBooksApp.controller('SignupController', SignupController);

    function SignupController($scope, $location, $timeout, authService) {
        $scope.savedSuccessfully = false;
        $scope.message = "";
        $scope.viewModel = {
            userName: "",
            password: "",
            confirmPassword: ""
        };
        $scope.signUp = _signUp;


        function _signUp() {
            authService.register($scope.viewModel).then(
                function (response) {

                    $scope.savedSuccessfully = true;
                    $scope.message = "User has been registered successfully, you will be redicted to login page in 2 seconds.";
                    startTimer();
                },
                function (response) {
                    var errors = [];
                    for (var key in response.data.modelState) {
                        for (var i = 0; i < response.data.modelState[key].length; i++) {
                            errors.push(response.data.modelState[key][i]);
                        }
                    }
                    $scope.message = "Failed to register user due to:" + errors.join(' ');
                });
        };

        var startTimer = function () {
            var timer = $timeout(function () {
                $timeout.cancel(timer);
                $location.path('/login');
            }, 2000);
        }
    }

    SignupController.$inject = ['$scope', '$location', '$timeout', 'authService'];
})();

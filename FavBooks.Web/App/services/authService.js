﻿(function () {
    'use strict';
    FavBooksApp.factory('authService', AuthService);

    function AuthService($http, $q, localStorageService, ngAuthSettings) {

        var _authentication = {
            isAuth: false,
            userName: ""
        };

        var _register = function (registration) {

            _logOut();

            return $http.post(ngAuthSettings.apiServiceBaseUri + 'api/account/register', registration).then(function (response) {
                return response;
            });

        };

        var _login = function (loginData) {

            var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password + "&client_id=" + ngAuthSettings.clientId;


            var deferred = $q.defer();

            $http.post(ngAuthSettings.apiServiceBaseUri + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {

                localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName });

                _authentication.isAuth = true;
                _authentication.userName = loginData.userName;

                deferred.resolve(response);

            }).error(function (err, status) {
                _logOut();
                deferred.reject(err);
            });

            return deferred.promise;

        };

        var _logOut = function () {

            localStorageService.remove('authorizationData');

            _authentication.isAuth = false;
            _authentication.userName = "";

        };

        var _fillAuthData = function () {

            var authData = localStorageService.get('authorizationData');
            if (authData) {
                _authentication.isAuth = true;
                _authentication.userName = authData.userName;
            }

        };

        return {
            register: _register,
            login: _login,
            logOut: _logOut,
            fillAuthData: _fillAuthData,
            authentication: _authentication
        };
    }

    AuthService.$inject = ['$http', '$q', 'localStorageService', 'ngAuthSettings'];

}());
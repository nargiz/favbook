(function () {
    'use strict';
    FavBooksApp.factory('authInterceptorService', AuthInterceptorService);

    function AuthInterceptorService($q, $injector, $location, localStorageService) {

        var _request = function (config) {

            config.headers = config.headers || {};

            var authData = localStorageService.get('authorizationData');
            if (authData) {
                config.headers.Authorization = 'Bearer ' + authData.token;
            }

            return config;
        }

        var _responseError = function (rejection) {
            if (rejection.status === 401) {
                var authService = $injector.get('authService');
                localStorageService.remove('authorizationData');
                authService.logOut();
                $location.path('/login');
            }
            return $q.reject(rejection);
        }

        return {
            request: _request,
            responseError: _responseError
        };
    }

    AuthInterceptorService.$inject = ['$q', '$injector', '$location', 'localStorageService'];

}());

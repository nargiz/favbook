var FavBooksApp = angular.module('FavBooksApp', ['ngRoute', 'ngAnimate', 'ui.bootstrap', 'LocalStorageModule', 'angular-loading-bar',
    'angularUtils.directives.dirPagination', 'ngToast', 'angular-confirm']);

FavBooksApp.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "HomeController",
        templateUrl: "/app/views/home/index.html"
    });

    $routeProvider.when("/login", {
        controller: "LoginController",
        templateUrl: "/app/views/account/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "SignupController",
        templateUrl: "/app/views/account/signup.html"
    });

    $routeProvider.when("/search", {
        controller: "SearchController",
        templateUrl: "/app/views/favourites/search.html"
    });

    $routeProvider.when("/favourites", {
        controller: "FavouritesController",
        templateUrl: "/app/views/favourites/index.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });

});

var serverBaseURL = {};
if (window.location.href.indexOf("localhost") > 0) {
    serverBaseURL = "http://localhost:26264/"
} else {
    serverBaseURL = "http://" + location.host + "/"
}

FavBooksApp.constant('ngAuthSettings', {
    apiServiceBaseUri: serverBaseURL,
    clientId: 'FavBooksWebApp'
});

FavBooksApp.config(['$httpProvider', '$locationProvider',  function ($httpProvider, $locationProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
    $locationProvider.html5Mode(true);

}]);

FavBooksApp.run(['authService',
    function (authService) {
        authService.fillAuthData();
    }
]);

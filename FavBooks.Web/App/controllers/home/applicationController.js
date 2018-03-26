(function () {
    'use strict';
    FavBooksApp.controller('ApplicationController', ApplicationController);

    function ApplicationController($scope, $location, authService) {
        $scope.defaultMetadata = {
            title: 'FavBooks',
        };
        $scope.metadata = {
            title: $scope.defaultMetadata.title,
        };
        $scope.authentication = authService.authentication;
        $scope.logOut = _logOut;
        
        $scope.$on('subContentLoaded', function (event, metadata) {
            $scope.metadata.title = metadata.title || $scope.defaultMetadata.title;
            $scope.isPageReady = true;
            $scope.currentURL = location.href;
        });

       
       // authService.startServices();

        function _logOut() {
            authService.logOut();
            $location.path('/home');
        }
    }

    ApplicationController.$inject = ['$scope', '$location', 'authService'];

})();

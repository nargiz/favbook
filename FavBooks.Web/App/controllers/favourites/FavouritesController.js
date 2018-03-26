(function () {
    'use strict';
    FavBooksApp.controller('FavouritesController', FavouritesController);

    function FavouritesController($scope, $confirm, bookService, ngToast) {
        $scope.books = null;
        $scope.removeFromFavourite = _removeFromFavourite;
        $scope.totalItems = 0;
        $scope.itemsPerPage = 10;
        $scope.pagination = {
            current: 1
        };
        $scope.changePage = _changePage;
        $scope.removeFromFavourite = _removeFromFavourite;

        getResultsPage(1);

        function getResultsPage(pageNumber) {
            bookService.getFavourites(pageNumber, $scope.itemsPerPage).then(
                function (response) {
                    $scope.books = response.items || [];
                    $scope.totalItems = response.total;
                },
                function (response) {
                    $scope.books = null;
                    ngToast.create({
                        className: 'danger',
                        content: 'Internal error'
                    });
                });
        }

        function _changePage(newPage) {
            getResultsPage(newPage);
        };

        function _removeFromFavourite(isbn) {
            $confirm({ text: 'Are you sure that you want to remove?', title: 'Confirmation' }).then(function () {
                bookService.removeFromFavourite(isbn).then(
                    function (response) {
                        getResultsPage($scope.pagination.current);

                        ngToast.create({
                            className: 'success',
                            content: 'Successfully removed from your favourite lists'
                        });
                    },
                    function (response) {
                        if (response.status === 404) {
                            ngToast.create({
                                className: 'danger',
                                content: 'Could not find an item to remove'
                            });
                        }
                        else {
                            ngToast.create({
                                className: 'danger',
                                content: 'Internal error'
                            });
                        }
                    });
            });
        };

    }

    FavouritesController.$inject = ['$scope', '$confirm', 'bookService', 'ngToast'];
})();

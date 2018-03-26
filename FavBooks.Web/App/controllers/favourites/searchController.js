(function () {
    'use strict';
    FavBooksApp.controller('SearchController', SearchController);

    function SearchController($scope, bookService, ngToast) {
        $scope.searchForm = { isbn: "" };
        $scope.book = null;
        $scope.search = _search;
        $scope.addToFavourite = _addToFavourite;

        function _search() {
            if ($scope.searchForm.$valid) {
                bookService.search($scope.searchForm.isbn).then(
                    function (response) {
                        $scope.book = response;
                    },
                    function (response) {
                        $scope.book = null;
                        if (response.status === 404) {
                            ngToast.create({
                                className: 'danger',
                                content: 'Could not find a book with specified ISBN'
                            });
                        }
                        else {
                            ngToast.create({
                                className: 'danger',
                                content: 'Internal error'
                            });
                        }
                    });
            }
        }

        function _addToFavourite(isbn) {
            bookService.addToFavourite(isbn).then(
                function (response) {
                    ngToast.create({
                        className: 'success',
                        content: 'Added to your favourites lists'
                    });
                },
                function (response) {
                    if (response.status === 409) {
                        ngToast.create({
                            className: 'warning',
                            content: 'You already favourited this book'
                        });
                    } else if (response.status === 404) {
                        ngToast.create({
                            className: 'danger',
                            content: 'Could not find a book'
                        });
                    }
                    else {
                        ngToast.create({
                            className: 'danger',
                            content: 'Internal error'
                        });
                    }
                });
        }

    }

    SearchController.$inject = ['$scope', 'bookService', 'ngToast'];
})();

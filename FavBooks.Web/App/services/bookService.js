(function () {
    'use strict';
    FavBooksApp.factory('bookService', BookService);

    function BookService($http, ngAuthSettings) {

        var _search = function (isbn) {
            return $http.get(ngAuthSettings.apiServiceBaseUri + 'api/books/' + isbn).then(function (results) {
                return results.data;
            });
        }

        var _addToFavourite = function (isbn) {
            return $http.post(ngAuthSettings.apiServiceBaseUri + 'api/favourites/', { ISBN: Number(isbn)}).then(function (results) {
                return results;
            });
        }

        var _removeFromFavourite = function (isbn) {
            return $http.delete(ngAuthSettings.apiServiceBaseUri + 'api/favourites/' + isbn).then(function (results) {
                return results;
            });
        }

        var _getFavourites = function (page, itemsPerPage) {
            return $http.get(ngAuthSettings.apiServiceBaseUri + 'api/favourites/' + page + '/' + itemsPerPage).then(function (results) {
                return results.data;
            });
        }

        return {
            search: _search,
            addToFavourite: _addToFavourite,
            getFavourites: _getFavourites,
            removeFromFavourite: _removeFromFavourite
        };
    }

    BookService.$inject = ['$http', 'ngAuthSettings'];

}());
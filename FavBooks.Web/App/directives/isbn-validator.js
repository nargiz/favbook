/**
 * Modified version of: https://github.com/janantala/angular-isbn/
 */

(function () {
    'use strict';

    var ALLOWEDCHARS = /^[ -]*$/;
    var ISBN13WEIGHTS = [1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1];

    var checksum = function (arr, weights) {
        return arr
            .reduce(function (a, x, i) {
                a.push([Number(x), weights[i]]);
                return a;
            }, [])
            .reduce(function (sum, a) {
                return sum + a[0] * a[1];
            }, 0);
    };

    FavBooksApp.directive('isbn13', function () {
        return {
            require: 'ngModel',
            link: function (scope, elm, attrs, ctrl) {
                ctrl.$parsers.unshift(function (value) {

                    //not empty
                    if (!value || value && value.length === 0) {
                        ctrl.$setValidity('isbn13', true);
                        return value;
                    }

                    //allow only numbers
                    var nonNumericCharacters = value.replace(/\d/g, '');
                    if (nonNumericCharacters.length > 0) {
                        ctrl.$setValidity('isbn13', false);
                        return undefined;
                    }

                    //length (13) and checksum check
                    if (value.length === 13 && checksum(value.split(''), ISBN13WEIGHTS) % 10 === 0) {
                        ctrl.$setValidity('isbn13', true);
                        return value;
                    } else {
                        ctrl.$setValidity('isbn13', false);
                        return undefined;
                    }
                });
            }
        };
    });

})();
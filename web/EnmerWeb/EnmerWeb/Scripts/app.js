﻿var app = angular.module('EnmerApp', ['ngMaterial', 'ngMessages', 'ngMdIcons',
      'ui.router', 'ui.router.title', 'ngResource']);

router(app);

app.factory("fileReader", function ($q) {
    var onLoad = function (reader, deferred, scope) {
        return function () {
            scope.$apply(function () {
                deferred.resolve(reader.result);
            });
        };
    };

    var onError = function (reader, deferred, scope) {
        return function () {
            scope.$apply(function () {
                deferred.reject(reader.result);
            });
        };
    };

    var onProgress = function (reader, scope) {
        return function (event) {
            scope.$broadcast("fileProgress", {
                total: event.total,
                loaded: event.loaded
            });
        };
    };

    var getReader = function (deferred, scope) {
        var reader = new FileReader();
        reader.onload = onLoad(reader, deferred, scope);
        reader.onerror = onError(reader, deferred, scope);
        reader.onprogress = onProgress(reader, scope);
        return reader;
    };

    var readAsDataURL = function (file, scope) {
        var deferred = $q.defer();

        var reader = getReader(deferred, scope);
        reader.readAsDataURL(file);

        return deferred.promise;
    };
    return {
        readAsDataUrl: readAsDataURL
    };
});


app.directive('loading', ['$http', function ($http) {
        return {
            restrict: 'A',
            link: function (scope, elm, attrs) {
                scope.isLoading = function () {
                    return $http.pendingRequests.length > 0;
                };

                scope.$watch(scope.isLoading, function (v) {
                    if (v) {
                        elm.show();
                    } else {
                        elm.hide();
                    }
                });
            }
        };

    }]);

app.directive("ngFileSelect", function (fileReader, $timeout) {
      return {
          scope: {
              ngModel: '='
          },
          link: function ($scope, el) {
              function getFile(file) {
                  fileReader.readAsDataUrl(file, $scope)
                    .then(function (result) {
                        $timeout(function () {
                            $scope.ngModel = {};
                            $scope.ngModel.dataUrl = result;
                            $scope.ngModel.file = file;
                        });
                    });
              }

              el.bind("change", function (e) {
                  var file = (e.srcElement || e.target).files[0];
                  getFile(file);
                  (e.srcElement || e.target).value = null;
              });
          }
      };
  });


//http://stackoverflow.com/questions/14012239/password-check-directive-in-angularjs
angular.module('EnmerApp').directive('nxEqualEx', function () {
    return {
        require: 'ngModel',
        link: function (scope, elem, attrs, model) {
            if (!attrs.nxEqualEx) {
                console.error('nxEqualEx expects a model as an argument!');
                return;
            }
            scope.$watch(attrs.nxEqualEx, function (value) {
                // Only compare values if the second ctrl has a value.
                if (model.$viewValue !== undefined && model.$viewValue !== '') {
                    model.$setValidity('nxEqualEx', value === model.$viewValue);
                }
            });
            model.$parsers.push(function (value) {
                // Mute the nxEqual error if the second ctrl is empty.
                if (value === undefined || value === '') {
                    model.$setValidity('nxEqualEx', true);
                    return value;
                }
                var isValid = value === scope.$eval(attrs.nxEqualEx);
                model.$setValidity('nxEqualEx', isValid);
                return isValid ? value : undefined;
            });
        }
    };
});


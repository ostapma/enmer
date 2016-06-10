var app = angular.module('EnmerApp', ['ngMaterial', 'ngMessages', 'ngMdIcons',
      'ui.router', 'ui.router.title', 'ngResource']);
app.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise("/");
    $stateProvider
        .state('dashboard',
        {
            url: "/",
            templateUrl: "partials/dashboard",
            resolve: {
                $title: function () { return 'Dashboard'; }
            }
        });
    $stateProvider
        .state('myaccount',
        {
            url: "/myaccount",
            templateUrl: "partials/accountsettings",
            resolve: {
                $title: function () { return 'Account Settings'; }
            },
            controller: 'AccountSettingsCtrl'
        });

});

app.config([
    '$locationProvider', function ($locationProvider) {
        $locationProvider.html5Mode(true).hashPrefix('!');
    }
]);


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



angular.module('EnmerApp').factory('accountSettings', ['$resource',
      function ($resource) {
          return $resource('/api/accountSettings/', {}, {
              query: { method: 'GET', params: {} }
          });
      }]);

angular.module('EnmerApp').factory('image', ['$http', 'fileReader',
      function ($http) {
          return {
              save: function (file) {
                  var fd = new FormData();
                  fd.append('file', file);
                  return $http.post('api/image', fd,
                  {
                      transformRequest: angular.identity,
                      headers: { "Content-Type": undefined }
                  });

              }
          };
      }]);


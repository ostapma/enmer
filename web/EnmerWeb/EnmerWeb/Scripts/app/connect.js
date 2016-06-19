
angular.module('EnmerApp').factory('accountSettingsService', ['$resource',
      function ($resource) {
          return $resource('/api/accountSettings/', {}, {
              query: { method: 'GET', params: {} }
          });
      }]);

angular.module('EnmerApp').factory('profileSettingsService', ['$resource',
      function ($resource) {
          return $resource('/api/profileSettings/', {}, {
          });
      }]);

angular.module('EnmerApp').factory('loginSettingsService', ['$resource',
      function ($resource) {
          return $resource('/api/loginSettings/', {}, {
          });
      }]);

angular.module('EnmerApp').factory('passwordSettingsService', ['$resource',
      function ($resource) {
          return $resource('/api/passwordSettings/', {}, {
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

angular.module('EnmerApp').factory('loggingSourceService', ['$resource',
      function ($resource) {
          return $resource('/api/loggingsource/:id', {}, {
              'update': { method: 'PUT' }
          });
      }]);


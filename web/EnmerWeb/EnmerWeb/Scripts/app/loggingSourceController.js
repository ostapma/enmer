angular.module('EnmerApp')
    .controller('LoggingSourceAddController',
    function ($scope, $state, loggingSourceService) {
        $scope.source= {
            "isEnabled": true
        }
        $scope.save = function () {
            loggingSourceService.save($scope.source).$promise.then(
                function() {
                    $state.go("sources");
                }
            );

        }
        $scope.cancel = function () {
            $state.go("sources");
        }
    }
);

angular.module('EnmerApp')
    .controller('LoggingSourceEditController',
    function ($scope, $state, loggingSourceService) {
        $scope.source = loggingSourceService.get({ id: $state.params.sourceid });
        $scope.save = function () {
            loggingSourceService.update({ id:$scope.source.id },$scope.source).$promise.then(
                function () {
                    $state.go("sources");
                }
            );

        }
        $scope.cancel = function () {
            $state.go("sources");
        }
    }
);

angular.module('EnmerApp')
    .controller('LoggingSourceController',
    function ($scope, $state, loggingSourceService) {
        $scope.sources = loggingSourceService.query();
        $scope.add = function() {
            $state.go("sourcesAdd");
        }
        $scope.edit = function(source) {
            $state.go("sourcesEdit", { sourceid: source.id });
        }
        $scope.delete = function(source) {
            loggingSourceService.delete({ id: source.id }).$promise.then(function() {
                $scope.sources.splice($scope.sources.indexOf(source), 1);
            });

        }
        $scope.toggleEnabled = function (source) {
            source.isEnabled = !source.isEnabled;
            loggingSourceService.update({ id: source.id }, source);
           
        }

    }
);
angular.module('EnmerApp')
    .controller('LoggingSourceAddController',
    function ($scope, $state) {
        console.log(1);
        $scope.save = function() {
            $state.go("sources");
        }
    }
);
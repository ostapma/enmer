app.controller('EnmerCtrl',
    function($scope, $mdSidenav, accountSettings) {
        $scope.toggleSidenav = function(menuId) {
            $mdSidenav(menuId).toggle();
        };

        $scope.profile = accountSettings.query();

        $scope.updateProfile = function(profile) {
            $scope.profile = profile;
        }
    });
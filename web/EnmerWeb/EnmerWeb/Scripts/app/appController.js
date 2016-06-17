app.controller('EnmerCtrl',
    function($scope, $mdSidenav, accountSettingsService) {
        $scope.toggleSidenav = function(menuId) {
            $mdSidenav(menuId).toggle();
        };

        accountSettingsService.query({},
            function(accountSettings) {
                $scope.profile = accountSettings.profileSettings;
            });
        

       

        $scope.updateProfile = function(profile) {
            $scope.profile = profile;
        }
    });
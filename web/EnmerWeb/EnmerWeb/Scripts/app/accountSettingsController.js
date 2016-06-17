angular.module('EnmerApp').controller('AccountSettingsCtrl',
    function ($scope, accountSettingsService) {
        accountSettingsService.query({},
            function(accountSettings) {
                $scope.$broadcast('accountSettingsLoad', accountSettings);
            });

    }
);


angular.module('EnmerApp').controller('ProfileSettingsCtrl',
    function ($scope, profileSettingsService, image) {
        $scope.deletePicture = function() {
            delete $scope.settings.pictureID;
            delete $scope.image;
        };
        $scope.save = function() {
            var save = function() {
                profileSettingsService.save($scope.settings);
                $scope.updateProfile($scope.settings);
            };
            if ($scope.image) {
                image.save($scope.image.file)
                    .success(function(data, status) {
                        $scope.settings.pictureID = data;
                        save();
                    });
            } else save();

        };

        $scope.$on('accountSettingsLoad', function(event, accountSettings) {
             $scope.settings = accountSettings.profileSettings;
        });

    }


);

angular.module('EnmerApp').controller('LoginSettingsCtrl',
    function ($scope, loginSettingsService) {
        $scope.save = function() {
            loginSettingsService.save(JSON.stringify($scope.settings.email));
        };

        $scope.$on('accountSettingsLoad', function(event, accountSettings) {
            $scope.settings = { email: accountSettings.email };
        });


    }
);

angular.module('EnmerApp')
    .controller('PasswordSettingsCtrl',
        function($scope, passwordSettingsService) {
            $scope.save = function() {
                passwordSettingsService.save($scope.settings);
            };


        }
);
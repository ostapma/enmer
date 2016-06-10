angular.module('EnmerApp').controller('AccountSettingsCtrl',
    function ($scope, accountSettings, image) {
        $scope.deletePicture = function() {
            delete ($scope.settings.pictureID);
            delete ($scope.image);
        }
        $scope.save = function ()
        {
            var save = function() {
                $scope.settings.$save();
                $scope.updateProfile($scope.settings);
            }
            if ($scope.image) {
                image.save($scope.image.file)
                    .success(function(data, status) {
                        $scope.settings.pictureID = data;
                        save();
                    });
            }
            else save();

        }

        $scope.settings = accountSettings.query();
    }
);
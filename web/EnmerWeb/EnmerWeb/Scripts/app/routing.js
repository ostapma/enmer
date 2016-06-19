var router = function (app) {
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
                resolve: {
                    $title: function () { return 'Account Settings'; }
                },
                views: {
                    'content': {
                        templateUrl: 'partials/accountsettings',
                        controller: 'AccountSettingsCtrl'
                    }
                }
            });
        $stateProvider
            .state('sources',
            {
                url: "/sources",

                resolve: {
                    $title: function () { return 'Logging Sources'; }
                },

                views: {
                    'toolbar': {
                        templateUrl: 'partials/loggingsourcestoolbar',
                        controller: 'LoggingSourceController'
                    },

                    'content': {
                        templateUrl: 'partials/loggingsources',
                        controller: 'LoggingSourceController'
                    }
                }
            });

        $stateProvider
            .state('sourcesEdit',
            {
                url: "/{sourceid:[0-9]+}",
                resolve: {
                    $title: function () { return 'Edit Logging Source'; }
                },

                views: {
                    'toolbar': {
                        templateUrl: 'partials/loggingsourceedittoolbar',
                        controller: 'LoggingSourceEditController'
                    },

                    'content': {
                        templateUrl: 'partials/loggingsourceedit',
                        controller: 'LoggingSourceEditController'
                    }
                }
            });

        $stateProvider
            .state('sourcesAdd',
            {
                url: "/sources/add",
              
                resolve: {
                    $title: function () { return 'Add Logging Source'; }
                },
                views: {
                    'toolbar': {
                        templateUrl: 'partials/loggingsourceedittoolbar',
                        controller: 'LoggingSourceAddController'
                    },

                    'content': {
                        templateUrl: 'partials/loggingsourceedit',
                        controller: 'LoggingSourceAddController'
                    }
                }
            });

    });

    app.config([
        '$locationProvider', function ($locationProvider) {
            $locationProvider.html5Mode(true).hashPrefix('!');
        }
    ]);

};
var router = function(app) {
    app.config(function($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise("/");
        $stateProvider
            .state('dashboard',
            {
                url: "/",
                templateUrl: "partials/dashboard",
                resolve: {
                    $title: function() { return 'Dashboard'; }
                }
            });
        $stateProvider
            .state('myaccount',
            {
                url: "/myaccount",
                templateUrl: "partials/accountsettings",
                resolve: {
                    $title: function() { return 'Account Settings'; }
                },
                controller: 'AccountSettingsCtrl'
            });
        $stateProvider
            .state('sources',
            {
                url: "/sources",
                templateUrl: "partials/loggingsources",
                resolve: {
                    $title: function() { return 'Logging Sources'; }
                },
                controller : function() {
                    
                }
    });

        $stateProvider
            .state('sourcesEdit',
            {
                url: "/{sourceid:[0-9]+}",
                templateUrl: "partials/loggingsourceedit",
                resolve: {
                    $title: function() { return 'Edit Logging Source'; }
                }
            });

        $stateProvider
            .state('sourcesAdd',
            {
                url: "/sources/add",
                templateUrl: "partials/loggingsourceedit",
                resolve: {
                    $title: function() { return 'Add Logging Source'; }
                },
                controller: 'LoggingSourceAddController'
    });

    });

    app.config([
        '$locationProvider', function($locationProvider) {
            $locationProvider.html5Mode(true).hashPrefix('!');
        }
    ]);

};
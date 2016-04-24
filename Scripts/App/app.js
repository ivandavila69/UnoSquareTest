angular.module('boardGameModule', ['ngRoute', 'ui.bootstrap']).config(['$routeProvider', '$locationProvider',
  function ($routeProvider, $locationProvider) {
      $routeProvider.
        when('/boardgame', {
            templateUrl: 'scripts/App/views/boardgames-list.html',
            controller: 'boardGameCtrl'
        }).
          otherwise({
            redirectTo: '/boardgame'
        });
  }]);
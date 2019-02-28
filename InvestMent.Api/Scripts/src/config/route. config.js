(function () {
  'use strict';

  angular
    .module('app')
    .config(["$routeProvider", routeConfig])
    .run(['$rootScope', '$location', 'accountService', routeGuard]);

  function routeConfig($routeProvider) {
    $routeProvider.when('/home', {
      template: "<home></home>"
    }).when('/login', {
      template: '<login></login>'
      }).when('/main', {
        template:'<main></main>'
      })
      .otherwise({
        template: "<home></home>"
      })
  }
  function routeGuard($rootScope, $location, accountService) {
    const publicRoute = ['/signin', '/login'];
    $rootScope.$on('$routeChangeStart', () => {
      const authRequired = publicRoute.indexOf($location.path()) == -1;
      if (authRequired &&
        !accountService.isAuth()) {
        $location.path('/login')
      }
    })
  }
}());

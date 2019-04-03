(function () {
  'use strict';

  angular
    .module('app')
    .component('register', register());
  function register() {
    function registerController(location, accountService) {
      var vm = this;
      vm.$onInit = function () {
        vm.user = {}
      }
      vm.submit = function () {
        accountService.login(vm.user)
          .then(succ => location.path('/home'))
          .catch(handleError)
      }
      function handleError(er) {
        console.log(er);
      }
    }
    return {
      bindings: {},
      templateUrl: resolve('register'),
      controller: ['$location', "accountService", loginController],
    }
  }

}());

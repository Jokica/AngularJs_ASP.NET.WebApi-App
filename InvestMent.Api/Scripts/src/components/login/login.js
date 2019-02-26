(function () {
  'use strict';

  angular
    .module('app')
    .component('login', login());
  function login() {
    function loginController(location, accountService) {
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
      templateUrl: resolve('login'),
      controller: ['$location', "accountService", loginController],
    }
  }

}());

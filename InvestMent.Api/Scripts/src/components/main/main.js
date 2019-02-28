(function () {
  'use strict';

  angular
    .module('app')
    .component('myMain', myMain());


  function myMain() {

    function myMainController() {
      var vm = this;

      init();

      function init() {
        vm.details = "My site - 2019"
      }
    }

    return {
      bindings: {},
      replace: true,
      templateUrl: resolve('main'),
      controller: myMainController,
    }
  }

}());

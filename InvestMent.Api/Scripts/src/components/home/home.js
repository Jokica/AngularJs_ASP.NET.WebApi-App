(function () {
  'use strict';
  angular
    .module('app')
    .component('home', home());

  function home() {
    function homeController() {
      var vm = this;
      vm.header = 'Who are we?'
    }
    return {
      bindings: {},
      controller: homeController,
      templateUrl:resolve('home')
    }
  }
}());

(function () {
  'use strict';
  angular
    .module('app')
    .component('home', home());

  function home() {
    function homeController() {
      var vm = this;
      vm.title = 'Hello World'
    }
    return {
      bindings: {},
      controller: homeController,
      templateUrl:resolve('home')
    }
  }
}());

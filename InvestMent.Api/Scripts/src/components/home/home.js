(function () {
  'use strict';
  angular
    .module('app')
    .component('home', home());

  function home() {
    function homeController( $location) {
      const vm = this;
      vm.header = 'Who are we?'

      vm.buildPancake = function () {
        console.log("Clicked")
        $location.path("/build");
      };
      vm.pickPancake = function () {
        console.log("Clicked")
        $location.path("/pick");
      };
    }
    return {
      bindings: {},
      controller: ['$location',homeController],
      templateUrl:resolve('home')
    }
  }
}());

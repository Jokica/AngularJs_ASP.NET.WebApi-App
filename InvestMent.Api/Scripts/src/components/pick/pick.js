(function () {
  'use strict';
  angular
    .module('app')
    .component('pick', pick());

  function pick() {
    function pickController() {
      var vm = this;
    }
    return {
      bindings: {},
      controller: [




        pickController],
      templateUrl: resolve('pick')
    }
  }
}());

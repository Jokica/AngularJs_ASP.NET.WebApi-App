(function () {
  'use strict';

  angular
    .module('app')
    .component('app', app());


  function app() {

    function appController() {
      var vm = this;

      init();

      function init() {
        vm.title = "Hello Wolrd -- APP"
      }
    }

    return {
      bindings: {},
      templateUrl:"/Scripts/src/components/app.html",
      controller: appController,
    }
  }

}());

(function () {
  'use strict';
  angular
    .module('app')
    .component('build', build());

  function build() {
    function buildController(ingredientsService) {
      const vm = this;
      vm.ingredients = ingredientsService.ingredients;
      console.log(vm.ingredients[0].imgUrl)
    }
    return {
      bindings: {},
      controller: ['ingredientsService', buildController],
      templateUrl: resolve('build')
    }
  }
}());

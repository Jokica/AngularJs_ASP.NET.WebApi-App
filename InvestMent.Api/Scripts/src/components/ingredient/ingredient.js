(function () {
  'use strict';
  angular
    .module('app')
    .component('ingredient', ingredient());

  function ingredient() {
    function ingredientController() {
      const vm = this;
      console.log(vm);
    }
    return {
      bindings: {
        title :'<',
        brand :'<',
        imgUrl :'<',
        type :'<'
      },
      controller: [ingredientController],
      templateUrl: resolve('ingredient')
    }
  }
}());

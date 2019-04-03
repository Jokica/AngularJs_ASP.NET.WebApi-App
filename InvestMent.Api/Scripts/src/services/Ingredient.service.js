
(function () {
  'use strict';
  angular
    .module('app.service')
    .factory('ingredientsService', ['$http', ingredientsService]);

  function ingredientsService(http) {
    return {
      ingredients
    };
  }
  const ingredients = [
    { type: "Chocolate", name: "asd", brand: "brads", imgUrl : "/Scripts/src/img/build.jpeg"},
    { type: "Chocolate", name: "asd", brand: "brads", imgUrl : "/Scripts/src/img/build.jpeg"},
    { type: "Chocolate", name: "asd", brand: "brads", imgUrl : "/Scripts/src/img/build.jpeg"},
    { type: "Chocolate", name: "asd", brand: "brads", imgUrl: "/Scripts/src/img/build.jpeg" },
    { type: "Chocolate", name: "asd", brand: "brads", imgUrl: "/Scripts/src/img/build.jpeg" },
    { type: "Chocolate", name: "asd", brand: "brads", imgUrl: "/Scripts/src/img/build.jpeg" },
    { type: "Chocolate", name: "asd", brand: "brads", imgUrl: "/Scripts/src/img/build.jpeg" },
    { type: "Chocolate", name: "asd", brand: "brads", imgUrl: "/Scripts/src/img/build.jpeg" },

  ]
})();

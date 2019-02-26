(function () {
  angular.module('app.service', ['LocalStorageModule']);
  angular.module('app', ['app.service','ngRoute']);
}())

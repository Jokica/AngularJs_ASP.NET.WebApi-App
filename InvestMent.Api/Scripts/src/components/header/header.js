(function () {
    'use strict';

    angular
        .module('app')
        .component('myHeader', myHeader());
    function myHeader() {
        function myHeaderController($location,accountService) {
            var vm = this;
            vm.$onInit = function(){
                vm.title = "MySite";
                vm.links = ['home', 'investmets', 'profile'];
            }
            vm.logout= function(){
                accountService.logout();
                $location.path('/login')
            } 
            vm.isAuth = accountService.isAuth;
            vm.getName = accountService.getName;
        }
        return {
            bindings: {},
            replace: true,
            templateUrl: resolve('header'),
            controller: ['$location','accountService',myHeaderController],
        }
    }

}());

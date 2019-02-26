(function () {
    'use strict';

    angular
        .module ('app')
        .component ('logout', logout());


    function logout() {

        function logoutController(accService){
            var vm = this;
            
            init();

            function init(){

            }
        }

        return {
            bindings: {},
            controller: ['accountService',logoutController],
            templateUrl:resolve('logout')
        }
    }

} ());
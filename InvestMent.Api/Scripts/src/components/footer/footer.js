(function () {
    'use strict';

    angular
        .module ('app')
        .component ('myFooter', myFooter());


    function myFooter() {

        function myFooterController(){
            var vm = this;
            
            init();

            function init(){
                vm.details = "My site - 2019"
            }
        }

        return {
            bindings: {},
            replace:true,
            templateUrl:resolve('footer'),
            controller: myFooterController,
        }
    }

} ());
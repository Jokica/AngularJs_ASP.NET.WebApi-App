(function () {
    'use strict';

    angular
        .module ('app')
        .component ('myInput', myInput());

    function myInput() {
        function myInputController(){
            var vm = this;
            vm.$onInit = function(){
                vm.type = vm.type || 'text';

            }
            vm.submit = function(){
                alert("asd")
            }
        }
        return {
            bindings: {
                type:'@',
                name:'@',
                value:'=',
                required:'@',
                minLen:'@',
                maxLen:'@',
                form:'<',
                submited:'<',
                label:'@'
            },
            controller: myInputController,
            templateUrl:resolve('input'),

        }
    }
} ());
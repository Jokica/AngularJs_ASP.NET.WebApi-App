(function(){
    'use strict';

    angular
        .module('app')
        .config(['$httpProvider',httpConfig])

    /** @ngInject */
    function httpConfig($httpProvider){
        $httpProvider.interceptors.push('authRequest')
    }

}());
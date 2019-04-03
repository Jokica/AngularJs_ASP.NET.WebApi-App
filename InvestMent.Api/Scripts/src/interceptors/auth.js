(function () {
    'use strict';

    angular
        .module('app.service')
        .factory('authRequest', ['$location', 'localStorageService', authRequest])

    /** @ngInject */
    function authRequest(location, localStorageService) {
        return {
            request,
            responseError
        }
        function request(config) {
            config.headers = config.headers || {}

            const authData = localStorageService.get('user');
          if (authData) {
            console.log(authData.token);
                config.headers['Authorization'] = 'Bearer ' + authData.token;
            }
            return config;
        }
        function responseError(rejection) {
            if (rejection.status === 401) {
                location.path('/login')
            }
            return rejection;
        }

    }

}());

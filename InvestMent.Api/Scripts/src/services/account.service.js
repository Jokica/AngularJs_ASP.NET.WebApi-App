
(function () {
  'use strict';

  angular
    .module('app.service')
    .factory('accountService', ['$http', 'localStorageService','$rootScope', accountService]);

  function accountService(http, storage,$rootScope) {
 
    return  {
      login,
      signUp,
      isAuth,
      getName,
      logout
    };
    function isAuth(){
      return storage.get('user') != undefined
    }
    function getName(){
     return storage.get('user').name
    }
    function login(credetions) {
      const data = formUrlEncoded(credetions.UserName, credetions.Password);
      $rootScope.$broadcast('auth', true);
      return http({
        method: "POST",
        url: '/token',
        data,
        headers: {
          "Content-Type": "application/x-www-form-urlencoded"
        }
      }).then(x => {
        
        storage.set('user', { token: x.access_token, name: credetions.UserName });
      });
    }
    function logout() {
      $rootScope.$broadcast('auth', false);
      storage.remove('user');
    }
    function signUp(credetions) {
      logout()
      $rootScope.$broadcast('auth', true);
        return http({
          method:'POST',
          url:'/api/account/register',
          data:credetions
        })
    }
    function formUrlEncoded(name, pass) {
      return "grant_type=password&username=" + name + "&password=" + pass;
    }
  }
})();

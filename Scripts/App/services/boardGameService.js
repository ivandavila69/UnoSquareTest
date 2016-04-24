angular.module('boardGameModule').factory('boardGameService', function ($http) {
    var fac = {};
    var urlBase = 'api/boardgame/';

    fac.GetAllRecords = function () {
        return $http.get(urlBase);
    };
    fac.Edit = function (boardGame) {
        return $http.put(urlBase + '/' + boardGame.Id, boardGame)
    };
    fac.Add = function (boardGame) {
        return $http.post(urlBase, boardGame);
    };
    fac.Delete = function (boardGame) {
        return $http.delete(urlBase + '/' + boardGame.Id);
    }
    return fac;
});

angular
    .module('boardGameModule')
    .controller("editBoardGameCtrl", ["$scope", "boardGame", "$uibModalInstance",

function editBoardGameCtrl($scope, boardGame, $uibModalInstance) {
    $scope.BoardGame = _.clone(boardGame);

    $scope.update = function () {
        //Call update api
        //On Success
        $uibModalInstance.close($scope.BoardGame);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);


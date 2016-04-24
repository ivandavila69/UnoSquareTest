angular
    .module('boardGameModule')
    .controller("deleteBoardGameCtrl", ["$scope", "boardGame", "$uibModalInstance",

function editBoardGameCtrl($scope, boardGame, $uibModalInstance) {
    $scope.BoardGame = _.clone(boardGame);

    $scope.proceed = function () {
        console.log("board game before close  ", $scope.BoardGame);
        $uibModalInstance.close($scope.BoardGame);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);



angular
    .module('boardGameModule')
    .controller("addBoardGameCtrl", ["$scope", "$uibModalInstance",

function editBoardGameCtrl($scope, $uibModalInstance) {
    $scope.BoardGame = {
        Id: 0,
        Name: '',
        Players: '',
        Category: '',
        Ages: '',
        Comments: ''
    };

    $scope.save = function (_boardGame) {
        $scope.BoardGame = _.clone(_boardGame);
        $uibModalInstance.close($scope.BoardGame);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);

angular.module('boardGameModule').controller("boardGameCtrl", ["$scope", "boardGameService", "$uibModal",
  function ($scope, boardGameService, $uibModal) {
      $scope.boardGamesData = boardGameService.GetAllRecords();

      $scope.BoardGame = {
          Id: '',
          Name: '',
          Players: '',
          Category: '',
          Ages: '',
          Comments: ''
      };

      // Reset board game details
      $scope.clear = function () {
          $scope.BoardGame.Id = '';
          $scope.BoardGame.Players = '';
          $scope.BoardGame.Price = '';
          $scope.BoardGame.Category = '';
          $scope.BoardGame.Ages = '';
          $scope.BoardGame.Comments = '';
      }

      boardGameService.GetAllRecords().then(function (d) {
          $scope.boardGamesData = d.data;
      }, function () {
          alert('error ! board games not loaded');
      });

      $scope.edit = function (data) {
          var modalInstance = $uibModal.open({
              animation: $scope.animationsEnabled,
              templateUrl: 'scripts/App/views/editBoardGame.html',
              controller: 'editBoardGameCtrl',
              size: 'lg',
              resolve: {
                  boardGame: function () {
                      return data;
                  }
              }
          });

          modalInstance.result.then(function (boardGameUpd) {
              var updatedBoardGame = _.find($scope.boardGamesData, function (_item) {
                  return _item.Id == boardGameUpd.Id;
              });
              boardGameService.Edit(boardGameUpd);
              updatedBoardGame = _.extend(updatedBoardGame, boardGameUpd);

          }, function () {
              $log.info('Modal dismissed at: ' + new Date());
          });
      }

      $scope.delete = function (data) {
          var modalInstance = $uibModal.open({
              animation: $scope.animationsEnabled,
              templateUrl: 'scripts/App/views/deleteBoardGame.html',
              controller: 'deleteBoardGameCtrl',
              size: 'lg',
              resolve: {
                  boardGame: function () {
                      return data;
                  }
              }
          });

          modalInstance.result.then(function (boardGameUpd) {
              boardGameService.Delete(boardGameUpd).then(function () {
                  var index = $scope.boardGamesData.indexOf(boardGameUpd);
                  $scope.boardGamesData.splice(index, 1);
              });

          }, function () {
              $log.info('Modal dismissed at: ' + new Date());
          });
      }

      $scope.add = function () {
          var modalInstance = $uibModal.open({
              animation: $scope.animationsEnabled,
              templateUrl: 'scripts/App/views/addBoardGame.html',
              controller: 'addBoardGameCtrl',
              size: 'lg'
          });

          modalInstance.result.then(function (newBoardGame) {
              boardGameService.Add(newBoardGame);
              $scope.boardGamesData.push(newBoardGame);
          }, function () {
              $log.info('Modal dismissed at: ' + new Date());
          });
      }
  }]);








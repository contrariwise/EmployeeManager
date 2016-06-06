'use strict';

var app = angular.module('employeeApp.controllers', []);

app.controller('mainController', ['$scope', 'EmployeesFactory', 'EmployeeFactory', '$location',
  function ($scope, EmployeesFactory, EmployeeFactory, $location) {

      $scope.employees = EmployeesFactory.query();
      $scope.currentEmployee = EmployeeFactory.show({ id: 1 });
      $scope.setCurrentEmployee = function(employee) {
          $scope.currentEmployee = EmployeeFactory.show({ id: employee.EmployeeNo });
      }

  }]);


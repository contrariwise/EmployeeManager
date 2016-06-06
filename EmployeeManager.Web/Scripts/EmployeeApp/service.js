'use strict';

var services = angular.module('employeeApp.services', ['ngResource']);

services.factory('EmployeesFactory', function ($resource) {
    return $resource('/api/employees', {}, {
        query: { method: 'GET', isArray: true }
    });
});

services.factory('EmployeeFactory', function ($resource) {
    return $resource('/api/employees/:id', {}, {
        show: { method: 'GET' }
    });
});
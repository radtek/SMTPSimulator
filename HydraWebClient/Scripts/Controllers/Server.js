﻿(function () {
    angular.module("Server", ["ui.grid", "ui.grid.edit", "ui.grid.rowEdit", "ui.grid.selection", "ui.bootstrap.modal", "ui.bootstrap.tooltip"])
        .service("BindingService", ["$http", DataService("api/ReceiveConnectors")])
        .service("SubnetService", ["$http", DataService("api/ServerSubnets")])

        .service("TimeTableService", ["$http", DataService("api/TimeTables")])

        .service("ServerService", [
            "$http", function($http) {
                this.get = function() {
                    return $http.get("api/Server");
                };

                this.set = function(config) {
                    return $http.post("api/Server", config);
                };
            }
        ])
        .controller("ServerController", [
            "$scope", "$modal", "TimeTableService", "$http", function ($scope, $modal, TimeTableService, $http) {
                $scope.running = null;
                $scope.status = "???";
                $scope.serviceVersion = "???";
                $scope.serviceBuildDate = "???";
                $scope.uiVersion = "???";
                $scope.uiBuildDate = "???";
                $scope.domains = [];
                $scope.timeTables = [];

                $http.get("api/Server/IsRunning")
                    .success(function(running) {
                        $scope.running = running;
                        $scope.status = running ? "Running" : "Stopped";
                    })
                    .error(function(data) {
                        $scope.status = "Error";
                        showError(data.Message);
                    });

                $scope.start = function() {
                    $http.get("api/Server/Start")
                        .success(function() {
                            $scope.running = true;
                            $scope.status = "Running";
                        })
                        .error(function(data) {
                            showError(data.Message);
                        });
                };

                $scope.stop = function() {
                    $http.get("api/Server/Stop")
                        .success(function() {
                            $scope.running = false;
                            $scope.status = "Stopped";
                        })
                        .error(function(data) {
                            showError(data.Message);
                        });
                };

                $http.get("api/Server/Version")
                    .success(function (versionInfo) {
                        var v = versionInfo.ServiceVersion;
                        $scope.serviceVersion = v._Major + "." + v._Minor + "." + v._Build + "." + v._Revision;
                        $scope.serviceBuildDate = versionInfo.ServiceBuildDate;
                        v = versionInfo.UiVersion;
                        $scope.uiVersion = v._Major + "." + v._Minor + "." + v._Build + "." + v._Revision;
                        $scope.uiBuildDate = versionInfo.UiBuildDate;
                    })
                    .error(function (data) {
                        $scope.version = "Error";
                        $scope.buildDate = "Error";
                        showError(data.Message);
                    });

                $http.get("api/Domains/WithMailboxCount")
                    .success(function (domains) {
                        $scope.domains = domains;
                    })
                    .error(function (data) {
                        showError(data.Message || data.data.Message);
                    });

                TimeTableService.all()
                    .success(function (timeTables) {
                        $scope.timeTables = timeTables;
                    })
                    .error(function (data) {
                        showError(data.Message || data.data.Message);
                    });
            }
        ]);
})();
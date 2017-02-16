var VehicleRecord = angular.module('VehicleRecord', []);

VehicleRecord.controller('AngularController', AngularController);

angular.module('VehicleRecord', [])
.controller('AngularController', ['$scope', '$http', function ($scope, $http) {

    $scope.selectDisabled = true;
    $scope.init = function (brandModels) {
        $scope.brandModelList = brandModels;
    }
    

    $scope.SaveVehicleClick = function () {
        if (!$("#vehicleBrand").val() || !$("#vehicleBrandModelHelp").val() || !$("#chassisNumber").val() || !$("#motorNumber").val()
            || !$("#motorPower").val() || !$("#motorPower_Hp").val() || !$("#fuelType").val() ||! $("#yearOfProduction").val()) {
                document.getElementById("warningMessage").innerHTML = "Niste ispravno unijeli podatke. Molim ponovite unos";
        }
        else {
            $scope.SaveVehicle(-1, $("#vehicleBrand").val(), $("#vehicleBrandModelHelp").val(), $("#chassisNumber").val(), $("#motorNumber").val(), $("#motorPower").val(), $("#motorPower_Hp").val(), $("#fuelType").val(), $("#yearOfProduction").val());
            document.getElementById("warningMessage").innerHTML = "";
        }
    }


    $scope.SaveVehicle = function (id, brandId, brandModelId, chassisNumber, motorNumber, motorPower, motorPower_Hp, fuelTypeId, yearOfProduction) {
        var post = $http({
            method: "POST",
            url: "/Vehicles/SaveVehicle",
            dataType: 'json',
            headers: { 'Content-Type': "application/json" },
            params: { id: id, brandId: brandId, brandModelId: brandModelId, chassisNumber: chassisNumber, motorNumber: motorNumber, motorPower: motorPower, motorPower_Hp: motorPower_Hp, fuelTypeId: fuelTypeId, yearOfProduction: yearOfProduction }
        });
        post.success(function (data, status) {
            window.location.reload();
        });

        post.error(function (data, status) {
            document.getElementById("warningMessage").innerHTML = "Greška na serveru. Izvinjavamo se.";
        });
    }

    $scope.EditVehicle = function (id, brandId, brandModelId, chassisNumber, motorNumber, motorPower, motorPower_Hp, fuelTypeId, yearOfProduction) {
        var brandName = document.getElementById('brandName.' + id).innerText;

        document.getElementById('brandName.' + id).classList.add("ng-hide");
        document.getElementById('input.brandName.' + id).classList.remove("ng-hide");
        document.getElementById('input.brandName.' + id).value = brandId;

        document.getElementById('brandModelValue.' + id).value = brandModelId;
        document.getElementById('brandModelName.' + id).classList.add("ng-hide");
        document.getElementById('input.brandModelName.' + id).classList.remove("ng-hide");
        document.getElementById('input.brandModelName.' + id).value = brandModelId;

        document.getElementById('chassisNumber.' + id).classList.add("ng-hide");
        document.getElementById('input.chassisNumber.' + id).classList.remove("ng-hide");
        document.getElementById('input.chassisNumber.' + id).value = chassisNumber;

        document.getElementById('motorNumber.' + id).classList.add("ng-hide");
        document.getElementById('input.motorNumber.' + id).classList.remove("ng-hide");
        document.getElementById('input.motorNumber.' + id).value = motorNumber;

        document.getElementById('motorPower.' + id).classList.add("ng-hide");
        document.getElementById('input.motorPower.' + id).classList.remove("ng-hide");
        document.getElementById('input.motorPower.' + id).value = motorPower;

        document.getElementById('motorPower_Hp.' + id).classList.add("ng-hide");
        document.getElementById('input.motorPower_Hp.' + id).classList.remove("ng-hide");
        document.getElementById('input.motorPower_Hp.' + id).value = motorPower_Hp;

        document.getElementById('fuelType.' + id).classList.add("ng-hide");
        document.getElementById('input.fuelType.' + id).classList.remove("ng-hide");
        document.getElementById('input.fuelType.' + id).value = fuelTypeId;

        document.getElementById('yearOfProduction.' + id).classList.add("ng-hide");
        document.getElementById('input.yearOfProduction.' + id).classList.remove("ng-hide");
        document.getElementById('input.yearOfProduction.' + id).value = yearOfProduction;

        document.getElementById('editButton.' + id).classList.add("ng-hide");
        document.getElementById('saveButton.' + id).classList.remove("ng-hide");

        $scope.EnableBrandModelsEdit(id, brandId);
    }

    $scope.EditSaveVehicle = function (id) {
        if (!document.getElementById('input.brandName.' + id).value || !document.getElementById('input.brandModelNameHelp.' + id).value ||
            !document.getElementById('input.chassisNumber.' + id).value || !document.getElementById('input.motorNumber.' + id).value
            || !document.getElementById('input.motorPower.' + id).value || !document.getElementById('input.motorPower_Hp.' + id).value
            || !document.getElementById('input.fuelType.' + id).value || !document.getElementById('input.yearOfProduction.' + id).value) {
                document.getElementById("warningMessage").innerHTML = "Niste ispravno unijeli podatke. Molim ponovite unos";
        }
        else {
            $scope.SaveVehicle(id, document.getElementById('input.brandName.' + id).value, document.getElementById('input.brandModelNameHelp.' + id).value,
                document.getElementById('input.chassisNumber.' + id).value, document.getElementById('input.motorNumber.' + id).value,
                document.getElementById('input.motorPower.' + id).value, document.getElementById('input.motorPower_Hp.' + id).value,
                document.getElementById('input.fuelType.' + id).value, document.getElementById('input.yearOfProduction.' + id).value);
        }
    }

        $scope.EnableBrandModels = function () {
            $scope.selectDisabled = false;
            $scope.brandModels = [];
            for (var i = 0; i < $scope.brandModelList.length; i++) {
                if ($scope.brandModelList[i].BrandId == parseInt($("#vehicleBrand").val())) {
                    console.log($scope.brandModelList[i]);
                    $scope.brandModels.push($scope.brandModelList[i]);
                }
            }
        }

        $scope.EnableBrandModelsEdit = function (id) {
            $scope.brandModelsEdit = [];
            for (var i = 0; i < $scope.brandModelList.length; i++) {
                if ($scope.brandModelList[i].BrandId == parseInt(document.getElementById('input.brandName.' + id).value)) {
                    $scope.brandModelsEdit.push($scope.brandModelList[i]);
                }
            }
            document.getElementById('input.brandModelName.' + id).value = 3;
        }

        $scope.DeleteVehicle = function (id, canBeDeleted) {
            if (canBeDeleted == 'False') {
                document.getElementById("warningMessage").innerHTML = "Izabrano vozilo se već nalazi u evidenciji i nije ga moguće obrisati.";
            }
            else {
                var post = $http({
                    method: "POST",
                    url: "/Vehicles/DeleteVehicle",
                    dataType: 'json',
                    headers: { 'Content-Type': "application/json" },
                    params: { vehicleId: id }
                });
                post.success(function (data, status) {
                    window.location.reload();
                });

                post.error(function (data, status) {
                    alert(data);
                });
                document.getElementById("warningMessage").innerHTML = "";
            }
        };

    $scope.SaveRecordClick = function () {
        if ($("#vehicleId").val() == "? undefined:undefined ?" || !$("#dateFrom").val() || !$("#timeFrom").val() || !$("#dateTo").val()
            || !$("#timeTo").val() || !$("#locationFrom").val() || !$("#locationTo").val() || !$("#driverName").val()
            || !$("#driverSurname").val() || !$("#numberOfPassangers").val()) {
                document.getElementById("warningMessage").innerHTML = "Niste ispravno unijeli podatke. Molim ponovite unos";
        }
        else {
            $scope.SaveRecord(-1, $("#vehicleId").val(), $("#dateFrom").val(), $("#timeFrom").val(), $("#dateTo").val(),
            $("#timeTo").val(), $("#locationFrom").val(), $("#locationTo").val(), $("#driverName").val(),
            $("#driverSurname").val(), $("#numberOfPassangers").val(), 1);
            document.getElementById("warningMessage").innerHTML = "";
        }
    }

    $scope.SaveRecord = function (id, vehicleId, dateFrom, timeFrom, dateTo, timeTo, locationFrom, locationTo, driverName, driverSurname, numberOfPassangers, statusId) {
        var post = $http({
            method: "POST",
            url: "/Records/SaveRecord",
            dataType: 'json',
            headers: { 'Content-Type': "application/json" },
            params: {
                recordId: id, vehicleId: vehicleId, dateFrom: dateFrom, timeFrom: timeFrom, dateTo: dateTo, timeTo: timeTo, locationFrom: locationFrom,
                locationTo: locationTo, driverName: driverName, driverSurname: driverSurname, numOfPassangers: numberOfPassangers, statusId: statusId
            }
        });
        post.success(function (data, status) {
            if (data != '')
                document.getElementById("warningMessage").innerHTML = data;
            else
                window.location.reload();
        });

        post.error(function (data, status, error) {
            console.log("Error:" + data);
            document.getElementById("warningMessage").innerHTML = "Greška na serveru. Izvinjavamo se.";
        });
    }

    $scope.EditRecord = function (id, statusId) {

        document.getElementById('statusId.' + id).classList.add("ng-hide");
        document.getElementById('input.statusId.' + id).classList.remove("ng-hide");
        document.getElementById('input.statusId.' + id).value = statusId;

        document.getElementById('editButton.' + id).classList.add("ng-hide");
        document.getElementById('editSaveButton.' + id).classList.remove("ng-hide");
    }

    $scope.UpdateRecordStatus = function (id) {
        if (!document.getElementById('input.statusId.' + id).value)
            document.getElementById("warningMessage").innerHTML = "Niste unijeli ispravne vrijednosti. Molim ponovite unos.";
        else{
            var post = $http({
                method: "POST",
                url: "/Records/UpdateRecordStatus",
                dataType: 'json',
                headers: { 'Content-Type': "application/json" },
                params: {
                    id: id, statusId: parseInt(document.getElementById('input.statusId.' + id).value)
                }
            });
            post.success(function (data, status) {
                window.location.reload();
            });

            post.error(function (data, status, error) {
                document.getElementById("warningMessage").innerHTML = "Greška na serveru. Izvinjavamo se.";
            });
        }
    }

    $scope.GetReports = function () {
        var post = $http({
            method: "POST",
            url: "/Reports/Index",
            dataType: 'json',
            headers: { 'Content-Type': "application/json" },
            params: {
                vehicleId: $("#vehicleReportId").val(), dateFrom: $("#dateFromReport").val(), dateTo: $("#dateToReport").val(),
                timeFrom: $("#timeFromReport").val(), timeTo: $("#timeToReport").val()
            }
        });

        post.error(function (data, status, error) {
            console.log(status, error);
            document.getElementById("warningMessage").innerHTML = "Greška na serveru. Izvinjavamo se.";
        });
    }
    
}]);
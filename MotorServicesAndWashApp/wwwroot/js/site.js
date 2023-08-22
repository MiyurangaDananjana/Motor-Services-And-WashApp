var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl)
});

function loadDistrictsForProvince(selectedProvinceId) {
    $.ajax({
        type: "GET",
        url: "/GetDistrict/" + selectedProvinceId,
        success: function (data) {
            $("#secondDropdown").empty();
            data.forEach(function (item) {
                $("#secondDropdown").append($('<option></option>').val(item.districtsId).text(item.districtsName));
            });
           
        },
        error: function (error) {
            console.log(error);
        }
    });
};
function loadCitiesForDistrict(selectedDistrictId) {
    $.ajax({
        type: "GET",
        url: "/GetCities/" + selectedDistrictId,
        success: function (data) {
            $("#thirdDropdown").empty();
            data.forEach(function (item) {
                $("#thirdDropdown").append($('<option></option>').val(item.citiesId).text(item.citiesName));
            });

        },
        error: function (error) {
            console.log(error);
        }
    });
};

$("#secondDropdown").change(function () {
    var selectedValue = $(this).val();
    setDistricIdToInput(selectedValue);
});

function loadCities(Id) {
    saveSelectedCity($("#thirdDropdown").val());
}

function setDistricIdToInput(DistrictId) {
    $('#InputDistrictId').val(DistrictId);
}

function saveSelectedCity(cityId) {
    $("#InputCityId").val(cityId);
}


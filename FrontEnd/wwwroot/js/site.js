// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function btnCircleClick() {
    alert("Please click Free or Busy button to change harbour status");
}


function btnBusyClick() {
    $.ajax('/backend/busyharbour', {
        type: 'POST',
        success: function (result) {
            $("#shipTable").html(result);
            $("#btnGreenCircle").hide();
            $("#btnRedCircle").show();
            alert("Ship successfully queued");
        },
        error: function () {
            alert("Something went wrong");;
        }
    });  
}


function btnFreeClick() {
    $.ajax('/backend/freeharbour', {
        type: 'POST',
        success: function (result) {
            $("#shipTable").html(result);
            $("#btnGreenCircle").show();
            $("#btnRedCircle").hide();
        },
        error: function () {
            alert("Something went wrong");;
        }
    });   
}

function addShipsBtnClick() {
    $.ajax('/backend/addships', {
        type: 'POST',  
        success: function (result) {
            $("#shipTable").html(result);
        },
        error: function () {
            alert("Something went wrong");;
        }
    });
}

function resetBtnClick() {
    $.ajax('/backend/reset', {
        type: 'POST',
        success: function (result) {
            $("#shipTable").html(result);
        },
        error: function () {
            alert("Something went wrong");;
        }
    });
}

function addExitsBtnClick() {
    window.close();
}

setInterval(() => {
    checkServiceStatus();
}, 18000);

function checkServiceStatus() {
    $.ajax('/backend/updatewindspeed', {
        type: 'POST',
        success: function (result) {
            $("#windSpeedDiv").html(result);
        },
        error: function () {
            alert("Something went wrong");;
        }
    });
}
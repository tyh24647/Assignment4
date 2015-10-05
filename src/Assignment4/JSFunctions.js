var hostURL = "http://localhost:22211/api/values/";


function forceGetFunc() {
    $.ajax(hostURL, {
        method: "GET",
        success: simpleResponse
    });
}


function getRandIndexVal(data) {
    var indexCount = data.length;
    var randIndex = Math.floor(Math.random() * indexCount);
    var newURL = hostURL + "/" + randIndex;

    document.getElementById("result").innerHTML = "Index value: " + randIndex;

    $.ajax(newURL, {
        method: "GET",
        success: simpleResponse,
    });
}


function forcePatchFunc() {
    $.ajax(hostURL + "/" + document.getElementById("characterIndex").value, {
        method: "PATCH",
        processData: false,
        contentType: "application/json",
        success: simpleResponse,
        data: JSON.stringify({
            Name: document.getElementById("name").value,
            Character: document.getElementById("character").value,
            NumberOfTimes: document.getElementById("num-times").value
        })
    });
}


function forceSightFunc() {
    $.ajax(hostURL, {
        method: "GET",
        success: getRandIndexVal
    });
}


function forcePushFunc() {
    $.ajax(hostURL, {
        method: "POST",
        processData: false,
        contentType: "application/json",
        success: simpleResponse,
        data: JSON.stringify({
            Name: document.getElementById("name").value,
            Character: document.getElementById("character").value,
            NumberOfTimes: document.getElementById("num-times").value
        })
    });
}


function forceDeleteFunc() {
    $.ajax(hostURL, {
        method: "DELETE",
        success: simpleResponse
    })

    forceGetFunc();
}
2

function simpleResponse(data) {
    document.getElementById("result").innerHTML = JSON.stringify(data);
}

// add a extra paramter for content type 
function makeRequest(method, url, callback) {
    const xhttp = new XMLHttpRequest();

    xhttp.open(method, `https://localhost:44320/${url}`, true)

    xhttp.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            callback(xhttp.response)
        }
    };
    return xhttp
}
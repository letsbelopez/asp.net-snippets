if (!lopez.languages) {
    lopez.languages = { services: {} };
}

lopez.languages.services.insert = function (data, onSuccess, onError) {
    var url = "/api/languages";   
    var settings = {
        cache: false
        , contentType: "application/json; charset=UTF-8"
        , data: JSON.stringify(data)
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "POST"
    };
    $.ajax(url, settings);
}

lopez.languages.services.update = function (data, id, onSuccess, onError) {
    var url = "/api/languages/" + id;
    var settings = {
        cache: false
        , contentType: "application/json; charset=UTF-8"
        , data: JSON.stringify(data)
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "PUT"
    };
    $.ajax(url, settings);
}

lopez.languages.services.getOne = function (id, onSuccess, onError) {
    var url = "/api/languages/" + id;    
    var settings = {
        cache: false
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "GET"
    };
    $.ajax(url, settings);
}

lopez.languages.services.delete = function (id, onSuccess, onError) {
    var url = "/api/languages/" + id;    
    var settings = {
        cache: false
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "DELETE"
    };
    $.ajax(url, settings);
}

lopez.languages.services.getAll = function (onSuccess, onError) {    
    var url = "/api/languages";
    var settings = {
        cache: false
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "GET"
    };
    $.ajax(url, settings);
}

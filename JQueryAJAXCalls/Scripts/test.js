
$(function () {

    function FillDivSingleSoldier(soldier) {

        var displayHTML = 'Name: ' + soldier.Name + ' Rank: ' + soldier.Rank + ' Serial Num: ' + soldier.SerialNumber;
        console.log(displayHTML);
        $('#targetDiv').text(displayHTML);
    };

    function FillDivSoldiers(soldier) {
        var displayHTML = '';

        $.each(soldier, function (index, item) {
            console.log(item.Name);
            displayHTML += 'Name: ' + item.Name + ' Rank: ' + item.Rank + ' Serial Num: ' + item.SerialNumber;
        });

        $('#targetDiv').text(displayHTML);
    };

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // .Ajax() here
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    $('#btnAjaxCallxxx').on("click", function () {

        var configmap = {
            url: "api/APICaller/1",
            type: "GET",
        };
        $.ajax(configmap)
            .done(function (data) {
                FillDivSingleSoldier(data);
            })
            .fail(function () {
                alert('failure occured');
            })
            .always(function () {
                //alert('always doing this');
            });
    });

    $('#btnAjaxAllSoldiersCall').on("click", function () {

        var configmap = {
            url: "api/APICaller/",
            type: "GET",
        };
        $.ajax(configmap)
            .done(function (data) {
                FillDivSoldiers(data);
            })
            .fail(function () {
                alert('failure occured');
            })
            .always(function () {
                //alert('always doing this');
            });
    });
    
    $('#btnAjaxPostCall').on("click", function () {

        var data = {
            Rank: "general",
            Name: "napolean",
            SerialNumber: "1122-1155"
        };

        var configmap = {
            url: "api/APICaller/",
            type: "POST",
            data: data
        };
        $.ajax(configmap)
            .done(function (callbackData) {
                $('#targetDiv').text(JSON.stringify(callbackData, null, 4)); // I can pass data back in the Ok() return
            })
            .fail(function (object) {
                $('#targetDiv').text(JSON.stringify(object, null,4)); // <-- display Bad Request object if not success as a json string
            })
            .always(function (object) {
                //alert('always doing this hre');
            });
    });
    

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // <element>.Load(url, [data], [complete])
    // (this is a down and dirty call meant to be used to target the target element directly)
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // a complete callback is optional and fires upon completion. It's not exactly the same as the global .done callback
    // but performs the same function.
    // the response data needs to make sense for what's being done in the ui. e.g. it doesn't make sense
    // to target a div directly with a list of objects (that will most likely come over as json). In such a case
    // the Ajax call would be used. Use this to perhaps load a single string or id
    $('#btnLoadCall').on("click", function () {
        $('#targetDiv').load('api/APICaller/1', function () {
            //do stuff here on success is needed
            console.log('load completion fired');
        });

    });

    $('#btnLoadAllSoldiersCall').on("click", function () {
        $('#targetDiv').load('api/APICaller/', function () {
            //do stuff here on success is needed
            console.log('load completion fired');
        });
    });

    $('#btnLoadRankCall').on("click", function () {
        $('#targetRankDiv').load('api/APICaller/1/rank/', function () {
            //do stuff here on success is needed
            console.log('load completion fired');
        });
    });

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // .Get(url,[data], [success], [dataType]) 
    // - similar to using th Ajax call load except it has access to both the success handler as well as the global 
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // callback methods
    // and you're not targeting an element directly. You process the return data like you would using the .Ajax call
    //$('#btnGetCall').on("click", function () {
    //    $.get('api/APICaller/1', function (data) {
    //        //do stuff here on success is needed
    //        FillDivSingleSoldier(data);
    //    });
    //});

    // just to show this works also leveraging the .done() and .fail() callback
    $('#btnGetCall').on("click", function () {
        $.get('api/APICaller/1')
          .done(function (data) {
            FillDivSingleSoldier(data);
        }).fail(function () {
            alert('got here on failure');
        }).always(function () {
            //alert('always do this');
        })
    });

    $('#btnGetAllSoldiersCall').on("click", function () {
        $.get('api/APICaller/', function (data) {
            //do stuff here on success is needed
            FillDivSoldiers(data);
        });
    });

    $('#btnGetRankCall').on("click", function () {
        $.get('api/APICaller/1/rank/', function (data) {
            //do stuff here on success is needed
            $('#targetRankDiv').text(data);
        });
    });

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // .Post(url, [data], [success], [dataType])
    // it's a shorthand call like .Load() with an optional complete callback function 
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    $('#btnPostCall').on("click", function () {

        var data = {
            Rank:"general",
            Name:"napolean",
            SerialNumber:"1122-1155"
        };

        $.post("api/APICaller/", data, function (data) {
            alert('post completed Ok'); // <--- the success will fire when a 200 is passed back. 
        });

    });
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // .getJSON(url, [data], [success])
    // it's a shorthand call like .Load() with an optional complete callback function 
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    $('#btngetJSONCall').on("click", function () {

        $.getJSON("api/APICaller/1/soldierJSON", function (data) {
            var jsonObj = JSON.parse(data); // convert json string to object for the FillDivSingleSoldier function
            FillDivSingleSoldier(jsonObj);
        });

    });

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // .Ajax - to download files from controller actions
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //, btnAjaxGetWord, btnAjaxGetExcel

    $('#btnAjaxGetText').on("click",function(){
        var ajaxmap = {
            url: "/home/ReturnFilePathResultText",
            type: "GET",
            dataType:"text"
        };
        $.ajax(ajaxmap).complete(function(data){
            //$('#targetDiv').text(data); // the download seems to work but I don't know how to target a section of the form with the contents of the result (doing .text(data) doesn't work)
        }).fail(function () {
            alert('fail on file download');
        });
    
    });

});

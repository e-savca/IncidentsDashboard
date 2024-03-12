var mainContent;
var titleContent;

$(function () {
    mainContent = $("#MainContent"); /// render partial views.  
    titleContent = $("title"); // render titles.  
});

function showLoadingIndicator() {
    mainContent.html(`
    <div id="loading" style="
        display: flex;
        justify-content: center;
        align-items: center;
        height: 70vh;
    ">
        <div style="
            border: 16px solid #f3f3f3;
            border-top: 16px solid #3498db;
            border-radius: 50%;
            width: 120px;
            height: 120px;
            animation: spin 2s linear infinite;
        "></div>
    </div>
    <style>
        @keyframes spin {
            0% { transform: rotate(0deg); }
            100% { transform: rotate(360deg); }
        }
    </style>
    `);
}

var routingApp = $.sammy("#MainContent", function () {
    this.get("#Dashboard", function (context) {
        titleContent.html("Dashboard");

        // Show loading indicator
        showLoadingIndicator();

        $.get("/Dashboard/Index", function (data) {
            context.$element().html(data);
        });
    });

    this.get("#User", function (context) {
        titleContent.html("Admin Panel");

        // Show loading indicator
        showLoadingIndicator();

        $.get("/User/Index", function (data) {
            // Hide loading indicator and show the data
            mainContent.html(data);
        });
    });


    //this.get("#/Student/Add", function (context) {
    //    titleContent.html("Add Student");
    //    //$("#BigLoader").modal('show'); // If you want to show loader  
    //    $.get("/Student/Add", function (data) {
    //        //$("#BigLoader").modal('hide');  
    //        context.$element().html(data);
    //    });
    //});

    //this.get("#/Student/Edit", function (context) {
    //    titleContent.html("Edit Student");
    //    $.get("/Student/Edit", {
    //        studentID: context.params.id // pass student id  
    //    }, function (data) {
    //        context.$element().html(data);
    //    });
    //});

});

$(function () {
    routingApp.run("#Dashboard"); // default routing page.  
});

function IfLinkNotExist(type, path) {
    if (!(type != null && path != null))
        return false;

    var isExist = true;

    if (type.toLowerCase() == "get") {
        if (routingApp.routes.get != undefined) {
            $.map(routingApp.routes.get, function (item) {
                if (item.path.toString().replace("/#", "#").replace(/\\/g, '').replace("$/", "").indexOf(path) >= 0) {
                    isExist = false;
                }
            });
        }
    } else if (type.toLowerCase() == "post") {
        if (routingApp.routes.post != undefined) {
            $.map(routingApp.routes.post, function (item) {
                if (item.path.toString().replace("/#", "#").replace(/\\/g, '').replace("$/", "").indexOf(path) >= 0) {
                    isExist = false;
                }
            });
        }
    }
    return isExist;
}  

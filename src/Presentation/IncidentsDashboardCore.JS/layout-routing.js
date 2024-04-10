import { LoadModalForm } from '/IDCore.JS/Common/LoadModalForm';
var mainContent;
var titleContent;
var lastHash;
var adminHash;
var dashboardHash;


$(function () {
    mainContent = $("#MainContent"); /// render partial views.  
    titleContent = $("title"); // render titles.  
    adminHash = '#Admin';
    dashboardHash = '#Dashboard';
});


var routingApp = $.sammy("#MainContent", function () {
    this.get("#Dashboard", function (context) {
        titleContent.html("Dashboard");
        $.get("/Dashboard/Index", function (data) {
            context.$element().html(data);
        });

        lastHash = window.location.hash;
    });

    this.get("#Dashboard/Add", function (context) {
        titleContent.html("Add Incident");
        $.get("/Dashboard/GetCreateAsync", function (data) {
            context.$element().html(data);
        });
    });

    this.get("#Dashboard/Edit/:id", function (context) {
        titleContent.html("Edit Incident");
        showLoadingIndicator();
        $.get("/Dashboard/GetUpdateAsync/" + context.params.id, function (data) {

            context.$element().html(data);

        });
    });

    this.get("#Dashboard/Details/:id", function (context) {
        titleContent.html("Incident Details");
        $.get("/Dashboard/GetDetailsAsync/" + context.params.id, function (data) {

            context.$element().html(data);

        });
    });

    //this.get("#Dashboard/Delete/:id", function (context) {
    //    titleContent.html("Incident Details");
    //    $.get("/Dashboard/DeleteAsync/" + context.params.id, function (data) {

    //        context.$element().html(data);

    //    });
    //});

    this.get("#Dashboard/Upload", function (context) {
        titleContent.html("Upload File");
        showLoadingIndicator();
        $.get("/Dashboard/GetUploadFile/", function (data) {

            context.$element().html(data);

        });
    });

    this.get("#Dashboard/Export", function (context) {
        titleContent.html("Export File");
        showLoadingIndicator();
        $.get("/Dashboard/GetExportIncidents/", function (data) {

            context.$element().html(data);

        });
    });


    this.get("#Admin", function (context) {
        titleContent.html("Admin Panel");

        showLoadingIndicator(); // Show loading indicator

        $.get("/Admin/Index", function (data) {
            context.$element().html(data);
        });

        lastHash = window.location.hash;
    });

    this.get("#Admin/Create", function (context) {
        
        if (lastHash != adminHash) {
            titleContent.html("Admin Panel");
            showLoadingIndicator(); // Show loading indicator
            $.get("/Admin/Index", function (data) {
                context.$element().html(data);
            });
        }
        LoadModalForm('/Admin/GetCreateAsync', 'New User', 'create');
        lastHash = window.location.hash;
    });

    this.get("#Admin/Edit/:id", function (context) {

        if (lastHash != adminHash) {
            titleContent.html("Admin Panel");
            showLoadingIndicator(); // Show loading indicator
            $.get("/Admin/Index", function (data) {
                context.$element().html(data);
            });
        }

        LoadModalForm('/Admin/GetUpdateAsync/' + context.params.id, 'Edit User', 'update');
        lastHash = window.location.hash;
    });

    this.get("#Admin/Details/:id", function (context) {

        if (lastHash != adminHash) {
            titleContent.html("Admin Panel");
            showLoadingIndicator(); // Show loading indicator
            $.get("/Admin/Index", function (data) {
                context.$element().html(data);
            });
        }
        LoadModalForm('/Admin/GetDetailsAsync/' + context.params.id, 'User Details');

        lastHash = window.location.hash;
    });

    this.get("#Admin/ModalClosed", function (context) {
        lastHash = adminHash;
    });

});

$(function () {
    routingApp.run("#Dashboard"); // default routing page. 
    lastHash = window.location.hash;
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
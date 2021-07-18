
setUser();

function setUser(e) {
    if (localStorage.getItem("LoginData") === null) {
        let countries = [$("#LoginUser").val()];
        localStorage.setItem("LoginData", JSON.stringify(countries));
    } else {
        $("#LoginUser").val(JSON.parse(localStorage.getItem("LoginData"))[0])

        //登入類型權限判斷

        //RD
        if (JSON.parse(localStorage.getItem("LoginData"))[0] === "8d5e5e67-6c1f-4379-bba2-ee0436253d85") {
            let TicketMenu = document.getElementById("TicketMenu");
            TicketMenu.style.display = "none";
            if (document.getElementById("ResolveButton") !== null) {
                let ResolveButton = document.getElementById("ResolveButton");
                ResolveButton.style.display = "";
            }
            if (document.getElementById("UpdateButton") !== null) {
                let ResolveButton = document.getElementById("UpdateButton");
                ResolveButton.style.display = "none";
            }
            
        }
        //QA
        if (JSON.parse(localStorage.getItem("LoginData"))[0] === "15b65d1f-b1a4-4b68-b562-f2dad9882007") {
            console.log('test');
            if (document.getElementById("ResolveButton") !== null) {
                let ResolveButton = document.getElementById("ResolveButton");
                ResolveButton.style.display = "";
            }
            let ResolveButtonReadOnly = document.getElementById("ResolveButtonReadOnly");
            ResolveButtonReadOnly.style.display = "";
            let UpdateButtonReadOnly = document.getElementById("UpdateButtonReadOnly");
            UpdateButtonReadOnly.style.display = "";
        }
        //ADMIN
        if (JSON.parse(localStorage.getItem("LoginData"))[0] === "cbea8e8f-8b9f-48b5-a7d3-40c9be502fd8") {
            let UserMenu = document.getElementById("UserMenu");
            UserMenu.style.display = "";
        }
    }

}
function changeUser(e) {
    let countries = [$("#LoginUser").val()];
    localStorage.setItem("LoginData", JSON.stringify(countries));
    location.reload();
}
function changeResolve(e) {
    $.ajax({
        url: "/api/changeResolve",
        type: "get",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        json: 'callback',
        data: { TicketKey: e },
        success: function (data) {
            if (data.result) {
                alert(data.msg);
                location.href = "/";
            } else {
                alert(data.msg);
            }
        },
        error: function () {
            alert("error");
            location.reload();
        }
    });
}

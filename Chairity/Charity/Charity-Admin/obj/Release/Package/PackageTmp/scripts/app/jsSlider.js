$(document).ready(function () {
    RefreshGrid();
    
});
function RefreshGrid() {
    BindGrid("TradingAccountList", "TradingAccountList", '/Trading/GetAccounts', true, true, true, true, true, "");
}


function OnGridDelete(e) {
    var data, GetDeleteStatus;
    var table = $('#GridTradingAccountList').DataTable();
    data = table.row(e.parentNode).data();
    if (confirm("Are you sure to proceed?")) {
        AjaxCall('/Trading/DeleteAccount', JSON.stringify({ "Id": data.Id }), GetDeleteStatus, null);
        RefreshGrid();
    }
}
function OnGridEdit(e) {

    var table = $('#GridTradingAccountList').DataTable();
    var data = table.row(e.parentNode).data();
    $("#HdnId").val(data.Id);
    $("#AccountNumber").val(data.AccountNumber);
    $("#StartingDate").val(parseJsonDateforRemarks(data.StartingDate));
    $("#Deposit").val(data.Deposit);
    $("#Withdrawal").val(data.Withdrawal);
    $("#Target").val(data.Target);
    $("#MaxDD").val(data.MaxDD);
    $("#Profit").val(data.Profit);
    $("#QQPercentage").val(data.QQPercentage);

    $("#ModelAd").modal("show");
}

function OnProfit(e) {
    var table = $('#GridTradingAccountList').DataTable();
    var data = table.row(e.parentNode).data();
    $("#labelTask").html("Profit");
    $("#btnAdd").html("+ Add Profit");
    $("#HdnType").val("Profit");
    $("#HdnTradingAccountId").val(data.Id);
    BindGrid("ProfitList", "ProfitList", '/Trading/GetProfit?Id=' + data.Id + "&Type=Profit", true, true, true, true, true, "");

    $("#ModelTask1").modal("show");
}

function OnQQ(e) {
    var table = $('#GridTradingAccountList').DataTable();
    var data = table.row(e.parentNode).data();
    $("#labelTask").html("QQ Percentage");
    $("#btnAdd").html("+ Add QQ");
    $("#HdnType").val("QQ");
    $("#HdnTradingAccountId").val(data.Id);
    BindGrid("ProfitList", "ProfitList", '/Trading/GetProfit?Id=' + data.Id + "&Type=QQ", true, true, true, true, true, "");

    $("#ModelTask1").modal("show");
}
function OnGridEdit1(e) {

    var table = $('#GridProfitList').DataTable();
    var data = table.row(e.parentNode).data();
    $("#HdnPId").val(data.Id);
    $("#AccountNumberP").val(data.AccountNumber);
    $("#MonthP").val(data.Month);
    $("#ProfitP").val(data.Profit);
    
    $("#ModelAdP").modal("show");
}

function OnGridDelete1(e) {
    var data, GetDeleteStatus;
    var table = $('#GridProfitList').DataTable();
    data = table.row(e.parentNode).data();
    if (confirm("Are you sure to proceed?")) {
        AjaxCall('/Trading/DeleteProfit', JSON.stringify({ "Id": data.Id }), GetDeleteStatus, null);
        BindGrid("ProfitList", "ProfitList", '/Trading/GetProfit?Id=' + data.Id + "&Type=" + $("#HdnType").val(), true, true, true, true, true, "");
    }
}
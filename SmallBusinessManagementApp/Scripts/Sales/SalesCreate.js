
$("#AddButton").click(function () {
    createRowForPurchase();

});


var index = 0;
function createRowForPurchase() {

    //Get Selected Item from UI
    var selectedItem = getSelectedItem();

    //Check Last Row Index
    var index = $("#SalesDetailsTable").children("tr").length;
    var sl = index;

    //For Model List<Property> Binding For MVC
    var indexTd = "<td style='display:none'><input type='hidden' id='Index" + index + "' name='PurchaseDetailses.Index' value='" + index + "' /> </td>";

    //For Serial No For UI
    var slTd = "<td id='Sl" + index + "'> " + (++sl) + " </td>";

    var ProductId = "<td> <input type='hidden' id='ProductId" + index + "'  name='SalesDetailses[" + index + "].ProductId' value='" + selectedItem.ProductId + "' /> " + selectedItem.ProductName + " </td>";
    //var AvaiableQuantity = "<td> <input type='hidden' id='AvaiableQuantity" + index + "'  name='SalesDetailses[" + index + "].ProductId' value='" + selectedItem.ProductId + "' /> " + selectedItem.ProductName + " </td>";
    var SalesDetailsQuantity = "<td> <input type='hidden' id='SalesDetails_Quantity" + index + "'  name='SalesDetailses[" + index + "].Quantity' value='" + selectedItem.Quantity + "' /> " + selectedItem.Quantity + " </td>";
    var SalesDetailsUnitPrice = "<td> <input type='hidden' id='SalesDetails_UnitPrice" + index + "'  name='SalesDetailses[" + index + "].UnitPrice' value='" + selectedItem.UnitPrice + "' /> " + selectedItem.UnitPrice + " </td>";
    var SalesDetailsTotalPrice = "<td> <input type='hidden' id='SalesDetails_TotalPrice" + index + "'  name='SalesDetailses[" + index + "].TotalPrice' value='" + selectedItem.TotalPrice + "' /> " + selectedItem.TotalPrice + " </td>";


    var newRow = "<tr>" + indexTd + slTd + ProductId + SalesDetailsQuantity + SalesDetailsUnitPrice + SalesDetailsTotalPrice;
    $("#SalesDetailsTable").append(newRow);

    $("#ProductId").val("");
    $("#AvaiableQuantity").val("");
    $("#SalesDetails_Quantity").val("");
    $("#SalesDetails_UnitPrice").val("");
    $("#SalesDetails_TotalPrice").val("");
    


}


function getSelectedItem() {
    var productId = $("#ProductId").val();
    var productName = $("#ProductId").find('option:selected').text();
    var availableQuantity = $("AvaiableQuantity").val();
    var SalesDetails_Quantity = $("#SalesDetails_Quantity").val();
    var SalesDetails_UnitPrice = $("#SalesDetails_UnitPrice").val();
    var SalesDetails_TotalPrice = $("#SalesDetails_TotalPrice").val();
    



    var item = {
        "ProductId": productId,
        "ProductName": productName,   
        "Quantity": SalesDetails_Quantity,
        "UnitPrice": SalesDetails_UnitPrice,
        "TotalPrice": SalesDetails_TotalPrice
    };
    return item;
}

function calculatePrice() {
    var total = 0.0, mrp = 0.0, quantity = 0.0, unitPrice = 0.0;
    quantity = parseFloat($("#SalesDetails_Quantity").val());
    unitPrice = parseFloat($("#SalesDetails_UnitPrice").val());
    if (quantity != "" && unitPrice != "") {
        total = quantity * unitPrice;
        $("#SalesDetails_TotalPrice").val(total);

        
    }
    if (($("#SalesDetails_Quantity").val()) == "" || ($("#SalesDetails_UnitPrice").val()) == "") {

        $("#PurchaseDetails_TotalPrice").val(0);
    }

}


$("#AddButton").click(function () {
    createRowForPurchase();

});


var index = 0;
function createRowForPurchase() {

    //Get Selected Item from UI
    var selectedItem = getSelectedItem();

    //Check Last Row Index
    var index = $("#PurchaseDetailsTable").children("tr").length;
    var sl = index;

    //For Model List<Property> Binding For MVC
    var indexTd = "<td style='display:none'><input type='hidden' id='Index" + index + "' name='PurchaseDetailses.Index' value='" + index + "' /> </td>";

    //For Serial No For UI
    var slTd = "<td id='Sl" + index + "'> " + (++sl) + " </td>";

    var ProductId = "<td> <input type='hidden' id='ProductId" + index + "'  name='PurchaseDetailses[" + index + "].ProductId' value='" + selectedItem.ProductId + "' /> " + selectedItem.ProductName + " </td>";
    var purchaseDetailsCode = "<td> <input type='hidden' id='PurchaseDetails_Code" + index + "'  name='PurchaseDetailses[" + index + "].Code' value='" + selectedItem.Code + "' /> " + selectedItem.Code + " </td>";
    var purchaseDetailsManufacturedDate = "<td> <input type='hidden' id='PurchaseDetails_ManufacturedDate" + index + "'  name='PurchaseDetailses[" + index + "].ManufacturedDate' value='" + selectedItem.ManufacturedDate + "' /> " + selectedItem.ManufacturedDate + " </td>";
    var purchaseDetailsExpiredDate = "<td> <input type='hidden' id='PurchaseDetails_ExpiredDate" + index + "'  name='PurchaseDetailses[" + index + "].ExpiredDate' value='" + selectedItem.ExpiredDate + "' /> " + selectedItem.ExpiredDate + " </td>";
    var purchaseDetailsPurchaseQuantity = "<td> <input type='hidden' id='PurchaseDetails_PurchaseQuantity" + index + "'  name='PurchaseDetailses[" + index + "].PurchaseQuantity' value='" + selectedItem.PurchaseQuantity + "' /> " + selectedItem.PurchaseQuantity + " </td>";
    var purchaseDetailsUnitPrice = "<td> <input type='hidden' id='PurchaseDetails_UnitPrice" + index + "'  name='PurchaseDetailses[" + index + "].UnitPrice' value='" + selectedItem.UnitPrice + "' /> " + selectedItem.UnitPrice + " </td>";
    var purchaseDetailsTotalPrice = "<td> <input type='hidden' id='PurchaseDetails_TotalPrice" + index + "'  name='PurchaseDetailses[" + index + "].TotalPrice' value='" + selectedItem.TotalPrice + "' /> " + selectedItem.TotalPrice + " </td>";
    var purchaseDetailsPreviousMRP = "<td> <input type='hidden' id='PurchaseDetails_PreviousMRP" + index + "'  name='PurchaseDetailses[" + index + "].PreviousMRP' value='" + selectedItem.PreviousMRP + "' /> " + selectedItem.PreviousMRP + " </td>";
    var purchaseDetailsNewMRP = "<td> <input type='hidden' id='PurchaseDetails_NewMRP" + index + "'  name='PurchaseDetailses[" + index + "].NewMRP' value='" + selectedItem.NewMRP + "' /> " + selectedItem.NewMRP + " </td>";

    var newRow = "<tr>" + indexTd + slTd + ProductId + purchaseDetailsCode + purchaseDetailsManufacturedDate+purchaseDetailsExpiredDate+purchaseDetailsPurchaseQuantity+purchaseDetailsUnitPrice+purchaseDetailsTotalPrice+purchaseDetailsPreviousMRP+purchaseDetailsNewMRP+" </tr>";

    $("#PurchaseDetailsTable").append(newRow);

    $("#ProductId").val("");
    $("#PurchaseDetails_Code").val("");
    $("#PurchaseDetails_ManufacturedDate").val("");
    $("#PurchaseDetails_ExpiredDate").val("");
    $("#PurchaseDetails_PurchaseQuantity").val("");
    $("#PurchaseDetails_UnitPrice").val("");
    $("#PurchaseDetails_TotalPrice").val("");
    $("#PurchaseDetails_PreviousMRP").val("");
    $("#PurchaseDetails_NewMRP").val("");
    

}


function getSelectedItem() {
    var productId = $("#ProductId").val();
    var productName = $("#ProductId").find('option:selected').text();
    var purchaseDetailsCode = $("#PurchaseDetails_Code").val();
    var purchaseDetailsManufacturedDate = $("#PurchaseDetails_ManufacturedDate").val();
    var purchaseDetailsExpiredDate = $("#PurchaseDetails_ExpiredDate").val();
    var purchaseDetailsPurchaseQuantity = $("#PurchaseDetails_PurchaseQuantity").val();
    var purchaseDetailsUnitPrice = $("#PurchaseDetails_UnitPrice").val();
    var purchaseDetailsTotalPrice = $("#PurchaseDetails_TotalPrice").val();
    var purchaseDetailsPreviousMRP = $("#PurchaseDetails_PreviousMRP").val();
    var purchaseDetailsNewMRP = $("#PurchaseDetails_NewMRP").val();
    
    

    var item = {
        "ProductId": productId,
        "ProductName": productName,
        "Code": purchaseDetailsCode,
        "ManufacturedDate": purchaseDetailsManufacturedDate,
        "ExpiredDate": purchaseDetailsExpiredDate,
        "PurchaseQuantity": purchaseDetailsPurchaseQuantity,
        "UnitPrice": purchaseDetailsUnitPrice,
        "TotalPrice": purchaseDetailsTotalPrice,
        "PreviousMRP": purchaseDetailsPreviousMRP,
        "NewMRP": purchaseDetailsNewMRP
    };
    return item;
}

function calculatePrice() {
    var total = 0.0, mrp = 0.0, quantity = 0.0, unitPrice=0.0;
    quantity = parseFloat($("#PurchaseDetails_PurchaseQuantity").val());
    unitPrice = parseFloat($("#PurchaseDetails_UnitPrice").val());
    if (quantity != "" && unitPrice != "") {
        total = quantity * unitPrice;
        $("#PurchaseDetails_TotalPrice").val(total);

        mrp = parseFloat((unitPrice * 125) / 100);
        $("#PurchaseDetails_NewMRP").val(mrp);
    }
    if (($("#PurchaseDetails_PurchaseQuantity").val())=="" || ($("#PurchaseDetails_UnitPrice").val())=="") {
        
        $("#PurchaseDetails_TotalPrice").val(0);
        $("#PurchaseDetails_NewMRP").val(0);
    }

}

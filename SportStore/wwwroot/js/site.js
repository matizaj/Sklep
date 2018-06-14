function onChangeSummaryCart() {
    
    var url = "/Cart/CartSummaryPartial?returnUrl=" + $("#RequestPathAndQuery").val();
    $("#CartSummary").load(url);
}

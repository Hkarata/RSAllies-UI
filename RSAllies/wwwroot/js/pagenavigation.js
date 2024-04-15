$(document).ready(function(){
    $(".ClickableDiv").click(function(){
        let value1 = encodeURIComponent(btoa($(this).data("value1").trim()));
        let value2 = $(this).data("value2").trim();
        let value3 = $(this).data("value3").trim();
        let combinedValue = encodeURIComponent(btoa(value2 + "|" + value3));
        window.location.href = "/Venue?value1=" + value1 + "&combined-value=" + combinedValue;
    });
});


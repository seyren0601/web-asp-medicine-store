function OnClick_Them() {
    var cart_amount = document.getElementById("cart_amount");
    if (cart_amount != null) { // Already logged in
        var current_count = parseInt(cart_amount.innerHTML);
        cart_amount.innerHTML = current_count + 1;
    }
    else {
        window.location.href = "/Identity/Account/Login"
    }
}
window.enablePayment = (clickedId, otherId) => {
    document.getElementById(otherId).disabled = true;
    document.getElementById(clickedId).disabled = false;
}

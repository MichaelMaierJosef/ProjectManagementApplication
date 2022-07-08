//Popup für Logout (Sind Sie sich sicher?)
function openWin() {
    if (confirm('Are you sure you want to logout?')) {
        // Save it!
        /*$.ajax({
            type: "POST",
            method: "POST",
            url: "../Identity/Account/Logout",
            headers: { "cache-control": "no-cache" },
            contentType: 'application/json',
            success: function (result) {

            },
            failure: function (error) {
            }
        });*/
        const form = document.getElementById('logiout');
        form.submit();
    } else {
        // Do nothing!
    }
}
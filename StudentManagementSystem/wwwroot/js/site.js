// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



// This function for disability check box
document.getElementById('disabilityCheck').onchange = function () {
    document.getElementById('disabilityText').disabled = !this.checked;
    document.getElementById('disabilityText').focus();
};

document.getElementById('medicationCheck').onchange = function () {
    document.getElementById('medicationText').disabled = !this.checked;
    document.getElementById('medicationText').focus();
};

document.getElementById('policeCheck').onchange = function () {
    document.getElementById('policeText').disabled = !this.checked;
    document.getElementById('policeText').focus();
};

//function Validator() {
//    //  ...bla bla bla... the checks
//    var validEmail = 'false';
//    toastr.error('Please Enter the email');
//    if (document.getElementById('email').value!='') {
//        document.getElementById('theFormID').submit();
//        return (true);
//    }    
//    else {
//        return (false);
//    }
//}

function IsFirstNameEmpty() {
    if (document.getElementById('TxtFName').value == "") {
        return 'First Name should not be empty';
    } else {
        return "";
    }
}

function IsFirstNameInValid() {
    if (document.getElementById('TxtFName').value.indexOf("@") != -1) {
        return 'First Name should not contain@';
    } else {
        return "";
    }
}

function IsLastNameInValid() {
    if (document.getElementById('TxtLName').value.length >= 5) {
        return 'Last Name should not contain more than 5 character';
    } else { return "";}
}

function IsValid() {
    var firstNameEmptyMessage = this.IsFirstNameEmpty();
    var firstNameInValidMessage = this.IsFirstNameInValid();
    var lastNameInValidMessage = this.IsLastNameInValid();

    var finalErrorMessage = "Errors:";
    if (firstNameEmptyMessage != "")
        finalErrorMessage += "\n" + firstNameEmptyMessage;
    if (firstNameInValidMessage != "")
        finalErrorMessage += "\n" + firstNameInValidMessage;
    if (lastNameInValidMessage != "")
        finalErrorMessage += "\n" + lastNameInValidMessage;
    if (finalErrorMessage != "Errors:") {
        alert(finalErrorMessage);
        return false;
    } else {
        return true;
    }
}
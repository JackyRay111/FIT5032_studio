function VerifyRating() {
    var rating = $("#fnrating").val()
        if (rating == "0") {
        alert("Please select rating.");
            return false;
        }
        else {
            return true;
        }
}

function RateOut(rating) {
    for (var i = 1; i <= rating; i++) {
        $("#span" + i).attr('class', ' glyphicon glyphicon-star-empty');
    }
}

    function RateOver(rating) {
        for (var i = 1; i <= rating ; i++) {
            $("#span" + i).attr('class', 'glyphicon glyphicon-star');
        }
    }

    

function RateClick(rating) {
    $("#fnrating").val(rating)
    for (var i = 1; i <= rating; i++) {
        $("#span" + i).attr('class', 'glyphicon glyphicon-star');
    }

    for (var i = rating + 1; i <= 5; i++) {
        $("#span" + i).attr('class', 'glyphicon glyphicon-star-empty');
    }

}

function RateSelected() {
    var rating = $("#fnrating").val()
        for(var i = 1; i <= rating; i++) {
            $("#span" + i).attr('class', 'glyphicon glyphicon-star');
        }
    }

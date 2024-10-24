

function alertSuccess() {
    $('.alert-success').css('display', 'block');
    $('.pace-demo').css('display', 'block');

    setTimeout(function () {
        $('.alert-success').css('display', 'none');

    }, 1000);
}
function AddNewContent() {
	$.ajax({
		url: "/Content/AddNewContent/",
		type: "POST",
		success: function (data) {
			$('.modal-title').html('Add New Product');
			$('.modal-body').html(data);
			$('#modal_theme_success').modal();
		}
	})
}
function AddContent(event) {
	
	var formData = {
		cTitle: $('#contentTitle').val(),
		cType: $('#contenttypeSelect').val()
	}
	$.ajax({
		url: "/Content/CreateContent/",
		method: "POST",
		data: formData,
		success: function (result) {
			
			console.log(result);
			if (result['statusCode'] === "200") {
				setTimeout(function () {
					$('.alert-success').css('display', 'block');
					setTimeout(function () {
						$('.alert-success').css('display', 'none');

					}, 3000)
				}, 1000)
				var iid = result['itemId'];
				window.location.href = "/Content/EditContent/" + iid;
			}
			//$('#createContent').html('Loading');

		}
	});


}
// customscript.js

var Utility = {
	getFormattedDate: function(createdOn) {
		
		var now = new Date();
		var createdDate = new Date(createdOn);
		var diffMs = now - createdDate; // Difference in milliseconds
		var diffMins = Math.floor(diffMs / 60000); // Convert milliseconds to minutes

		if (diffMins < 5) {
			return "Just Now";
		} else if (diffMins < 60) {
			return diffMins + " minutes ago";
		}

		var diffHours = Math.floor(diffMins / 60); // Convert minutes to hours
		if (diffHours < 24) {
			return diffHours + " hours ago";
		}

		var diffDays = Math.floor(diffHours / 24); // Convert hours to days
		if (diffDays < 7) {
			return diffDays + " days ago";
		}

		// Format date as "MMM dd, yyyy"
		var options = { year: 'numeric', month: 'short', day: '2-digit' };
		return createdDate.toLocaleDateString('en-US', options);
	}
};
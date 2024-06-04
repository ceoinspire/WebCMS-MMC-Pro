

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
	event.preventDefault();
	debugger;
	var formData = {
		cTitle: $('#contentTitle').val(),
		cType: $('#contenttypeSelect').val()
	}
	$.ajax({
		url: "/Content/CreateContent/",
		method: "POST",
		data: formData,
		success: function (result) {
			debugger;
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


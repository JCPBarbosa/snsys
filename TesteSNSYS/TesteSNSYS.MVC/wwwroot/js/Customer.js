$(document).ready(async function () {
    if (localStorage.getItem('token') == null || localStorage.getItem('token') === undefined) {
        window.location.href = '/login'
    }

    if (pathname.includes("CUSTOMER/EDIT")) {
        await GetCustomerById(getParameter(window.location.href));

    }
});

async function GetCustomerById(id) {

    var response = await getDataWithToken(`https://localhost:7087/api/Customer/${id}`).then(result => { return result });

    if (response.success) {

        $("#Name").val(response.data.name);
        $("#Email").val(response.data.email);
        $("#Phone").val(response.data.phone);
        $("#Id").val(response.data.id);

    } else {
        Swal.fire({
            icon: 'warning',
            title: 'Atenção',
            text: 'Falha ao buscar',
            confirmButtonColor: '#0d6efd'
        });
    }
}

$("#btnReturn").click(function () {
    window.location.href = '/home'
})

$("#btnCreate").click(function () {
    window.location.href = '/customer/create'
})

$("#btnUpdate").click(async function () {

    $("#Name").removeClass("text-danger");
    $("#Email").removeClass("text-danger");
    $("#Phone").removeClass("text-danger");

    var name = $("#Name").val();
    var email = $("#Email").val();
    var phone = $("#Phone").val();
    var id = $("#Id").val();

    if (ValidForm()) {

        var customer = {
            id: parseInt(id),
            name: name,
            email: email,
            phone: phone,
            userId: localStorage.getItem('userId')
        }

        if (customer.id === 0) {

            var response = await postDataWithToken("https://localhost:7087/api/Customer", customer).then(result => { return result });

            if (response.success) {

                Swal.fire({
                    title: 'Sucesso',
                    text: "Você será redirecionado!",
                    icon: 'success',
                    confirmButtonColor: '#0d6efd',
                    confirmButtonText: 'OK'
                }).then((result) => {
                    window.location.href = '/home'
                });

            } else {

                if (response.message == 'Forbidden') {
                    Swal.fire({
                        icon: 'warning',
                        title: 'Atenção',
                        text: response.data,
                        confirmButtonColor: '#0d6efd'
                    });
                }
                else {
                    Swal.fire({
                        icon: 'warning',
                        title: 'Atenção',
                        text: 'Falha ao cadastrar',
                        confirmButtonColor: '#0d6efd'
                    });
                }
              
            }
        } else {
            var response = await putDataWithToken("https://localhost:7087/api/Customer", customer).then(result => { return result });

            if (response.success) {

                Swal.fire({
                    title: 'Sucesso',
                    text: "Você será redirecionado!",
                    icon: 'success',
                    confirmButtonColor: '#0d6efd',
                    confirmButtonText: 'OK'
                }).then((result) => {
                    window.location.href = '/home'
                });

            } else {
                if (response.message == 'Forbidden') {
                    Swal.fire({
                        icon: 'warning',
                        title: 'Atenção',
                        text: response.data,
                        confirmButtonColor: '#0d6efd'
                    });
                }
                else {
                    Swal.fire({
                        icon: 'warning',
                        title: 'Atenção',
                        text: 'Falha ao cadastrar',
                        confirmButtonColor: '#0d6efd'
                    });
                }
            }
        }


    }
    else {

        Swal.fire({
            icon: 'warning',
            title: 'Atenção',
            text: 'Todos os campos são obrigatórios',
            confirmButtonColor: '#0d6efd'
        });
    }

});

async function ValidForm() {
    let valid = true;
    const fields = [
        { label: "Name", input: "#Name" },
        { label: "Email", input: "#Email" },
        { label: "Phone", input: "#Phone" }
    ];

    fields.forEach(({ label, input }) => {

        const inputElement = $(input);
        const labelElement = $(`#lbl${label}`);

        if (inputElement.val() === "") {
            labelElement.addClass("text-danger");
            valid = false;
        } else {
            labelElement.removeClass("text-danger");
        }
    });

    return valid;
}

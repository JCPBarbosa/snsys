const pathname = window.location.pathname.toUpperCase();

$(document).ready(async function () {
    if (localStorage.getItem('token') == null || localStorage.getItem('token') === undefined) {
        window.location.href = '/login'
    }

    if (pathname.includes("HOME")) {
        await GetGustomers().then(result => { return result });
    }
});

$("#btnSignout").click(function () {
    localStorage.removeItem('token');
    window.location.href = '/login';
})

async function GetGustomers() {

    var response = await getDataWithToken('https://localhost:7087/api/Customer').then(result => { return result });

    if (response.success) {

        for (var i = 0; i < response.data.length; i++) {
            var html = `<tr>
                <th scope="row">${response.data[i].id}</th>
                <td>${response.data[i].name}</td>
                <td>${response.data[i].email}</td>
                <td>${response.data[i].phone}</td>
                <td><a class="btn btn-primary" href="${window.location.origin + '/Customer/Edit/' + response.data[i].id}" role="button">Edit</a></td>
                <td><a class="btn btn-danger" href="#" onclick="Remove('${response.data[i].id}')" role="button">Remove</a></td>
            </tr>`;

            $("#tableHome tbody").append(html);
        }

    } else {
        var html = `<tr>
                <td scope="row"></td>
                <td scope="row">Sem Registros</td>
                <td scope="row"></td>
                <td scope="row"></td>                
            </tr>`;

        $("#tableHome tbody").append(html);
    }
}

async function Remove(id) {

    Swal.fire({
        title: 'Atenção!',
        text: "Deseja remover este registro?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#0d6efd',
        cancelButtonColor: '#dc3545',
        confirmButtonText: 'Sim',
        cancelButtonText: 'Não',
    }).then(async (result) => {
        if (result.isConfirmed) {

            var response = await deleteDataWithToken(`https://localhost:7087/api/Customer/${id}`).then(result => { return result });

            if (response.success) {

                Swal.fire({
                    title: 'Sucesso!',
                    text: "Registros excluido com sucesso!",
                    icon: 'success',
                    confirmButtonColor: '#0d6efd',
                    confirmButtonText: 'OK'
                }).then(async (result) => {
                    $('#tableHome tbody').empty();
                    await GetGustomers().then(result => { return result });
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
                        title: 'Atenção!',
                        text: 'Falha ao excluir o registro!',
                        confirmButtonColor: '#0d6efd'
                    });
                }
            }
        }
    })
}

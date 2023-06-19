$(document).ready(async function () {
    localStorage.removeItem('token')
});


$("#btnSignUp").click(async function () {

    var user = $("#User").val();
    var password = $("#Password").val();

    if (user === '' || password === '') {
        Swal.fire({
            icon: 'warning',
            title: 'Atenção',
            text: 'Todos os campos são obrigatórios',
            confirmButtonColor: '#0d6efd'
        });
    }
    else {
        var login = {
            user: user,
            password: password
        }

        var response = await postDataWithToken("https://localhost:7087/api/Login", login).then(result => { return result });

        if (response.success) {
            localStorage.setItem('token', response.data.token);
            localStorage.setItem('userId', response.data.userId);
            window.location.href = '/home';
        } else {
            Swal.fire({
                icon: 'warning',
                title: 'Atenção',
                text: response.message,
                confirmButtonColor: '#0d6efd'
            });
        }
    }
})
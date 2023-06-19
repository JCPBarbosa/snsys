async function postDataWithToken(url, obj) {

    try {

        const options = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${localStorage.getItem('token')}`
            },
            body: JSON.stringify(obj)
        };

        const response = await fetch(url, options);

        if (response.status === 403) {
            return {
                data: 'Usuário sem permissão',
                message: "Forbidden",
                success: false
            };
        }

        return await response.json();

        // Faça algo com o retorno da API aqui
    } catch (error) {
        return {
            data: null,
            message: "Falha",
            success: false
        };
    }
}

async function getDataWithToken(url) {

    try {

        const options = {
            headers: {
                'Authorization': `Bearer ${localStorage.getItem('token')}`
            }
        };

        const response = await fetch(url, options);
        return await response.json();

        // Faça algo com o retorno da API aqui
    } catch (error) {
        return {
            data: null,
            message: "Falha",
            success: false
        };
    }
}

async function putDataWithToken(url, obj) {
    try {

        const options = {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${localStorage.getItem('token')}`
            },
            body: JSON.stringify(obj)
        };

        const response = await fetch(url, options);

        if (response.status === 403) {
            return {
                data: 'Usuário sem permissão',
                message: "Forbidden",
                success: false
            };
        }

        return await response.json();

        // Faça algo com o retorno da API aqui
    } catch (error) {
        return {
            data: null,
            message: "Falha",
            success: false
        };
    }
}

async function deleteDataWithToken(url) {

    try {

        const options = {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${localStorage.getItem('token')}`
            }
        };

        const response = await fetch(url, options);

        if (response.status === 403) {
            return {
                data: 'Usuário sem permissão',
                message: "Forbidden",
                success: false
            };
        }

        return await response.json();

        // Faça algo com o retorno da API aqui
    } catch (error) {
        return {
            data: null,
            message: "Falha",
            success: false
        };
    }

}

function getParameter(url) {
    const urlObj = new URL(url);
    const pathname = urlObj.pathname;
    const partes = pathname.split('/');
    const parametro = partes[partes.length - 1];
    return parametro;
}

function formatPhone(e) {
    $(e).mask('(00) 00000-0009');
}
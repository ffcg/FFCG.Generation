export class BadUserService {
    getToken() {
        var authority = "https://login.microsoftonline.com/tenantSpecificId"
        var credentials = {
            clientId: "9ee97847-78f0-45f1-a8b3-01ba6078718f",
            clientSecret: "b504ea42-5a4d-436e-abc6-84eaab640754"
        }

        var data = {
            authority: authority,
            credentials: credentials
        }

        return fetch('http://localhost:8000/gettoken', {
                method: 'POST',
                headers: {'Content-Type': 'application/json'},
                body: JSON.stringify(data)
            }).then(res => res.json())
            .then(json => 
                json.token                 
            ).catch(error =>
                 console.log(error.response)
            )       
    }

    getUser(id) {
        var thisToken = ""

        this.getToken().then(token => thisToken = token)

        return fetch('http://localhost:8000/getuser/' + id, {
                method: 'GET',
                headers: {'Content-Type': 'application/json', 'Authentication': 'Bearer: ' + thisToken}
            }).then(res => res.json())
            .then(user => user).catch(error =>
                 console.log(error.response)
            )
    }

    setPassword(userId, password) {
        var thisToken = ""

        this.getToken().then(token => thisToken = token)

        var data = {
            id: userId,
            password: password
        }

        return fetch('http://localhost:80000/setuserpassword/', {
                method: 'POST',
                headers: {'Content-Type': 'application/json', 'Authentication': 'Bearer: ' + thisToken},
                body: JSON.stringify(data)
            }).then(res => res.json())
            .then(user => user).catch(error =>
                 console.log(error.response)
            )
    }
}

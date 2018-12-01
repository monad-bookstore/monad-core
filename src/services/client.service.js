import Cookie from 'js-cookie'
import axios from 'axios'

function validate(username, password) {
    const payload = { username: username, password: password }
    let result = { success: true, data: {} }
    axios.post('/api/authentication/validate', payload).then((response) => {
        result.data = response.data
    }).catch(e => {
        result.success = false
    })

    return result
}

function retrieve() {
    axios.get('/api/authentication/client').then(response => {
        return response.data
    })

    return null
}

function setAuthorizationKey(key) {
    Cookie.set("monad-authentication", key, { expires: 7 })    
    console.log(key)
}

function getAuthorizationKey() {
    return Cookie.get("monad-authentication")
}

function removeAuthorizationKey() {
    Cookie.remove("monad-authentication")
}

export const ClientService = {
    validate,
    getAuthorizationKey,
    setAuthorizationKey,
    removeAuthorizationKey,
    retrieve
}
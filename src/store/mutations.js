import { ClientService }  from '../services/client.service'

export default {
    AuthorizeClient: (state, { username, password }) => {
        const result = ClientService.validate(username, password)
        if (result.success) {
            state.client.data = result.data
        }
    },
    SetClient: (state, client) => {
        state.client.data = client
    },
}
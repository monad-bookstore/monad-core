export default {
    AuthorizeClient: (state, ssid) => {
        state.client.ssid = ssid
        state.client.data.administrator = true
    },
    LogoutClient: (state) => {
        state.client.ssid = null
    }
}
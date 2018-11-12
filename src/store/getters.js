export default {
    isAuthenticated: state => !!state.client.ssid,
    isAdministrator: state => !!_.get(state.client, "data.administrator")
}
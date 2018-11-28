export default {
    isAuthenticated: state => !!state.client.data,
    isAdministrator: state => _.get(state.client, "data.accessFlag", -1) === 1
}
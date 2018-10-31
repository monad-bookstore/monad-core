export default [
    {
        path: '/',
        name: 'welcome',
        component: require('../pages/Welcome.vue').default
    },
    {
        path: '/signin',
        name: 'signin',
        component: require('../pages/Signin.vue').default
    },
    {
        path: '/registration',
        name: 'registration',
        component: require('../pages/Registration.vue').default
    },
    {
        path: '/cart',
        name: 'cart',
        component: require('../pages/Cart.vue').default
    },
    {
        path: '/orders',
        name: 'orders',
        component: require('../pages/Orders.vue').default
    },
    {
        path: '/settings',
        name: 'settings',
        component: require('../pages/Settings.vue').default
    },
    {
        path: '/store',
        name: 'store',
        component: require('../pages/Store.vue').default
    },
    {
        path: '/contact',
        name: 'contact',
        component: require('../pages/Contact.vue').default
    },
    {
        path: '/cases',
        name: 'cases',
        component: require('../pages/Cases.vue').default
    },
    {
        path: '/case',
        name: 'case',
        component: require('../pages/CaseOverview.vue').default
    },
    {
        path: '/overview',
        name: 'overview',
        component: require('../pages/Overview.vue').default
    }
];
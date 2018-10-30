export default [
    {
        path: '/administrative',
        redirect: '/administrative/dashboard'
    },
    {
        path: '/administrative/dashboard',
        name: 'dashboard',
        component: require('../pages/Dashboard.vue').default
    },
    {
        path: '/administrative/products',
        name: 'products',
        component: require('../pages/Products.vue').default
    },
    {
        path: '/administrative/suppliers',
        name: 'suppliers',
        component: require('../pages/Suppliers.vue').default
    },
    {
        path: '/administrative/quality-control',
        name: 'quality-control',
        component: require('../pages/QualityControl.vue').default
    },
    {
        path: '/administrative/clients',
        name: 'clients',
        component: require('../pages/Clients.vue').default
    },
    {
        path: '/administrative/orders',
        name: 'orders',
        component: require('../pages/Orders.vue').default
    },
];
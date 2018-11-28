import authorized from '../../../middleware/authorized';

export default [
    {
        path: '/',
        name: 'welcome',
        component: require('../pages/Welcome.vue').default,
        meta: {
            titled: "El. knygų parduotuvė - MONAD.LT"
        }
    },
    {
        path: '/signin',
        name: 'signin',
        component: require('../pages/Signin.vue').default,
        meta: {
            titled: "Prisijungimas - MONAD.LT"
        }
    },
    {
        path: '/registration',
        name: 'registration',
        component: require('../pages/Registration.vue').default,
        meta: {
            titled: "Registracija - MONAD.LT"
        }
    },
    {
        path: '/cart',
        name: 'cart',
        component: require('../pages/Cart.vue').default,
        meta: {
            titled: "Pirkinių krepšelis - MONAD.LT",
            middleware: authorized
        }
    },
    {
        path: '/orders',
        name: 'orders',
        component: require('../pages/Orders.vue').default,
        meta: {
            titled: "Užsakymai - MONAD.LT"
        }
    },
    {
        path: '/order-overview',
        name: 'order-overview',
        component: require('../pages/OrderOverview.vue').default,
        meta: {
            titled: "Užsakymo apžvalga - MONAD.LT"
        }
    },
    {
        path: '/settings',
        name: 'settings',
        component: require('../pages/Settings.vue').default,
        meta: {
            titled: "Nustatymai - MONAD.LT"
        }
    },
    {
        path: '/store',
        name: 'store',
        component: require('../pages/Store.vue').default,
        meta: {
            titled: "Parduotuvė - MONAD.LT",
        }
    },
    {
        path: '/contact',
        name: 'contact',
        component: require('../pages/Contact.vue').default,
        meta: {
            titled: "Pagalbos centras - MONAD.LT"
        }
    },
    {
        path: '/cases',
        name: 'cases',
        component: require('../pages/Cases.vue').default,
        meta: {
            titled: "Pagalbos centras - MONAD.LT"
        }
    },
    {
        path: '/case',
        name: 'case',
        component: require('../pages/CaseOverview.vue').default,
        meta: {
            titled: "Pagalbos centras - MONAD.LT"
        }
    },
    {
        path: '/overview',
        name: 'overview',
        component: require('../pages/Overview.vue').default,
    }
];
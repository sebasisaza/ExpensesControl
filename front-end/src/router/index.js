import Vue from 'vue'
import Vuex from 'vuex'
import VueRouter from 'vue-router'
import General from '../views/General.vue'
import ExpenseControl from '../views/ExpenseControl.vue'
import DayCollection from '../views/DayCollection.vue'
import Clients from '../views/Clients.vue'
import Payments from '../views/Payments.vue'
import Login from '../views/Login.vue'

Vue.use(VueRouter)
Vue.use(Vuex)

const store = new Vuex.Store(
  {
    state: {
      authenticated: !!localStorage.getItem('token'),
    },
    mutations: {
      setAuthentication(state, status){
        state.authenticated = status;
      }
    }
  })

const routes = [
  {
    path: '/',
    name: 'Login',
    component: Login
  },
  {
    path: '/general',
    name: 'General',
    component: General,
    beforeEnter: (to, from, next) => {
      if(store.state.authenticated == false){
        next('/');
      }else{
        next();
      }
    }
  },
  {
    path: '/expense-control',
    name: 'ExpenseControl',
    component: ExpenseControl,
    beforeEnter: (to, from, next) => {
      if(store.state.authenticated == false){
        next('/');
      }else{
        next();
      }
    }
  },
  {
    path: '/day-collection',
    name: 'DayCollection',
    component: DayCollection,
    beforeEnter: (to, from, next) => {
      if(store.state.authenticated == false){
        next('/');
      }else{
        next();
      }
    }
  },
  {
    path: '/payments',
    name: 'Payments',
    component: Payments,
    beforeEnter: (to, from, next) => {
      if(store.state.authenticated == false){
        next('/');
      }else{
        next();
      }
    }
  },
  {
    path: '/clients',
    name: 'Clients',
    component: Clients,
    beforeEnter: (to, from, next) => {
      if(store.state.authenticated == false){
        next('/');
      }else{
        next();
      }
    }
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  store: store,
  routes
})

export default router

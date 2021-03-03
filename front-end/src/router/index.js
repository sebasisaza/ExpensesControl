import Vue from 'vue'
import VueRouter from 'vue-router'
import General from '../views/General.vue'
import ExpenseControl from '../views/ExpenseControl.vue'
import DayCollection from '../views/DayCollection.vue'
import Clients from '../views/Clients.vue'
import Payments from '../views/Payments.vue'
import Login from '../views/Login.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Login',
    component: Login
  },
  {
    path: '/general',
    name: 'General',
    component: General
  },
  {
    path: '/expense-control',
    name: 'ExpenseControl',
    component: ExpenseControl
  },
  {
    path: '/day-collection',
    name: 'DayCollection',
    component: DayCollection
  },
  {
    path: '/payments',
    name: 'Payments',
    component: Payments
  },
  {
    path: '/clients',
    name: 'Clients',
    component: Clients
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router

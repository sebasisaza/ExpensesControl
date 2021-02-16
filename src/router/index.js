import Vue from 'vue'
import VueRouter from 'vue-router'
import General from '../views/General.vue'
import ExpenseControl from '../views/ExpenseControl.vue'
import DayCollection from '../views/DayCollection.vue'
import DetailClient from '../views/DetailClient.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
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
    path: '/detail-client/:id_client',
    name: 'DetailClient',
    component: DetailClient
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router

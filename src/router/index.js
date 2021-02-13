import Vue from 'vue'
import VueRouter from 'vue-router'
import General from '../views/General.vue'
import ExpenseControl from '../views/ExpenseControl.vue'

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
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router

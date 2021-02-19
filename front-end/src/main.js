import Vue from 'vue'
import App from './App.vue'
import router from './router'
import Paginate from 'vuejs-paginate'
import Notifications from 'vue-notification'

Vue.config.productionTip = false
Vue.component('paginate', Paginate)
Vue.use(Notifications)

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')

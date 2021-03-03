<template>
  <div>
    <Header />
    <Payments />
  </div>
</template>

<script>
// @ is an alias to /src
import Payments from '@/components/Payments';
import Header from '@/views/Header.vue';
export default {
  components: {
    Payments,
    Header
  }
}
</script>

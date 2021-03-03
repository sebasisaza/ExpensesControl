<template>
  <div>
    <Header />
    <Clients />
  </div>
</template>

<script>
// @ is an alias to /src
import Clients from '@/components/Clients';
import Header from '@/views/Header.vue';
export default {
  components: {
    Clients,
    Header
  }
}
</script>

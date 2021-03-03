<template>
  <div>
    <Header />
    <General />
  </div>
</template>

<script>
// @ is an alias to /src
import General from '@/components/General';
import Header from '@/views/Header.vue';
export default {
  components: {
    General,
    Header
  }
}
</script>

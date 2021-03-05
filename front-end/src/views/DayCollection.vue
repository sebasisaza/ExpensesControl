<template>
  <div>
    <Header />
    <DayCollection />
  </div>
</template>

<script>
// @ is an alias to /src
import Header from '@/views/Header.vue';
import DayCollection from '@/components/DayCollection';
export default {
  components: {
    Header,
    DayCollection
  }
}
</script>

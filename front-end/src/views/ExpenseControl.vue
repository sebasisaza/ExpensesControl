<template>
  <div>
    <Header />
    <ExpenseControl />
  </div>
</template>

<script>
// @ is an alias to /src
import ExpenseControl from '@/components/ExpenseControl';
import Header from '@/views/Header.vue';
export default {
  components: {
    ExpenseControl,
    Header
  }
}
</script>

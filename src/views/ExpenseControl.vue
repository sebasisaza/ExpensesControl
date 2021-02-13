<template>
  <div>
    <ExpenseControl />
  </div>
</template>

<script>
// @ is an alias to /src
import ExpenseControl from '@/components/ExpenseControl';
export default {
  name: 'Home',
  components: {
    ExpenseControl
  }
}
</script>

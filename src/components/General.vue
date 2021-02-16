<template>
    <div class="content">
        <h1 class="tittle">Informacíon General</h1>
        <div class="general">
            <label>Saldo Inicial</label>
            <input type="text" class="input">
            <label>Fecha</label>
            <input type="date" class="input">
            <label>Utilidades Mes</label>
            <input type="text" class="input">
            <label>Gastos Mes</label>
            <input type="text" class="input">
            <label>Cartera Mes</label>
            <input type="text" class="input">
            <label>Cartera Total</label>
            <input type="text" class="input">
        </div>
    </div>
</template>
<script>
export default {
    
}
</script>
<style>

.content{
    display: grid;
    grid-template-columns: 1fr;
}
.general {
    display: grid;
    gap: 10px;
    grid-template-columns: 1fr 1fr;
    grid-template-rows: repeat(7, 1fr);
    grid-template-areas: 'label input'
                         'label input'
                         'label input'
                         'label input'
                         'label input'
                         'label input';
    align-self: center;
    justify-self: center;
}
.tittle{
    text-align: center;
    padding: 10px 0 10px 0;
}
</style>
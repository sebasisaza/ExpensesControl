<template>
    <div class="content">
        <h1 class="tittle">Control de Gastos</h1>
        <div class="expenses">
            <label>Concepto</label>
            <input type="text" class="input">
            <label>Valor</label>
            <input type="text" class="input">
            <label>Fecha</label>
            <input type="date" class="input">
        </div>
        <div class="div-table">
            <button class="btn-main">Agregar Gasto</button>
            <table class="table">
                <thead>
                    <tr>
                        <th>Concepto</th>
                        <th>Valor</th>
                        <th>Fecha</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Gasolina</td>
                        <td>20.000</td>
                        <td>16/02/2021</td>
                        <td><button class="btn-table">Borrar</button></td>
                    </tr>
                    <tr>
                        <td>Gasolina</td>
                        <td>20.000</td>
                        <td>16/02/2021</td>
                        <td><button class="btn-table">Borrar</button></td>
                    </tr>
                    <tr>
                        <td>Gasolina</td>
                        <td>20.000</td>
                        <td>16/02/2021</td>
                        <td><button class="btn-table">Borrar</button></td>
                    </tr>
                    <tr>
                        <td>Gasolina</td>
                        <td>20.000</td>
                        <td>16/02/2021</td>
                        <td><button class="btn-table">Borrar</button></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>
<script>
export default {
    
}
</script>
<style>
.expenses{
    display: grid;
    gap: 10px;
    grid-template-columns: 1fr 1fr;
    grid-template-rows: repeat(3, 1fr);
    grid-template-areas: 'label input'
                         'label input'
                         'label input';
    align-self: center;
    justify-self: center;
}
.div-table{
    padding: 2% 10% 0 10%;
}
</style>
<template>
    <div class="content">
        <h1 class="tittle">Control de Gastos</h1>
        <div class="form">
            <label>Concepto</label>
            <input type="text" class="input">
            <label>Valor</label>
            <input type="number" class="input">
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
                        <td><button class="btn-danger">Borrar</button></td>
                    </tr>
                    <tr>
                        <td>Gasolina</td>
                        <td>20.000</td>
                        <td>16/02/2021</td>
                        <td><button class="btn-danger">Borrar</button></td>
                    </tr>
                    <tr>
                        <td>Gasolina</td>
                        <td>20.000</td>
                        <td>16/02/2021</td>
                        <td><button class="btn-danger">Borrar</button></td>
                    </tr>
                    <tr>
                        <td>Gasolina</td>
                        <td>20.000</td>
                        <td>16/02/2021</td>
                        <td><button class="btn-danger">Borrar</button></td>
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

</style>
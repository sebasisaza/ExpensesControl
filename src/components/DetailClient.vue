<template>
    <div class="content">
        <h1 class="tittle">Detalle de: <span class="client">Felipe Agudelo</span></h1>
        <div class="form">
            <label>Tasa</label>
            <input type="text" class="input" disabled>
            <label>Teléfono</label>
            <input type="text" class="input" disabled>
            <label>Valor Prestado</label>
            <input type="text" class="input" disabled>
            <label>Valor Pagado</label>
            <input type="text" class="input" disabled>
            <label>Valor Adeudado</label>
            <input type="text" class="input" disabled>
        </div>
        <div class="div-table">
            <button class="btn-main">Agregar Pago</button>
            <table class="table">
                <thead>
                    <tr>
                        <th>Pago No</th>
                        <th>Valor</th>
                        <th>Fecha de Pago</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>1</td>
                        <td>20.000</td>
                        <td>16/02/2021</td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td>20.000</td>
                        <td>16/02/2021</td>
                    </tr>
                    <tr>
                        <td>3</td>
                        <td>20.000</td>
                        <td>16/02/2021</td>
                    </tr>
                    <tr>
                        <td>4</td>
                        <td>20.000</td>
                        <td>16/02/2021</td>
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
.client{
    font-size: 20px;
}
</style>
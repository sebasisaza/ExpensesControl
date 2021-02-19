<template>
    <div class="content">
        <h1 class="tittle">Cobros del día: <span class="day">16/02/2021</span></h1>
        <div class="div-table">
            <input type="text" class="input-search" placeholder="Buscar...">
            <table class="table">
                <thead>
                    <tr>
                        <th>Nombre</th>
                        <th>Teléfono</th>
                        <th>Dirección</th>
                        <th>Cuota</th>
                        <th>Valor Por Cuota</th>
                        <th>Detalle</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Gasolina</td>
                        <td>20.000</td>
                        <td>16/02/2021</td>
                        <td>16/02/2021</td>
                        <td>16/02/2021</td>
                        <td><router-link :to="{ path: 'detail-client/1' }"><button class="btn-info">Detalle</button></router-link></td>
                    </tr>
                    <tr>
                        <td>Gasolina</td>
                        <td>20.000</td>
                        <td>16/02/2021</td>
                        <td>16/02/2021</td>
                        <td>16/02/2021</td>
                        <td><router-link :to="{ path: 'detail-client/1' }"><button class="btn-info">Detalle</button></router-link></td>
                    </tr>
                    <tr>
                        <td>Gasolina</td>
                        <td>20.000</td>
                        <td>16/02/2021</td>
                        <td>16/02/2021</td>
                        <td>16/02/2021</td>
                        <td><router-link :to="{ path: 'detail-client/1' }"><button class="btn-info">Detalle</button></router-link></td>
                    </tr>
                    <tr>
                        <td>Gasolina</td>
                        <td>20.000</td>
                        <td>16/02/2021</td>
                        <td>16/02/2021</td>
                        <td>16/02/2021</td>
                        <td><router-link :to="{ path: 'detail-client/1' }"><button class="btn-info">Detalle</button></router-link></td>
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
.day{
    font-size: 20px;
}
</style>
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
            <button class="btn-main" v-on:click="showModal()">Agregar Pago</button>
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

        <div class="modal hidden">
            <div class="top-modal">
                <h1 class="tittle">Agregar Pago</h1>
                <button class="close-modal" v-on:click="closeModal()">&times;</button>
            </div>
            <div class="form">
                <label>Valor</label>
                <input type="number" class="input">
                <label>Fecha</label>
                <input type="date" class="input">
                <button class="btn-cancel" v-on:click="closeModal()">Cancelar</button>
                <button class="btn-main">Agregar</button>
            </div>
        </div>
        <div class="overlay hidden"></div>
        
    </div>
</template>
<script>
export default {
    data: function () {
        return {
            count: 0
        }
    },
    methods:{
        showModal(){
            const modal = document.querySelector('.modal');
            const overlay = document.querySelector('.overlay');
            modal.classList.remove('hidden');
            overlay.classList.remove('hidden');
        },
        closeModal(){
            const modal = document.querySelector('.modal');
            const overlay = document.querySelector('.overlay');
            modal.classList.add('hidden');
            overlay.classList.add('hidden');
        }
    }
}
</script>
<style>
.client{
    font-size: 20px;
}
</style>
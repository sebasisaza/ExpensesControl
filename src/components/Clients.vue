<template>
    <div class="content">
        <h1 class="tittle">Clientes</h1>
        <div class="div-table">
            <button class="btn-main" v-on:click="showModal()">Agregar Cliente</button>
            <table class="table">
                <thead>
                    <tr>
                        <th>Nombre</th>
                        <th>Teléfono</th>
                        <th>Tipo</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Gasolina</td>
                        <td>20.000</td>
                        <td>16/02/2021</td>
                        <td><button class="btn-info">Ver</button></td>
                    </tr>
                    <tr>
                        <td>Gasolina</td>
                        <td>20.000</td>
                        <td>16/02/2021</td>
                        <td><button class="btn-info">Ver</button></td>
                    </tr>
                    <tr>
                        <td>Gasolina</td>
                        <td>20.000</td>
                        <td>16/02/2021</td>
                        <td><button class="btn-info">Ver</button></td>
                    </tr>
                    <tr>
                        <td>Gasolina</td>
                        <td>20.000</td>
                        <td>16/02/2021</td>
                        <td><button class="btn-info">Ver</button></td>
                    </tr>
                </tbody>
            </table>
        </div>

        <div class="modal hidden">
            <div class="top-modal">
                <h1 class="tittle">Agregar Cliente</h1>
                <button class="close-modal">&times;</button>
            </div>
            <div class="form">
                <label>Nombre</label>
                <input type="text" class="input">
                <label>Cédula</label>
                <input type="text" class="input">
                <label>Teléfono</label>
                <input type="text" class="input">
                <label>Préstamo</label>
                <input type="text" class="input">
                <label>Plazo</label>
                <input type="text" class="input">
                <label>Interés</label>
                <input type="text" class="input">
                <label>Pago</label>
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
        }
    }
}
</script>
<style>
.hidden{
    display: none;
}
.modal {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  width: 70%;
  background-color: white;
  padding: 1rem 3rem 3rem 3rem;
  border-radius: 5px;
  box-shadow: 0 3rem 5rem rgba(0, 0, 0, 0.3);
  z-index: 3;
}
.overlay {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.6);
  backdrop-filter: blur(3px);
  z-index: 2;
}
.top-modal{
    display: grid;
    grid-template-columns: 0.8fr 0.2fr;
    margin-bottom: 20px;
}
.close-modal{
    text-align: right;
    font-size: 2rem;
    color: #333;
    cursor: pointer;
    border: none;
    background: none;
}
</style>
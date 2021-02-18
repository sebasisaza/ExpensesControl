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
                    <tr v-for="(item) in clients" :key="item.id_client">
                        <td>{{item.name}}</td>
                        <td>{{item.phone}}</td>
                        <td>{{item.payment_type}}</td>
                        <td><button class="btn-info">Ver</button></td>
                    </tr>
                </tbody>
            </table>
            <div class="pagination">
                <a href="#">&#8592;</a>
                <a href="#" class="active">1</a>
                <a href="#">2</a>
                <a href="#">3</a>
                <a href="#">4</a>
                <a href="#">5</a>
                <a href="#">6</a>
                <a href="#">&#8594;</a>
            </div>
        </div>

        <div class="modal hidden">
            <div class="top-modal">
                <h1 class="tittle">Agregar Cliente</h1>
                <button class="close-modal" v-on:click="closeModal()">&times;</button>
            </div>
            <div class="form">
                <label>Nombre</label>
                <input type="text" class="input">
                <label>Cédula</label>
                <input type="number" class="input">
                <label>Teléfono</label>
                <input type="number" class="input">
                <label>Préstamo</label>
                <input type="number" class="input">
                <label>Plazo</label>
                <input type="number" class="input">
                <label>Interés</label>
                <input type="number" class="input">
                <label>Pago</label>
                <div class="radios">
                    <div class="pretty p-icon p-round">
                        <input type="radio" name="icon_solid" />
                        <div class="state p-primary">
                            <i class="icon mdi mdi-check"></i>
                            <label>Diario</label>
                        </div>
                    </div>
                    <div class="pretty p-icon p-round">
                        <input type="radio" name="icon_solid" />
                        <div class="state p-success">
                            <i class="icon mdi mdi-check"></i>
                            <label>Semanal</label>
                        </div>
                    </div>
                    <div class="pretty p-icon p-round">
                        <input type="radio" name="icon_solid" />
                        <div class="state p-info">
                            <i class="icon mdi mdi-check"></i>
                            <label>Quincenal</label>
                        </div>
                    </div>
                    <div class="pretty p-icon p-round">
                        <input type="radio" name="icon_solid" />
                        <div class="state p-info">
                            <i class="icon mdi mdi-check"></i>
                            <label>Mensual</label>
                        </div>
                    </div>
                </div>
                <label>Sumar día cobro</label>
                <input type="number" class="input">
                <button class="btn-cancel" v-on:click="closeModal()">Cancelar</button>
                <button class="btn-main">Agregar</button>
            </div>
        </div>
        <div class="overlay hidden"></div>

    </div>
</template>
<script>
import axios from 'axios'
export default {
    data: function () {
        return {
            clients: []
        }
    },
    created: function () {
        axios.get('https://jsonplaceholder.typicode.com/users')
            .then((response) => {
                this.clients = response.data;
            }).catch((e) => {
                console.log(e);
            })
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
.hidden{
    display: none;
}
.modal {
  position: absolute;
  top: 30%;
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
.radios{
    display: flex;
    justify-content: space-around;
}
.btn-cancel{
    border: none;
    width: 150px;
    height: 40px;
    border-radius: 15px;
    background: #d32f2f;
    color: white;
}
.btn-cancel:hover{
  background: #a03838;
  cursor: pointer;
}
.table{
    margin-bottom: 20px;
}
.pagination {
  display: inline-block;
}
.pagination a {
  color: black;
  float: left;
  padding: 8px 16px;
  text-decoration: none;
}
.pagination a.active {
  background-color: #101A26;
  color: white;
  border-radius: 5px;
}
.pagination a:hover:not(.active) {
  background-color: #ddd;
  border-radius: 5px;
}
</style>
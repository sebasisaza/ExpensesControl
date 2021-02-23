<template>
    <div class="content">
        <h1 class="tittle">Detalle de: <span class="client">{{client.name}}</span></h1>
        <div class="form">
            <label>Tasa</label>
            <input type="text" class="input" v-model="client.interest_rate" disabled>
            <label>Teléfono</label>
            <input type="text" class="input" v-model="client.phone" disabled>
            <label>Valor Prestado</label>
            <input type="text" class="input" v-model="client.loan" disabled>
            <label>Valor Pagado</label>
            <input type="text" class="input" v-model="client.payment_paid" disabled>
            <label>Valor Adeudado</label>
            <input type="text" class="input" v-model="client.payment_owed" disabled>
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
                    <tr v-for="(item, index) in client.payments" :key="item.id_client">
                        <td>{{index+1}}</td>
                        <td>{{item.value}}</td>
                        <td>{{item.date}}</td>
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
import axios from 'axios'
export default {
    data: function () {
        return {
            id_client: this.$route.params.id_client,
            client:{
                name: '',
                interest_rate: '',
                phone: '',
                loan: '',
                payment_paid: '',
                payment_owed: '',
                payments: []
            }
        }
    },
    created(){
        this.getDetail();
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
        },
        getDetail(){
            axios.get(process.env.VUE_APP_URL+`ClientPayments/getByIdClient/${this.id_client}`)
            .then((response) => {
                this.client = response.data.data;
            }).catch((e) => {
                console.log(e);
            })   
        }
    }
    
}
</script>
<style>
.client{
    font-size: 20px;
}
</style>
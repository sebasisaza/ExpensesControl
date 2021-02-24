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
    </div>
</template>
<script>
import moment from 'moment'
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
            },
            clientPayment:{
                value: '',
                date: moment().format('yyyy-MM-DD'),
                id_client: this.id_client
            }
        }
    },
    created(){
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
             this.cleanPayment();
        },
    }
}
</script>
<style>
.client{
    font-size: 20px;
}
</style>
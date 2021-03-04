<template>
    <div class="content">
        <h1 class="tittle">Informacíon General</h1>
        <div class="form">
            <label>Saldo Inicial</label>
            <input v-model="info.initial_balance" type="number" class="input">
            <label>Fecha</label>
            <input v-model="date" v-on:change="dateChange(date)" type="month" class="input">
            <label>Utilidades Mes</label>
            <input v-model="info.utilities_month" type="text" class="input" disabled>
            <label>Gastos Mes</label>
            <input v-model="info.expenses_month" type="text" class="input" disabled>
            <label>Cartera Mes</label>
            <input v-model="info.payment_pending_month" type="text" class="input" disabled>
            <label>Cartera Total</label>
            <input v-model="info.payment_pending" type="text" class="input" disabled>
        </div>
    </div>
</template>
<script>
import axios from 'axios'
import moment from 'moment'
export default {
    data: function(){
        return{
            date: moment().format('yyyy-MM'),
            info:{
                initial_balance: '',
                utilities_month: '',
                expenses_month: '',
                payment_pending_month: '',
                payment_pending: ''
            }
        }
    },
    created: function () {
        this.getData(this.date);
    },
    methods:{
        getData(date){
            axios.create({
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer '+localStorage.getItem('token')
                }
            })
            .get(process.env.VUE_APP_URL+`General/get/${date}`)
            .then((response) => {
                this.info = response.data;
            }).catch((e) => {
                console.log(e);
            })   
        },
        dateChange(date){
            this.clearInfo();
            this.getData(date);
        },
        clearInfo(){
            this.info ={
                initial_balance: '',
                utilities_month: '',
                expenses_month: '',
                payment_pending_month: '',
                payment_pending: ''
            }
        }
    }
}
</script>
<style>


</style>
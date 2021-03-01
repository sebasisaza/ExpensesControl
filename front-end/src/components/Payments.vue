<template>
    <div class="content">
        <h1 class="tittle">Relación de Pagos</h1>
        <div class="div-table">
            <input type="text" v-model="search" v-on:keyup="searchClient()" class="input-search" placeholder="Buscar...">
            <table class="table">
                <thead>
                    <tr>
                        <th>Nombre</th>
                        <th>Identificación</th>
                        <th class="hide">Teléfono</th>
                        <th class="hide">Tipo Pago</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody v-if="clients.length > 0">
                    <tr v-for="(item) in clients" :key="item.id_client">
                        <td>{{item.name}}</td>
                        <td>{{item.identification}}</td>
                        <td class="hide">{{item.phone}}</td>
                        <td class="hide" v-if="1 === item.payment_type">Diario</td>
                        <td class="hide" v-else-if="2 === item.payment_type">Semanal</td>
                        <td class="hide" v-else-if="3 === item.payment_type">Quincenal</td>
                        <td class="hide" v-else-if="4 === item.payment_type">Mensual</td>
                        <td><button class="btn-info" v-on:click="getDetail(item.id_client)">Detalle</button></td>
                    </tr>
                </tbody>
                <tbody v-else>
                    <tr>
                        <td colspan="7">No hay registros...</td>
                    </tr>
                </tbody>
            </table>
            <paginate
                :page-count="pages"
                :page-range="currentPage"
                :click-handler="pageChange"
                :prev-text="'<'"
                :next-text="'>'"
                :container-class="'pagination'">
            </paginate>
        </div>

        <div class="modal hidden">
            <div class="top-modal">
                <h1 class="tittle">Detalle Pagos Cliente</h1>
                <button class="close-modal" v-on:click="closeModal()">&times;</button>
            </div>
            <div class="form">
                <label>Nombre</label>
                <label>{{clientDetail.name}}</label>
                <label>Tasa</label>
                <label>{{clientDetail.interest_rate}}%</label>
                <label>Teléfono</label>
                <label>{{clientDetail.phone}}</label>
                <label>Tipo de Pago</label>
                <label>{{payment_type_desc[clientDetail.payment_type-1]}}</label>
                <label>Plazo</label>
                <label>{{clientDetail.time_limit}} días</label>
                <label>Valor Cuota</label>
                <label>{{clientDetail.payment_scheduled}}</label>
                <label>Valor Prestado</label>
                <label>{{clientDetail.loan}}</label>
                <label>Valor Pagado</label>
                <label>{{clientDetail.payment_paid}}</label>
                <label>Valor Adeudado</label>
                <label>{{clientDetail.payment_owed}}</label>
            </div><hr><br>
            <div class="form">
                <label>Valor</label>
                <input v-model="payment.value" type="number" class="input">
                <label>Fecha</label>
                <input v-model="payment.date" type="date" class="input">
                <button class="btn-main" v-on:click="addPayment(payment)">Agregar Pago</button>
            </div>
            <table class="table">
                <thead>
                    <tr>
                        <th>Pago No</th>
                        <th>Valor</th>
                        <th>Fecha</th>
                    </tr>
                </thead>
                <tbody v-if="clientDetail.payments.length > 0">
                    <tr v-for="(item, i) in clientDetail.payments" :key="item.id_client_payment">
                        <td>{{i+1}}</td>
                        <td>{{item.value}}</td>
                        <td>{{item.date}}</td>
                    </tr>
                </tbody>
                <tbody v-else>
                    <tr>
                        <td colspan="7">No hay registros...</td>
                    </tr>
                </tbody>
            </table>
            <button class="btn-cancel" v-on:click="closeModal()">Cancelar</button>
        </div>
        <div class="overlay hidden"></div>

    </div>
</template>
<script>
import axios from 'axios'
import Paginate from 'vuejs-paginate'
import moment from 'moment'
export default {
    Paginate,
    data: function () {
        return {
            id_client: 0,
            clients: [],
            pages: 0,
            currentPage: 1,
            search: '',
            clientDetail:{
                name: '',
                interest_rate: '',
                identification: '',
                phone: '',
                payment_type: '',
                loan: '',
                time_limit: '',
                payment_scheduled: '',
                payments:[]
            },
            payment:{
                id_client: 0,
                value: '',
                date: moment().format('yyyy-MM-DD'),
            },
            payment_type_desc: [
                'Diario',
                'Semanal',
                'Quincenal',
                'Mensual'
            ]
        }
    },
    created: function () {
        this.getClients();
    },
    methods:{
        getClients(){
            const size = 10;
            const page = this.currentPage;
            const search = this.search;
            axios.get(process.env.VUE_APP_URL+`Clients/get?size=${size}&page=${page}&search=${search}`)
            .then((response) => {
                this.clients = response.data.data;
                this.pages = response.data.pages;
            }).catch((e) => {
                console.log(e);
            })
        },
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
        pageChange(pageNum){
            this.currentPage = pageNum;
            this.getClients();
        },
        searchClient(){
            this.getClients();
        },
        getDetail(id_client){
            this.id_client = id_client;
            this.showModal();
            axios.get(process.env.VUE_APP_URL+`ClientPayments/getByIdClient/${id_client}`)
            .then((response) => {
                this.clientDetail = response.data.data;
            }).catch((e) => {
                console.log(e);
            })   
        },
        addPayment(){
            this.payment.id_client = this.id_client;
            const validation = this.validate(this.payment);
            if(!validation.success){
                this.$notify({
                    text: validation.message,
                    type: 'error'
                });
            }else{
                this.payment.id_client = parseInt(this.id_client);
                this.payment.value = parseInt(this.payment.value);
                axios.post(process.env.VUE_APP_URL+'ClientPayments/create', this.payment)
                .then((response) => {
                    if(response.data.data)
                    {
                        this.closeModal();
                        this.cleanPayment();
                        this.$notify({
                            title: 'Confirmación',
                            text: response.data.messages[0]
                        });
                        this.getDetail(this.payment.id_client);
                    }
                }).catch((e) => {
                    console.log(e);
                })
            }
        },
        validate(payment){
            let res = {
                success: false,
                message: ''
            };
            if(payment.value === ''){
                res.message = 'El valor es obligatorio';
                return res;
            }else if(payment.date === ''){
                res.message = 'La fecha es obligatoria';
                return res;
            }else{
                res.success = true;
                return res;
            }
        },
        cleanPayment(){
            this.payment = {
                value: '',
                date: moment().format('yyyy-MM-DD'),
                id_client: this.id_client
            }
        },
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
.pagination li {
  display: inline-block;
}
.pagination li a {
  float: left;
  padding: 8px 16px;
  text-decoration: none;
}
.pagination li.active {
  background-color: #101A26;
  color: white;
  border-radius: 5px;
}
.pagination li:hover:not(.active) {
  background-color: #ddd;
  border-radius: 5px;
}
</style>
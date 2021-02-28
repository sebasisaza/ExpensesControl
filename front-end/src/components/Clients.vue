<template>
    <div class="content">
        <h1 class="tittle">Clientes</h1>
        <div class="div-table">
            <button class="btn-main" v-on:click="showModal()">Agregar Cliente</button><br>
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
                        <td><button class="btn-info" v-on:click="getClient(item.id_client)">Editar</button></td>
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
                <h1 class="tittle">Agregar Cliente</h1>
                <button class="close-modal" v-on:click="closeModal()">&times;</button>
            </div>
            <div class="form">
                <label>Nombre</label>
                <input v-model="client.name" type="text" class="input">
                <label>Cédula</label>
                <input v-model="client.identification" type="number" class="input">
                <label>Teléfono</label>
                <input v-model="client.phone" type="number" class="input">
                <label>Préstamo</label>
                <input v-model="client.loan" type="number" class="input">
                <label>Pago</label>
                <div class="radios">
                    <div class="pretty p-icon p-round" v-on:change="radioChange(client.payment_type)">
                        <input v-model="client.payment_type" type="radio" name="icon_solid" value="1"/>
                        <div class="state p-primary">
                            <i class="icon mdi mdi-check"></i>
                            <label>Diario</label>
                        </div>
                    </div>
                    <div class="pretty p-icon p-round" v-on:change="radioChange(client.payment_type)">
                        <input v-model="client.payment_type" type="radio" name="icon_solid" value="2"/>
                        <div class="state p-success">
                            <i class="icon mdi mdi-check"></i>
                            <label>Semanal</label>
                        </div>
                    </div>
                    <div class="pretty p-icon p-round" v-on:change="radioChange(client.payment_type)">
                        <input v-model="client.payment_type" type="radio" name="icon_solid" value="3"/>
                        <div class="state p-info">
                            <i class="icon mdi mdi-check"></i>
                            <label>Quincenal</label>
                        </div>
                    </div>
                    <div class="pretty p-icon p-round" v-on:change="radioChange(client.payment_type)">
                        <input v-model="client.payment_type" type="radio" name="icon_solid" value="4"/>
                        <div class="state p-info">
                            <i class="icon mdi mdi-check"></i>
                            <label>Mensual</label>
                        </div>
                    </div>
                </div>
                <label>Plazo</label>
                <select class="select" name="select" v-model="client.time_limit">
                    <option v-for="(item) in options" :key="item.key" :value="item.value">{{item.description}}</option>
                </select>
                <label>Interés</label>
                <input v-model="client.interest_rate" type="number" class="input">
                <label>Sumar día cobro</label>
                <input v-model="client.days_added" type="number" class="input">
                <button class="btn-cancel" v-on:click="closeModal()">Cancelar</button>
                <button class="btn-main" v-if="!update" v-on:click="addClient()">Agregar</button>
                <button class="btn-main" v-if="update" v-on:click="updateClient()">Actualizar</button>
            </div>
        </div>
        <div class="overlay hidden"></div>

    </div>
</template>
<script>
import axios from 'axios'
import Paginate from 'vuejs-paginate'
export default {
    Paginate,
    data: function () {
        return {
            clients: [],
            pages: 0,
            currentPage: 1,
            search: '',
            client:{
                name: '',
                identification: '',
                phone: '',
                loan: '',
                time_limit: 30,
                interest_rate: '',
                payment_type: 1,
                days_added: ''
            },
            update: false,
            options:[
                {description: '30 días', value: 30},
                {description: '60 días', value: 60}
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
            this.cleanClient();
            this.update = false;
        },
        pageChange(pageNum){
            this.currentPage = pageNum;
            this.getClients();
        },
        searchClient(){
            this.getClients();
        },
        parseObjectClient(client){
            this.client.identification = parseFloat(client.identification);
            this.client.loan = parseFloat(client.loan);
            this.client.time_limit = parseFloat(client.time_limit);
            this.client.interest_rate = parseFloat(client.interest_rate);
            this.client.days_added = parseFloat(client.days_added);
            this.client.payment_type = parseFloat(client.payment_type);
            return this.client;
        },
        cleanClient(){
            this.client = {
                name: '',
                identification: '',
                phone: '',
                loan: '',
                time_limit: '',
                interest_rate: '',
                payment_type: 1,
                days_added: ''
            };
        },
        addClient(){
            this.client.time_limit = this.client.time_limit.value;
            const validation = this.validate(this.client);
            if(!validation.success){
                this.$notify({
                    text: validation.message,
                    type: 'error'
                });
            }else{
                this.parseObjectClient(this.client);
                axios.post(process.env.VUE_APP_URL+'Clients/create', this.client)
                .then((response) => {
                    if(response.data.data)
                    {
                        this.closeModal();
                        this.cleanClient();
                        this.$notify({
                            text: response.data.messages[0],
                            type: 'success'
                        });
                        this.getClients();
                    }
                }).catch((e) => {
                    console.log(e);
                })
            }
        },
        getClient(id_client){
            this.update = true;
            axios.get(process.env.VUE_APP_URL+`Clients/get/${id_client}`)
            .then((response) => {
                this.radioChange(response.data.data.payment_type);
                this.client = response.data.data;
                this.showModal();
            }).catch((e) => {
                console.log(e);
            })
        },
        updateClient(){
            const validation = this.validate(this.client);
            if(!validation.success){
                this.$notify({
                    text: validation.message,
                    type: 'error'
                });
            }else{
                this.parseObjectClient(this.client);
                axios.post(process.env.VUE_APP_URL+'Clients/update', this.client)
                .then((response) => {
                    if(response.data.data)
                    {
                        this.closeModal();
                        this.cleanClient();
                        this.$notify({
                            text: response.data.messages[0],
                            type: 'success'
                        });
                        this.getClients();
                    }
                }).catch((e) => {
                    console.log(e);
                })
            }
        },
        validate(client){
            let res = {
                success: false,
                message: ''
            };
            if(client.name === ''){
                res.message = 'El nombre es obligatorio';
                return res;
            }else if(client.identification === ''){
                res.message = 'La identificación es obligatoria';
                return res;
            }else if(client.phone === ''){
                res.message = 'El teléfono es obligatorio';
                return res;
            }else if(client.loan === ''){
                res.message = 'La prestamo es obligatorio';
                return res;
            }else if(client.time_limit === ''){
                res.message = 'El plazo es obligatorio';
                return res;
            }else if(client.payment_type === ''){
                res.message = 'El tipo de pago es obligatorio';
                return res;
            }else if(client.days_added === ''){
                res.message = 'Sumar día cobro es obligatorio';
                return res;
            }else{
                res.success = true;
                return res;
            }
        },
        radioChange(payment_type){
            switch (Number(payment_type)) {
                case 1:
                    this.options = [
                        {description: '30 días', value: 30},
                        {description: '60 días', value: 60}
                    ];
                    break;
                case 2:
                    this.options = [
                        {description: '4 semanas', value: 30},
                        {description: '8 semanas', value: 60}
                    ];
                    break;
                case 3:
                    this.options = [
                        {description: '2 quincenas', value: 30},
                        {description: '4 quincenas', value: 60}
                    ];
                    break;
                case 4:
                    this.options = [
                        {description: '1 mes', value: 30},
                        {description: '2 meses', value: 60}
                    ];
                    break;
            }
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
.select{
    border: 2px solid #ccc;
    border-radius: 15px;
    padding: 2px 15px 2px 15px;
}
</style>
<template>
    <div class="content">
        <h1 class="tittle">Cobros del día: <span class="day">{{today}}</span></h1>
        <div class="div-table">
            <input type="text" class="input-search" placeholder="Buscar...">
            <table class="table">
                <thead>
                    <tr>
                        <th>Nombre</th>
                        <th>Teléfono</th>
                        <th>Cuota</th>
                        <th>Valor Por Cuota</th>
                        <th>Detalle</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(item) in dayCollections" :key="item.id_client">
                        <td>{{item.name_client}}</td>
                        <td>{{item.phone_client}}</td>
                        <td>{{item.payments}}/{{item.payments_scheduled}}</td>
                        <td>{{item.payments_value}}</td>
                        <td><router-link :to="{ path: 'detail-client/'+item.id_client }"><button class="btn-info">Detalle</button></router-link></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>
<script>
import axios from 'axios'
import moment from 'moment'
export default {
    data: function(){
        return {
            today: moment().format('yyyy-MM-DD'),
            dayCollections: []
        }
    },
    created(){
        this.getDatCollections();
    },
    methods:{
        getDatCollections(){
            axios.get(process.env.VUE_APP_URL+`DayCollections/get`)
            .then((response) => {
                this.dayCollections = response.data.data;
            }).catch((e) => {
                console.log(e);
            })   
        }

    }
}
</script>
<style>
.day{
    font-size: 20px;
}
</style>
<template>
    <div class="content">
        <h1 class="tittle">Control de Gastos</h1>
        <div class="form">
            <label>Concepto</label>
            <input v-model="expense.description" type="text" class="input">
            <label>Valor</label>
            <input v-model="expense.value" type="number" class="input">
            <label>Fecha</label>
            <input v-model="expense.date" type="date" class="input">
        </div>
        <div class="div-table">
            <button v-on:click="addExpense()" class="btn-main">Agregar Gasto</button>
            <table class="table">
                <thead>
                    <tr>
                        <th>Concepto</th>
                        <th>Valor</th>
                        <th>Fecha</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody v-if="expenses.length > 0">
                    <tr v-for="(item) in expenses" :key="item.id_expense">
                        <td>{{item.description}}</td>
                        <td>{{item.value}}</td>
                        <td>{{item.date}}</td>
                        <td><button v-on:click="deleteExpense(item.id_expense)" class="btn-danger">Borrar</button></td>
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
    </div>
</template>
<script>
import axios from 'axios'
export default {
    data: function () {
        return {
            expenses: [],
            pages: 0,
            currentPage: 1,
            expense:{
                description: '',
                value: '',
                date: ''
            }
        }
    },
    created(){
        this.getExpenses();
    },
    methods:{
        getExpenses(){
            const size = 10;
            const page = this.currentPage;
            axios.get(process.env.VUE_APP_URL+`Expenses/get?size=${size}&page=${page}`)
            .then((response) => {
                this.expenses = response.data.data;
                this.pages = response.data.pages;
            }).catch((e) => {
                console.log(e);
            })
        },
        pageChange(pageNum){
            this.currentPage = pageNum;
            this.getExpenses();
        },
        cleanExpense(){
            this.expense = {
                description: '',
                value: '',
                date: ''
            };
        },
        addExpense(){
            const validation = this.validate(this.expense);
            if(!validation.success){
                this.$notify({
                    text: validation.message,
                    type: 'error'
                });
            }else{
                this.expense.value = parseInt(this.expense.value);
                axios.post(process.env.VUE_APP_URL+'Expenses/create', this.expense)
                .then((response) => {
                    if(response.data.data)
                    {
                        this.$notify({
                            title: 'Confirmación',
                            text: response.data.messages[0]
                        });
                        this.cleanExpense();
                        this.getExpenses();
                    }
                }).catch((e) => {
                    console.log(e);
                })
            }
        },
        deleteExpense(id_expense){
            axios.get(process.env.VUE_APP_URL+`Expenses/delete/${id_expense}`)
            .then((response) => {
                if(response.data.data)
                {
                    this.$notify({
                        title: 'Confirmación',
                        text: response.data.messages[0]
                    });
                    this.getExpenses();
                }
            }).catch((e) => {
                console.log(e);
            })
        },
        validate(expense){
            let res = {
                success: false,
                message: ''
            };
            if(expense.description === ''){
                res.message = 'El concepto es obligatorio';
                return res;
            }else if(expense.value === ''){
                res.message = 'El valor es obligatorio';
                return res;
            }else if(expense.date === ''){
                res.message = 'La fecha es obligatoria';
                return res;
            }else{
                res.success = true;
                return res;
            }
        }
    }
}
</script>
<style>

</style>
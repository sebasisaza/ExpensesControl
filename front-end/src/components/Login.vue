<template>
    <div class="login">
        <div class="container">
            <h1>Iniciar Sesión</h1>
            <input v-model="loginData.username" type="text" class="input-login" placeholder="Usuario">
            <input v-model="loginData.password" type="password" class="input-login" placeholder="Contraseña">
            <button v-on:click="login()" class="btn-login">Ingresar</button>
        </div>    
    </div>
</template>
<script>
import axios from 'axios'
export default {
    data: function () {
        return {
            loginData:{
                username: '',
                password: ''
            }
        }
    },
    methods:{
        login(){

            var bodyFormData = new FormData();
            bodyFormData.append('username', this.loginData.username);
            bodyFormData.append('password', this.loginData.password);

            axios.post(process.env.VUE_APP_URL+'Login/auth', bodyFormData)
            .then((response) => {
                localStorage.setItem('token', response.data);
                this.$router.push({ name: 'General' })
            }).catch((e) => {
                console.log(e);
                this.$notify({
                    text: 'Credenciales Invalidas',
                    type: 'error'
                });
            })
        }
    }
}
</script>
<style>
.login{
    margin-top: 5%;
    display: flex;
    justify-content: center;
}
.container{
    -webkit-box-shadow: 0 15px 30px 0 rgb(0 0 0 / 20%);
    -moz-box-shadow: 0 15px 30px 0 rgb(0 0 0 / 20%);
    box-shadow: 0 15px 30px 0 rgb(0 0 0 / 20%);
    border: none;
    padding: 5%;
    border-radius: 30px;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-around;
    height: 250px;
}
.input-login{
    border: 2px solid #ccc;
    border-radius: 15px;
    outline: none;
    padding: 2px 15px 2px 15px;
    width: 90%;
}
.btn-login{
    border: none;
    width: 100%;
    height: 40px;
    border-radius: 30px;
    background: #101A26;
    color: white;
    margin-bottom: 10px;
}
.btn-login:hover{
  background: #335379;
  cursor: pointer;
}

@media only screen 
  and (min-device-width: 300px) 
  and (max-device-width: 568px)
  and (-webkit-min-device-pixel-ratio: 2) {
    .login{
        margin: 0;
    }
    .container{
      width: 100%;
      box-shadow: none;

    }
    .btn-login{
        width: 100%;
    }
}
</style>
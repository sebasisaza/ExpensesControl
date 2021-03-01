<template>
  <div id="app">
    <header>
      <h1>Control de Gastos</h1>
    </header>
    <nav>
      <router-link to="/">General</router-link>
      <router-link to="/expense-control">Control de Gastos</router-link>
      <!-- <router-link to="/day-collection">Cobros día</router-link> -->
      <router-link to="/payments">Relación Pagos</router-link>
      <router-link to="/clients">Clientes</router-link>
    </nav>
    <router-view/>
    <notifications position="top center"/>
  </div>
</template>

<style>
@import url('https://fonts.googleapis.com/css2?family=Poppins:wght@100&display=swap');
*{
  margin: 0;
  padding: 0;
  font-family: 'Poppins', sans-serif;
  font-size: 16px;
  font-weight: bolder;
}
#app{
  display: grid;
  grid-template-columns: 1fr;
  grid-template-rows: 0.2fr 0.2fr 1.6fr;
  grid-template-areas: 'header'
                       'nav'
                       'content';
}
.content{
  grid-area: content;
}
header{
  display: flex;
  justify-content: space-around;
  background: #101A26;
  color: #fff;
  padding: 1rem;
}
nav a:link{
  text-decoration: none;
  color: #101A26;
}
nav {
  padding: 0.3rem;
  background: #ccc;
  color: #fff;
  display: flex;
  justify-content: space-around;
}
nav a{
  padding: 10px;
  text-decoration: none;
  font-weight: bolder;
}
nav a:visited{
  text-decoration: none;
  color: #101A26;
}
nav a.router-link-exact-active {
  color: #fff;
}
.content{
    display: grid;
    grid-template-columns: 1fr;
}
.form {
    display: grid;
    gap: 10px;
    grid-template-columns: 1fr 1fr;
    align-self: center;
    justify-self: center;
}
.tittle{
    text-align: center;
    padding: 10px 0 10px 0;
}
.input{
    border: 2px solid #ccc;
    border-radius: 15px;
    outline: none;
    padding: 2px 15px 2px 15px;
}
.input-search{
  border: 2px solid #ccc;
  border-radius: 15px;
  outline: none;
  padding: 2px 15px 2px 15px;
  width: 250px;
  margin-bottom: 10px;
}
.div-table{
    padding: 0 10% 0 10%;
}
.table{
    width: 100%;
    border-collapse: collapse;
}
.table thead tr {
    background-color: #ccc;
    text-align: left;
}
.table th,
.table td {
    padding: 5px 10px;
}

.table tbody tr:hover{
    background: #f8f8f8;
}
button:focus{
  outline: none;
}
.btn-main{
    border: none;
    width: 150px;
    height: 40px;
    border-radius: 15px;
    background: #101A26;
    color: white;
    margin-bottom: 10px;
}
.btn-main:hover{
  background: #335379;
  cursor: pointer;
}
.btn-danger{
    border: none;
    width: 80px;
    height: 25px;
    border-radius: 8px;
    background: #d32f2f;
    color: white;
}
.btn-danger:hover{
  background: #a03838;
  cursor: pointer;
}
.btn-info{
    border: none;
    width: 80px;
    height: 25px;
    border-radius: 8px;
    background: #2196F3;
    color: white;
    text-decoration: none;
}
.btn-info:hover{
  background: #1976D2;
  cursor: pointer;
}

@media only screen 
  and (min-device-width: 300px) 
  and (max-device-width: 568px)
  and (-webkit-min-device-pixel-ratio: 2) {
    nav{
      flex-direction: column;
      align-items: center;
    }
    nav a{
      padding: 5px;
      text-decoration: none;
      font-weight: bolder;
      font-size: 13px;
    }
    .form{
      padding: 0 2% 0 2%;
    }
    .div-table{
      padding: 0 2% 0 2%;
    }
    .table th, .table td {
        padding: 3px;
        word-wrap: break-word
    }
    .btn-danger, .btn-info{
      width: 60px;
      font-size: 13px;
    }
    .input{
      width: 100px;
      height: 25px;
    }
    .modal .form{
      display: grid;
      grid-template-columns: 120px 200px;
    }
    .radios{
      flex-direction: column;
    }
    .modal .btn-cancel, .modal .btn-main{
      width: 120px;
    }
    .hide{
      display: none;
    }
}

</style>

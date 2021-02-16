<template>
  <div id="app">
    <header>
      <h1>Control de Gastos</h1>
    </header>
    <nav>
      <router-link to="/">General</router-link>
      <router-link to="/expense-control">Control de Gastos</router-link>
      <router-link to="/day-collection">Cobros día</router-link>
      <router-link to="/customers">Clientes</router-link>
    </nav>
    <router-view/>
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

nav a:link{
  text-decoration: none;
  color: #101A26;
}

header{
  background: #101A26;
  color: #fff;
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 1rem;
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
  text-align: center;
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
.btn-table{
    border: none;
    width: 80px;
    height: 25px;
    border-radius: 8px;
    background: #d32f2f;
    color: white;
}
.btn-table:hover{
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
  and (min-device-width: 320px) 
  and (max-device-width: 480px)
  and (-webkit-min-device-pixel-ratio: 2) {

    nav {
      display: grid;
      grid-template-columns: 1fr 1fr;
      grid-template-rows: 1fr, 1fr;
      grid-template-areas: 'router-link router-link'
                           'router-link router-link';
      align-items: center;
      max-width: 320px;
    }
    input{
      width: 110px;
    }
}

</style>

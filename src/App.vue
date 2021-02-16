<template>
  <div id="app">
    <header>
      <h1>Control de Gastos</h1>
    </header>
    <nav>
      <router-link to="/">General</router-link>
      <router-link to="/expense-control">Control de Gastos</router-link>
      <router-link to="/day">Cobros día</router-link>
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

a:link{
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

.input{
    border: 2px solid #ccc;
    border-radius: 15px;
    outline: none;
    padding: 2px 10px 2px 10px;
}
.table{
    width: 100%;
    border-collapse: collapse;
    min-width: 400px;
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

</style>

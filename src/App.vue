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
</style>

<template>
  <nav class="navbar navbar-expand navbar-dark bg-primary" style="position: sticky; top: 56px; z-index: 10;">
    <div class="container-fluid">
      <div class="navbar-header">
        <router-link class="navbar-brand" :to="'/Library'">Library manager</router-link>
      </div>

      <button class="navbar-toggler" type="button" data-toggle="collapse" aria-expanded="false" aria-label="Toggle navigation" >
        <span class="navbar-toggler-icon">|||</span>
      </button>

      <div class="collapse navbar-collapse" id="navbar">
        <ul class="nav navbar-nav mr-auto">
          <li class="nav-item"><router-link class="nav-link" :to="'/Library/BooksReaderView'">Books to take</router-link></li>
          <li class="nav-item"><router-link class="nav-link" :to="'/Library/Storage'">Storage</router-link></li>
          <li class="nav-item"><router-link class="nav-link" :to="'/Library/Register'">Register</router-link></li>
          
        </ul>
      </div>
    </div>
  </nav>
</template>

<script>
export default {
  name: "LibNavbar",
};
</script>

<style>
</style>
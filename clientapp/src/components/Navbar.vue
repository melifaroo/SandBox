<template>
  <nav class="navbar navbar-expand navbar-dark bg-dark" style="position: sticky; top: 0; z-index: 10;">
    <div class="container-fluid">
      <div class="navbar-header">
        <router-link class="navbar-brand" to="/">Sandbox</router-link>
      </div>

      <button class="navbar-toggler" type="button" data-toggle="collapse" aria-expanded="false" aria-label="Toggle navigation" >
        <span class="navbar-toggler-icon"></span>
      </button>

      <div class="collapse navbar-collapse" id="navbar">
        <ul class="nav navbar-nav mr-auto">
          <li class="nav-item"><router-link class="nav-link" to="/">Home <span class="sr-only">(current)</span></router-link></li>   
          <li class="nav-item"><router-link class="nav-link" to="/Blogs">Blogs</router-link></li>
          <li class="nav-item"><router-link class="nav-link" to="/Library">Library</router-link></li>       
          <li class="nav-item"><router-link class="nav-link" to="/About">About</router-link></li>
        </ul>        
      </div>
    </div>
  </nav>
</template>

<script>
export default {
  name: "Navbar",
};
</script>

<style>
</style>
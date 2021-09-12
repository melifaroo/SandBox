<template>
  <nav class="navbar navbar-expand navbar-dark bg-primary" style="position: sticky; top: 56px; z-index: 10;">
    <div class="container-fluid">
        <span ></span>
      <div class="navbar-header">
        <router-link class="navbar-brand" :to="'/Blogs'">BlogsApp</router-link>
      </div>

      <button class="navbar-toggler" type="button" data-toggle="collapse" aria-expanded="false" aria-label="Toggle navigation" >
        <span class="navbar-toggler-icon">|||</span>
      </button>

      <div class="collapse navbar-collapse" id="navbar">
        <ul class="nav navbar-nav mr-auto">
          <li class="nav-item"><router-link class="nav-link" :to="'/Blogs'">Blogs<span class="sr-only">(current)</span></router-link></li>
          <li class="nav-item"><router-link class="nav-link" :to="'/Blogs/Bloggers'">Bloggers</router-link></li>       
          <li class="nav-item"><router-link class="nav-link" :to="'/Blogs/Posts'">Posts</router-link></li>
        </ul>

        <ul class="nav navbar-nav ml-auto">
          <li class="nav-item"><label class="navbar-brand">Util : </label></li>
          <li class="nav-item"><router-link class="nav-link " to="/Blogs/DBSeed">Seed DB</router-link></li>
        </ul>
      </div>      
    </div>
  </nav>
</template>

<script>
export default {
  name: "BlogsNavbar",
};
</script>

<style>
</style>
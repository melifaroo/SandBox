<template>
  <nav class="navbar navbar-expand navbar-dark bg-dark" style="position: sticky; top: 0; z-index: 10;">
    <div class="container-fluid">
      <div class="navbar-header">
        <a class="navbar-brand" href="/">Sandbox</a>
      </div>

      <button class="navbar-toggler" type="button" data-toggle="collapse" aria-expanded="false" aria-label="Toggle navigation" >
        <span class="navbar-toggler-icon"></span>
      </button>

      <div class="collapse navbar-collapse" id="navbar">
        <ul class="nav navbar-nav mr-auto">
          <li class="nav-item"><a class="nav-link" href="/">Home <span class="sr-only">(current)</span></a></li>   
          <li class="nav-item"><a class="nav-link" href="/Blogs">Blogs</a></li>
          <li class="nav-item"><a class="nav-link" href="/Library">Library</a></li>       
          <li class="nav-item"><a class="nav-link" href="/About">About</a></li>
        </ul>
        
        <ul class="nav navbar-nav ml-auto">
          <li class="nav-item"><label class="navbar-brand">Util : </label></li>
          <li class="nav-item"><a class="nav-link " href="/DBSeed">Seed DB</a></li>
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
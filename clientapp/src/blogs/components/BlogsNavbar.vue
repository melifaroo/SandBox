<template>
  <nav class="navbar navbar-expand navbar-blue bg-light" style="position: sticky; top: 64px; z-index: 10;">
    <div class="container-fluid" style="margin-left:130px">
        <span ></span>
      <div class="navbar-header">
        <a class="navbar-brand" href="/Blogs">BlogsApp</a>
      </div>

      <button class="navbar-toggler" type="button" data-toggle="collapse" aria-expanded="false" aria-label="Toggle navigation" >
        <span class="navbar-toggler-icon">|||</span>
      </button>

      <div class="collapse navbar-collapse" id="navbar">
        <ul class="nav navbar-nav mr-auto">
          <li class="nav-item"><a class="nav-link" href="/Blogs">Blogs<span class="sr-only">(current)</span></a></li>
          <li class="nav-item"><a class="nav-link" href="/Blogs/Bloggers">Bloggers</a></li>       
          <li class="nav-item"><a class="nav-link" href="/Blogs/Posts">Posts</a></li>
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
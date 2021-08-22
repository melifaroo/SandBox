<template>
  <nav class="navbar navbar-expand navbar-dark bg-dark">
    <div class="container-fluid">
      <div class="navbar-header">
        <a class="navbar-brand" href="/">WordsApp Client</a>
      </div>

      <button class="navbar-toggler" type="button" data-toggle="collapse" aria-expanded="false" aria-label="Toggle navigation" >
        <span class="navbar-toggler-icon">|||</span>
      </button>

      <div class="collapse navbar-collapse" id="navbar">
        <ul class="nav navbar-nav mr-auto">
          <li class="nav-item"><a class="nav-link" href="/">Home <span class="sr-only">(current)</span></a></li>          
          <li class="nav-item dropdown">
            <a class="nav-link dropdown-toggle" data-toggle="dropdown" href="#">Data</a>
            <ul class="dropdown-menu bg-dark">
              <li><a class="nav-link " href="/Words">Words</a></li>
              <li><a class="nav-link" href="/Countries">Countries</a></li>
              <li><a class="nav-link" href="/Languages">Languages</a></li>
            </ul>
          </li>
          <li class="nav-item"><a class="nav-link" href="/About">About</a></li>
        </ul>
        
        <ul class="nav navbar-nav ml-auto">
          <li class="nav-item me-auto"><label class="navbar-brand">Sandbox : </label></li>
          <!--li class="nav-item dropdown me-auto">
            <a class="nav-link dropdown-toggle" data-toggle="dropdown" href="#">Library</a>
            <ul class="dropdown-menu dropdown-menu-end bg-dark">
              <li><a class="nav-link " href="/Sandbox/Library/Readers">Readers</a></li>
              <li><a class="nav-link " href="/Sandbox/Library/Authors">Authors</a></li>
              <li><a class="nav-link " href="/Sandbox/Library/Books">Books</a></li>
              <li><a class="nav-link " href="/Sandbox/Library/Borrowings">Borrowing</a></li>
            </ul>
          </li-->
          <li class="nav-item dropdown me-auto">
            <a class="nav-link dropdown-toggle" data-toggle="dropdown" href="#">some kind of Blogs</a>
            <ul class="dropdown-menu dropdown-menu-end bg-dark">
              <li><a class="nav-link " href="/Sandbox/Blogging/Bloggers">Bloggers</a></li>
              <li><a class="nav-link " href="/Sandbox/Blogging/Posts">Posts</a></li>
              <li><a class="nav-link " href="/Sandbox/Blogging/Blogs">Blogs</a></li>
              <li><a class="nav-link " href="/Sandbox/Blogging/DBSeed">DB seed</a></li>
            </ul>
          </li>
        </ul>
        <!--form class="form-inline my-2 my-md-0">
          <input class="form-control" type="text" placeholder="Search" />
        </form-->
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
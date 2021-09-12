<template>
  <div class="Storage">      
    <p>
        <nav class="navbar navbar-expand navbar-light bg-light" style="position: sticky; top: 84px; z-index: 10;">
            <div class="container-fluid">     
                <div class="navbar-header">
                    <router-link class="navbar-brand" :to="'/Library/Storage'">Storage</router-link>
                </div>               
                <ul class="nav navbar-nav mr-auto">
                <li class="nav-item">
                    <router-link class="nav-link" :to="'/Library/Storage'">Books</router-link> 
                </li>
                <li class="nav-item">
                    <router-link class="nav-link" :to="'/Library/Storage/Authors'">Authors</router-link>       
                </li>
                </ul> 
            </div>            
        </nav>
    </p>
    <router-view />
  </div>
</template>

<script>
    export default {};
</script>
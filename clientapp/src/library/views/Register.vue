<template>
  <div class="Register">      
    <p>
        <nav class="navbar navbar-expand navbar-light bg-light" style="position: sticky; top: 84px; z-index: 10;">
            <div class="container-fluid">     
                <div class="navbar-header">
                    <router-link class="navbar-brand" :to="'/Library/Register'">Register</router-link>
                </div>               
                <ul class="nav navbar-nav mr-auto">
                <li class="nav-item">
                    <router-link class="nav-link" :to="'/Library/Register'">Borrowings</router-link> 
                </li>
                <li class="nav-item">
                    <router-link class="nav-link" :to="'/Library/Register/Readers'">Readers</router-link>       
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
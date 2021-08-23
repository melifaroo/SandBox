<template>
  <div class="home">
    <h1><p><img alt="Dot Net logo" src="../assets/NET_Core_Logo.png" > + <img alt="Vue logo" src="../assets/logo.png" ></p></h1>
    <Startpage msg="Welcome"/>
    <h2><a href="/sandbox/blogging/blogs"> Blogs simulation, demo app: DotNet Core WebAPI (EFCore+SQL) + Vue </a></h2>
  </div>
</template>

<script>
// @ is an alias to /src
    import Startpage from '@/components/Startpage.vue'

export default {
  name: 'Home',
  components: {
      Startpage
  }
}
</script>

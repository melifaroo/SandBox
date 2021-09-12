<template>
  <div class="home">
    <h1><p><img alt="Dot Net logo" src="../assets/dotnetcorelogo.png" > + <img alt="Vue logo" src="../assets/vuelogo.png" ></p></h1>
    <Startpage msg="Welcome"/>
    <h2><a href="/blogs"> Blogs imitation: DotNet Core WebAPI (EFCore SQL) + Vue </a></h2>
    <h2><a href="/library"> Library manager: DotNet Core WebAPI (ADONet SQL) + Vue </a></h2>
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

<template>
  <div class="Vlogs">
    <h1>Blogs ({{blogs.length}})</h1>
    <form>
    <div class="form-switch">
      <input class="form-check-input" type="checkbox" id="flexSwitchCheckDefault" v-model="layout" >
      <label class="form-check-label" for="flexSwitchCheckDefault">Enable cards layout</label>
    </div>
    </form>
    <!--a class="btn btn-link" :click="viewlayout = 'cards'" href=#>Cards</a> | <a class="btn btn-link" :click="viewlayout = 'list'" href=#>List</a--> 
    <div v-if="layout">
      <blogscards :blogs="blogs" />
    </div>
    <div v-else>
      <blogslist :blogs="blogs" />
    </div>
    <a class="btn btn-success" href="/sandbox/blogging/addblogger">Add new blog</a>      
    <!--a class="btn btn-success" href="/addblog">Create new blog</a-->
  </div>
</template>


<script>
import blogslist from "../../components/BlogsList.vue"
import blogscards from "../../components/BlogsCards.vue"

export default {
  data() {
    return {
      blogs: [],
      layout : true,
    };
  },
  created() {
      this.getBlogs();      
  },
  components :{
     blogslist,
     blogscards
  },
  methods: {
    getBlogs() {
        fetch("https://localhost:5001/sandbox/blogging/blogs")
          .then(async (response) => {
            const data = await response.json();
            if (!response.ok) {
              // get error message from body or default to response statusText
              const error = (data && data.message) || response.statusText;
              return Promise.reject(error);
            }
            this.blogs = data;
          })
          .catch((error) => console.log(error));
    }
  },
};
</script>

<template>
  <div class="blogPostForm">
    <h1>Create new post</h1>
    <div class="container">
      <form @submit.prevent="createPost">
            <div class="input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text" >Blog</span>
                </div>   
                <select class="form-control" disabled name="blogs" id="blogs" v-model="Post.blogId">
                    <option value="">Choose blog</option>
                    <option v-for="blog of blogs" :key="blog.blogId" :value="blog.blogId">
                        {{ blog.url }}
                    </option>
                </select>
            </div>
            <div class="input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text" >Blogger</span>
                </div>   
                <select class="form-control" required name="bloggers" id="bloggers" v-model="Post.bloggerId">
                    <option value="">Choose blogger</option>
                    <option v-for="blogger of bloggers" :key="blogger.bloggerId" :value="blogger.bloggerId">
                        {{ blogger.nickName }}
                    </option>
                </select>
            </div>
            <div class="input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text" >Title</span>
                </div>           
                <input required type="text" class="form-control" id="title"  v-model="Post.title" placeholder="Enter post title" /> 
            </div>
            <div class="input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text" >Content</span>
                </div>              
                <textarea type="text" class="form-control" id="content" rows="4" cols="50" v-model="Post.content" placeholder="Enter post" /> 
            </div>
            
        <ul>
          <a class="btn btn-secondary" :href="'/blogs/'+this.$route.params.id">Back to {{ Blog.url }} </a>
          <button type="submit" class="btn btn-success">Save</button>
        </ul>
      </form>
    </div>
  </div>
</template>

<script>
import bloggingService from '..'

export default {
  name: "BlogPostForm",
  data() {
    return {
      Post: {
        postId: undefined,
        title: "",
        content: "",
        bloggerId: "",
        blogId: this.$route.params.id,
      },
      Blog: {
        url : "",
        blogId: this.$route.params.id,          
      },
      bloggers: [],
      blogs: []
    };
  },
  created (){
    if ("id" in this.$route.params) {
        bloggingService.getBlogById(this.$route.params.id).then( result => this.Blog = result ).catch( error => console.log(error) );
    }    
    bloggingService.getBlogs().then(result => this.blogs = result).catch((error) => console.log(error)); 
    bloggingService.getBloggers().then( result => this.bloggers = result ).catch( error => console.log(error) );     
  },
  methods: {   
    async createPost() {
      await bloggingService.createPost(this.Post).then( this.$router.push("/blogs/"+this.$route.params.id) ).catch( error => console.log(error) );
    }
  },
};
</script>
  

<style scoped>

    .blogPostForm .input-group-prepend 
    {
        min-width: 200px;
    }
    .blogPostForm .input-group-text
    {
        width: 100%;
    }

</style>
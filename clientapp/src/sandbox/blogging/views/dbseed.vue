<template>
  <div class="blogging">
    <ul>
      <form @submit.prevent="seedDB">
        <div class="form-row">
            <div class="form-group col-md-3">
                <label>Bloggers count</label>
                <input type="number" min="0" max="30" class="form-control"  id="bloggerCount"  v-model="bloggerCount" placeholder="Enter count of bloggers to seed" />
            </div>
            <div class="form-group col-md-3">
                <label>Posts count</label>
                <input type="number" min="0" max="30" class="form-control"  id="postCount"  v-model="postCount" placeholder="Enter count of posts to seed" />
            </div>
            <div class="form-group col-md-3">
                <label>Blogs count</label>
                <input type="number" min="0" max="10" class="form-control"  id="blogCount"  v-model="blogCount" placeholder="Enter count of blogs to seed" />
            </div>
        </div>
        <ul>
            <a class="btn btn-secondary" onclick="history.back()">Return</a>
            <button class="btn btn-success" type="submit" >Seed</button>
            <a class="btn btn-danger" style="color: yellow;" @click="clearDB">Clear DB</a>
        </ul>
      </form>
      
        <ul>            
            <label>{{result}}</label>
        </ul>
    </ul>
  </div>
</template>

<script>
export default {
  name: "DBSeed",
  data() {
    return {
      bloggerCount : 0,
      postCount : 0,
      blogCount : 0,
      result : "",
    };
  },
  components: {
  },
  methods: {
      async seedDB(){
          
        let response = await fetch("https://localhost:5001/sandbox/blogging/blogs/seed?blogCount=" + this.blogCount +"&bloggerCount=" +this.bloggerCount+ "&postCount=" + this.postCount, { method: "POST" });
        
        if (!response.ok) {
            const error =  response.statusText;
            return Promise.reject(error);
        }
        
        this.bloggerCount= 0;
        this.postCount = 0;
        this.blogCount = 0;
        this.result = response.statusText;
      },

  },
};
</script>
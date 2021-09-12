var bloggingService = {
    baseUrl : "https://localhost:5001",

    async getBloggerById(id) {
        let response = await fetch(this.baseUrl + "/api/blogs/bloggers/" + id);
        return this.process(response);
    },

    async getBlogById(id) {
        let response = await fetch(this.baseUrl + "/api/blogs/" + id);
        return this.process(response);
    },

    async getPostById(id) {
        let response = await fetch(this.baseUrl + "/api/blogs/posts/" + id);
        return this.process(response);
    },

    async getBloggerPostsCount(id) {
        let response = await fetch(this.baseUrl + "/api/blogs/bloggers/" + id + "/postsCount");
        return this.process(response);
    },

    async getBloggerBlogsCount(id) {
        let response = await fetch(this.baseUrl + "/api/blogs/bloggers/" + id + "/blogsCount");
        return this.process(response);
    },

    async getBlogPostsCount(id) {
        let response = await fetch(this.baseUrl + "/api/blogs/" + id + "/postsCount");
        return this.process(response);
    },

    async getBlogAuthorsCount(id) {
        let response = await fetch(this.baseUrl + "/api/blogs/" + id + "/authorsCount");
        return this.process(response);
    },

    async getBloggers() {
        let response = await fetch(this.baseUrl + "/api/blogs/bloggers");
        return this.process(response);
    },

    async deleteBlogger(id) {
        await fetch(this.baseUrl + "/api/blogs/bloggers/delete/" + id, { method: "POST" });
    },

    async createOrUpdateBlogger(Blogger) {
        var url = this.baseUrl + "/api/blogs/bloggers/";
        if (Blogger.bloggerId!=undefined) {
          url = url + "edit/" + Blogger.bloggerId;
        } else {
          url = url + "create"
        }
        const requestOptions = {
          method: "POST",
          body: JSON.stringify( Blogger ),
          headers: { "Content-Type": "application/json" },
        };
        let response = await fetch(url, requestOptions);
        return this.process(response);
      },
      
    async deleteBlog(id) {
        await fetch(this.baseUrl + "/api/blogs/delete/" + id, { method: "POST" });
        //return this.process(response);
    },

    async createOrUpdateBlog(Blog) {
        var url = this.baseUrl + "/api/blogs/";
        if (Blog.blogId!=undefined) {
          url = url + "edit/" + Blog.blogId;
        } else {
          url = url + "create"
        }
        const requestOptions = {
          method: "POST",
          body: JSON.stringify( Blog ),
          headers: { "Content-Type": "application/json" },
        };
        let response = await fetch(url, requestOptions);
        return this.process(response);
      },
      
    async deletePost(id) {
        return await fetch(this.baseUrl + "/api/blogs/posts/delete/" + id, { method: "POST" });
    },
    
    async updatePost(Post) {
        var url = this.baseUrl + "/api/blogs/posts/edit/" + Post.postId;
        const requestOptions = {
          method: "POST",
          body: JSON.stringify( Post ),
          headers: { "Content-Type": "application/json" },
        };
        let response = await fetch(url, requestOptions);
        return this.process(response);
      },
      
    async createPost(Post) {
        var url = this.baseUrl + "/api/blogs/posts/create";
        const requestOptions = {
          method: "POST",
          body: JSON.stringify( Post ),
          headers: { "Content-Type": "application/json" },
        };
        let response = await fetch(url, requestOptions);
        return this.process(response);
      },

      async getBlogPosts(id) {
        let response = await fetch(this.baseUrl + "/api/blogs/"+id+"/posts");
        return this.process(response);
      },

      async getBloggerBlogs(id) {
        let response = await fetch(this.baseUrl + "/api/blogs/bloggers/"+id+"/blogs");
        return this.process(response);
      },

      async getBloggerPosts(id) {
        let response = await fetch(this.baseUrl + "/api/blogs/bloggers/"+id+"/posts");
        return this.process(response);
      },


    async getBlogs() {
        let response = await fetch(this.baseUrl + "/api/blogs");
        return this.process(response);
    },

    async getPosts() {
        let response = await fetch(this.baseUrl + "/api/blogs/posts");
        return this.process(response);
    },

    async seedSandBoxDB(blogCount, bloggerCount, postCount) {
        let response = await fetch(this.baseUrl + "/api/blogs/seed?blogCount=" + blogCount +"&bloggerCount=" +bloggerCount+ "&postCount=" + postCount, { method: "POST" });
        return response;
    },

    async process(response){
        if (!response.ok) {
            return Promise.reject(response.statusText);
        }
        return await response.json();
    }

}


export default bloggingService;
var bloggingService = {
    baseUrl : "https://localhost:5001/api",

    async getBloggerById(id) {
        let response = await fetch(this.baseUrl + "/sandbox/blogging/bloggers/" + id);
        return this.process(response);
    },

    async getBlogById(id) {
        let response = await fetch(this.baseUrl + "/sandbox/blogging/blogs/" + id);
        return this.process(response);
    },

    async getPostById(id) {
        let response = await fetch(this.baseUrl + "/sandbox/blogging/posts/" + id);
        return this.process(response);
    },

    async getBloggerPostsCount(id) {
        let response = await fetch(this.baseUrl + "/sandbox/blogging/bloggers/" + id + "/postsCount");
        return this.process(response);
    },

    async getBloggerBlogsCount(id) {
        let response = await fetch(this.baseUrl + "/sandbox/blogging/bloggers/" + id + "/blogsCount");
        return this.process(response);
    },

    async getBlogPostsCount(id) {
        let response = await fetch(this.baseUrl + "/sandbox/blogging/blogs/" + id + "/postsCount");
        return this.process(response);
    },

    async getBlogAuthorsCount(id) {
        let response = await fetch(this.baseUrl + "/sandbox/blogging/blogs/" + id + "/authorsCount");
        return this.process(response);
    },

    async getBloggers() {
        let response = await fetch(this.baseUrl + "/sandbox/blogging/bloggers");
        return this.process(response);
    },

    async deleteBlogger(id) {
        let response = await fetch(this.baseUrl + "/sandbox/blogging/bloggers/delete/" + id, { method: "POST" });
        return this.process(response);
    },

    async createOrUpdateBlogger(Blogger) {
        var url = this.baseUrl + "/sandbox/blogging/bloggers/";
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
        let response = await fetch(this.baseUrl + "/sandbox/blogging/blogs/delete/" + id, { method: "POST" });
        return this.process(response);
    },

    async createOrUpdateBlog(Blog) {
        var url = this.baseUrl + "/sandbox/blogging/blogs/";
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
        let response = await fetch(this.baseUrl + "/sandbox/blogging/posts/delete/" + id, { method: "POST" });
        return this.process(response);
    },
    
    async updatePost(Post) {
        var url = this.baseUrl + "/sandbox/blogging/posts/edit/" + Post.postId;
        const requestOptions = {
          method: "POST",
          body: JSON.stringify( Post ),
          headers: { "Content-Type": "application/json" },
        };
        let response = await fetch(url, requestOptions);
        return this.process(response);
      },
      
    async createPost(Post) {
        var url = this.baseUrl + "/sandbox/blogging/posts/create";
        const requestOptions = {
          method: "POST",
          body: JSON.stringify( Post ),
          headers: { "Content-Type": "application/json" },
        };
        let response = await fetch(url, requestOptions);
        return this.process(response);
      },

      async getBlogPosts(id) {
        let response = await fetch(this.baseUrl + "/sandbox/blogging/blogs/"+id+"/posts");
        return this.process(response);
      },

      async getBloggerBlogs(id) {
        let response = await fetch(this.baseUrl + "/sandbox/blogging/bloggers/"+id+"/blogs");
        return this.process(response);
      },

      async getBloggerPosts(id) {
        let response = await fetch(this.baseUrl + "/sandbox/blogging/bloggers/"+id+"/posts");
        return this.process(response);
      },


    async getBlogs() {
        let response = await fetch(this.baseUrl + "/sandbox/blogging/blogs");
        return this.process(response);
    },

    async getPosts() {
        let response = await fetch(this.baseUrl + "/sandbox/blogging/posts");
        return this.process(response);
    },

    async seedSandBoxDB(blogCount, bloggerCount, postCount) {
        let response = await fetch(this.baseUrl + "/sandbox/blogging/blogs/seed?blogCount=" + blogCount +"&bloggerCount=" +bloggerCount+ "&postCount=" + postCount, { method: "POST" });
        return response;
    },

    process(response){
        const data = response.json();
        if (!response.ok) {
            const error = (data && data.message) || response.statusText;
            return Promise.reject(error);
        }
        return data;
    }

}


export default bloggingService;
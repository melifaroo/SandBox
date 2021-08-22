var bloggingService = {
    async getBloggerById(id) {
        let response = await fetch("https://localhost:5001/sandbox/blogging/bloggers/" + id);
        return this.process(response);
    },

    async getBlogById(id) {
        let response = await fetch("https://localhost:5001/sandbox/blogging/blogs/" + id);
        return this.process(response);
    },

    async getBloggerPostsCount(id) {
        let response = await fetch("https://localhost:5001/sandbox/blogging/bloggers/" + id + "/postsCount");
        return this.process(response);
    },

    async getBloggerBlogsCount(id) {
        let response = await fetch("https://localhost:5001/sandbox/blogging/bloggers/" + id + "/blogsCount");
        return this.process(response);
    },

    async getBlogPostsCount(id) {
        let response = await fetch("https://localhost:5001/sandbox/blogging/blogs/" + id + "/postsCount");
        return this.process(response);
    },

    async getBlogAuthorsCount(id) {
        let response = await fetch("https://localhost:5001/sandbox/blogging/blogs/" + id + "/authorsCount");
        return this.process(response);
    },

    async getBloggers() {
        let response = await fetch("https://localhost:5001/sandbox/blogging/bloggers");
        return this.process(response);
    },

    async deleteBlogger(id) {
        let response = await fetch("https://localhost:5001/sandbox/blogging/bloggers/delete/" + id, { method: "POST" });
        return this.process(response);
    },

    async createOrUpdateBlogger(Blogger) {
        var url = "https://localhost:5001/sandbox/blogging/bloggers/";
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
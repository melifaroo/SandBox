var libraryService = {
    baseUrl : "https://localhost:5001",

    async getStorage() {
        let response = await fetch(this.baseUrl + "/api/library/storage");
        return this.process(response);
    },
    async getRegister() {
        let response = await fetch(this.baseUrl + "/api/library/register");
        return this.process(response);
    },
    
    async getAuthors() {
        let response = await fetch(this.baseUrl + "/api/library/authors");
        return this.process(response);
    },
    
    async getReaders() {
        let response = await fetch(this.baseUrl + "/api/library/readers");
        return this.process(response);
    },

    async getBooksReaderView() {
        let response = await fetch(this.baseUrl + "/api/library/books");
        return this.process(response);
    },

    async seedSandBoxDB() {
        let response = await fetch(this.baseUrl + "/api/library/seed", { method: "POST" });
        return response;
    },

    async process(response){
        if (!response.ok) {
            return Promise.reject(response.statusText);
        }
        return await response.json();
    }

}


export default libraryService;
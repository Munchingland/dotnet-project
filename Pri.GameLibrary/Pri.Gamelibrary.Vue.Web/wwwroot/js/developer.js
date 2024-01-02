let app = new Vue({
    el: "#developer",
    data: {
        baseUrl: "https://localhost:7056/api",
        loading: false,
        developers: [],
        errorMessage: "",
        hasError: false,
        developersVisible: false,
    },
    methods: {
        showDevelopers: async function () {
            this.loading = true;
            this.developers = await axios.get(`${this.baseUrl}/Developers`)
                .then(response => response.data.items)
                .catch(error => {
                    if (error.response.status == 404) {
                        this.errorMessage = "endpoint not found";
                    }
                    this.hasError = true;
                });
            this.developersVisible = true;
            this.loading = false;
        },
    },
});

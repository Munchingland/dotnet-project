let app = new Vue({
    el: "#app",
    data: {
        baseUrl: "https://localhost:7056/api",
        loading: false,
        games: [],
        errorMessage: "",
        hasError: false,
        gamesVisible: false,
    },
    methods: {
        showGames: async function () {
            this.loading = true;
            this.games = await axios.get(`${this.baseUrl}/Games`)
                .then(response => response.data.items)
                .catch(error => {
                    if (error.response.status == 404) {
                        this.errorMessage = "endpoint not found";
                    }
                    this.hasError = true;
                });
            this.gamesVisible = true;
            this.loading = false;
        },
    },
});

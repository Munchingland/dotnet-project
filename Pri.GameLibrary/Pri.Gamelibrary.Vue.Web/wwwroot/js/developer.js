let app = new Vue({
    el: "#developer",
    data: {
        loading: false,
        developers: [],
        errorMessage: "",
        hasError: false,
        developersVisible: false,

        games: [],
        gamesVisible: false,
    },
    mounted: async function () {
        await this.showDevelopers();
        consol.log("hi");
    },
    methods: {
        showDevelopers: async function () {
            this.loading = true;
            this.gamesVisible = false;
            this.developers = await axios.get(`${baseUrl}/Developers`)
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
        showGamesByDeveloper: async function (developer) {
            this.loading = true;
            this.developers = [];
            this.developers.push(developer);
            this.games = await axios.get(`${baseUrl}/Games/developer/${developer.id}`)
                .then(response => response.data.items)
                .catch(error => {
                    if (error.response.status == 404) {
                        this.errorMessage = "endpoint not found";
                    }
                    this.hasError = true;
                });
            this.gamesVisible = true;
            this.loading = false;
        }
    },
});

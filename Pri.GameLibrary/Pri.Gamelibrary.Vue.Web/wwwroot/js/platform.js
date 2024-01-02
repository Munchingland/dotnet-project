let app = new Vue({
    el: "#platform",
    data: {
        baseUrl: "https://localhost:7056/api",
        loading: false,
        platforms: [],
        errorMessage: "",
        hasError: false,
        platformsVisible: false,
        gamesVisible: false,
        games : [],
    },
    methods: {
        showPlatforms: async function () {
            this.loading = true;
            this.platforms = await axios.get(`${this.baseUrl}/Platforms`)
                .then(response => response.data.items)
                .catch(error => {
                    if (error.response.status == 404) {
                        this.errorMessage = "endpoint not found";
                    }
                    this.hasError = true;
                });
            this.platformsVisible = true;
            this.loading = false;
        },
        showGamesOnPlatform: async function (platform) {
            this.loading = true;
            this.platforms = [];
            this.platforms.push(platform);
            this.games = await axios.get(`${this.baseUrl}/Games/platform/${platform.id}`)
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

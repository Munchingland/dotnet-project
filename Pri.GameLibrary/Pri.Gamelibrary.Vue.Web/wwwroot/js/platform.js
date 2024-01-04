let app = new Vue({
    el: "#platform",
    data: {
        loading: false,
        platforms: [],
        errorMessage: "",
        hasError: false,
        platformsVisible: false,

        gamesVisible: false,
        games : [],
    },
    mounted: async function () {
        await this.showPlatforms();
    },
    methods: {
        showPlatforms: async function () {
            this.loading = true;
            this.gamesVisible = false;
            this.platforms = await axios.get(`${baseUrl}/Platforms`)
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
            this.games = await axios.get(`${baseUrl}/Games/platform/${platform.id}`)
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

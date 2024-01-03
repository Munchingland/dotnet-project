let app = new Vue({
    el: "#app",
    data: {
        baseUrl: "https://localhost:7056/api",
        loading: false,
        games: [],
        errorMessage: "",
        hasError: false,
        gamesVisible: false,
        reviews: [],
        reviewsVisible: false,
        gameName: ""
    },
    methods: {
        showGames: async function () {
            this.loading = true;
            this.reviewsVisible = false;
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
        showReviews: async function (game) {
            this.loading = true;
            this.games = [];
            this.gameName = game.name;
            this.games.push(game);
            this.reviews = await axios.get(`${this.baseUrl}/Reviews/${game.id}`)
                .then(response => response.data.items)
                .catch(error => {
                    if (error.response.status == 404) {
                        this.errorMessage = "endpoint not found";
                    }
                    this.hasError = true;
                })
            this.reviewsVisible = true;
            this.loading = false;
        }
    },
});

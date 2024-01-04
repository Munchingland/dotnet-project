let gameLibrary = new Vue({
    el: "#games",
    data: {
        loading: false,
        games: [],
        errorMessage: "",
        hasError: false,
        gamesVisible: false,
        reviews: [],
        reviewsVisible: false,
        gameName: "",
        userId: "",

        userGamesLoaded: false,
    },

    mounted: async function () {
        if (sessionStorage.getItem("token")) {
            await this.showGamesOwnedByUser();
        }
        else {
            await this.showGames();
        }

    },

    methods: {
        showGamesNotOwnedByUser: async function () {
            if (sessionStorage.getItem("token")) {
                this.userId = readUserIdFromToken();
                this.loading = true;
                this.reviewsVisible = false;

                this.games = await axios.get(`${baseUrl}/games/NotUser/${this.userId}`)
                    .then(response => response.data.items)
                    .catch(error => {
                        if (error.response.status == 404) {
                            this.errorMessage = "endpoint not found";
                        }
                        this.hasError = true;
                    });
                this.userGamesLoaded = false;
                this.gamesVisible = true;
                this.loading = false;


            }
            else {
                this.errorMessage = "Please login before seeing library";
            }
        },
        showGamesOwnedByUser: async function () {
            if (sessionStorage.getItem("token")) {
                this.userId = readUserIdFromToken();
                this.loading = true;
                this.reviewsVisible = false;

                this.games = await axios.get(`${baseUrl}/games/user/${this.userId}`)
                    .then(response => response.data.items)
                    .catch(error => {
                        if (error.response.status == 404) {
                            this.errorMessage = "endpoint not found";
                        }
                        this.hasError = true;
                    });
                this.userGamesLoaded = true;
                this.gamesVisible = true;
                this.loading = false;


            }
            else {
                this.errorMessage = "Please login before seeing library";
            }
        },
    },
});
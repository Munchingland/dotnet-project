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

        libraryAddModel:{
            gameId: "",
            userId: ""
        },

        userGamesLoaded: false,
    },

    mounted: async function () {
        await this.showGamesOwnedByUser();

    },

    methods: {
        showGamesNotOwnedByUser: async function () {
            if (sessionStorage.getItem("token")) {
                this.setDataWhenStartingFunction();

                this.games = await axios.get(`${baseUrl}/library/NotUser/${this.userId}`)
                    .then(response => response.data.items)
                    .catch(error => {
                        if (error.response.status == 404) {
                            this.errorMessage = "endpoint not found";
                        }
                        this.hasError = true;
                    });
                this.userGamesLoaded = false;

                this.setDataWhenFinishingFunction();
            }
            else {
                this.setErrorMessageNotLoggedIn();
            }
        },
        showGamesOwnedByUser: async function () {
            if (sessionStorage.getItem("token")) {
                this.setDataWhenStartingFunction();

                this.games = await axios.get(`${baseUrl}/library/user/${this.userId}`)
                    .then(response => response.data.items)
                    .catch(error => {
                        if (error.response.status == 404) {
                            this.errorMessage = "endpoint not found";
                        }
                        this.hasError = true;
                    });
                this.userGamesLoaded = true;

                this.setDataWhenFinishingFunction();
            }
            else {
                this.setErrorMessageNotLoggedIn();
            }
        },
        addToLibrary: async function (game) {
            if (sessionStorage.getItem("token")) {
                this.setDataWhenStartingFunction();
                this.libraryAddModel.userId = this.userId;
                this.libraryAddModel.gameId = game.id;

                await axios.post(`${baseUrl}/library`, this.libraryAddModel)
                    .catch(error => {
                        if (error.response.status == 404) {
                            this.errorMessage = "endpoint not found";
                        }
                        this.hasError = true;
                    });

                await this.showGamesNotOwnedByUser();
            }
            else {
                this.setErrorMessageNotLoggedIn();
            }
        },
        removeFromLibrary: async function (game) {
            if (sessionStorage.getItem("token")) {
                this.setDataWhenStartingFunction();

                await axios.delete(`${baseUrl}/library/${this.userId}/${game.id}`)
                    .catch(error => {
                        if (error.response.status == 404) {
                            this.errorMessage = "endpoint not found";
                        }
                        this.hasError = true;
                    });


                await this.showGamesOwnedByUser();
            }
            else {
                this.setErrorMessageNotLoggedIn();
            }
        },
        setDataWhenStartingFunction: function () {
            this.userId = readUserIdFromToken();
            this.loading = true;
            this.reviewsVisible = false;
        },
        setDataWhenFinishingFunction: function () {
            this.gamesVisible = true;
            this.loading = false;
        },

        setErrorMessageNotLoggedIn: function () {
            this.errorMessage = "Please login before seeing library";
        },
    },
});
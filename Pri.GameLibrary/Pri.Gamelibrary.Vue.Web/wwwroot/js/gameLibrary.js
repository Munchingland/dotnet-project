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

        reviews: [],
        reviewsVisible: false,

        libraryAddModel: {
            gameId: "",
            userId: ""
        },

        newReviewModel: {
            gameId: "",
            userId: "",
            score: 0,
            description: "",
        },

        updateReviewModel: {
            reviewId: 0,
            score: 0,
            description: "",
        },

        selectedGame: {},
        selectedReviewId : 0,

        scores: [
            0,
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10
        ],

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

        updateReview: async function () {
            this.updateReviewModel.description.trim();
            this.loading = true;
            await axios.put(`${baseUrl}/Reviews`, this.updateReviewModel, axiosConfig)
                .then(response => response.data)
                .catch(error => {
                    this.error = true;
                    this.errorMessage = error.message;
                })
                .finally(() => {
                    this.loading = false;
                });
            $('#updateReviewModal').modal('hide');
            this.resetReviewModels();
            this.selectedGame = {};
            this.showGamesOwnedByUser();
        },

        createReview: async function () {
            this.newReviewModel.description.trim();
            this.fillReviewModelWithUserId();
            this.loading = true;
            await axios.post(`${baseUrl}/Reviews`, this.newReviewModel, axiosConfig)
                .then(response => response.data)
                .catch(error => {
                    this.error = true;
                    this.errorMessage = error.message;
                })
                .finally(() => {
                    this.loading = false;
                });
            $('#createReviewModal').modal('hide');
            this.resetReviewModels();
            this.selectedGame = {};
            this.showGamesOwnedByUser();
        },

        showReviews: async function (game) {
            this.loading = true;
            this.games = [];
            this.gameName = game.name;
            this.games.push(game);
            this.reviews = await axios.get(`${baseUrl}/Reviews/${game.id}`)
                .then(response => response.data.items)
                .catch(error => {
                    if (error.response.status == 404) {
                        this.errorMessage = "endpoint not found";
                    }
                    this.hasError = true;
                });
            this.reviewsVisible = true;
            this.loading = false;
        },

        deleteReview: async function (selectedReviewId) {
            this.isLoading = true;
            await axios.delete(`${baseUrl}/Reviews/${selectedReviewId}`, axiosConfig).catch((e) => {
                if (e.response.status === 400) {
                    console.log(e.response.data[0].errorMessage);
                    this.errorMessage = e.response.data[0].errorMessage;
                }
                else {
                    this.errorMessage = e.message;
                }
            });
            $('#deleteReviewConfirmModal').modal('hide');
            this.selectedGame = {};
            this.selectedReviewId = 0;
            this.showGamesOwnedByUser();
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

        showCreateModal: function (game) {
            $('#createReviewModal').modal('show');
            this.newReviewModel.gameId = game.id;
            this.selectedGame = game;
        },

        showUpdateModal: function (game) {
            $('#updateReviewModal').modal('show');
            this.selectedGame = game;
            this.updateReviewModel.reviewId = game.reviewId;
            this.updateReviewModel.description = game.description;
            this.updateReviewModel.score = game.averageReview;
        },

        showDeleteModal: function (game) {
            $('#deleteReviewConfirmModal').modal('show');
            this.selectedGame = game;
            this.selectedReviewId = game.reviewId;
        },

        cancelReviewAction: function () {
            this.resetReviewModels();
        },

        resetReviewModels: function () {
            this.newReviewModel = {
                gameId: "",
                userId: "",
                score: 0,
                description: "",
            };
            this.updateReviewModel = { 
                    reviewId: 0,
                    score: 0,
                    description: "",
            }
        },

        fillReviewModelWithUserId: function () {
            this.newReviewModel.userId = this.userId;
        }

    },
});
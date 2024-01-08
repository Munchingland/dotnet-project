let game = new Vue({
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

        developers: [],
        platforms: [],

        newGameModel: {
            name: "",
            developerId: 0,
            platformIds: [],
            releaseDate: new Date(),
        },

        updateGameModel: {
            gameId : 0,
            name: "",
            developerId: 0,
            platformIds: [],
            releaseDate: new Date(),
        },

    },

    mounted: async function () {
        await this.showGames();
    },

    methods: {
        showGames: async function () {
            this.loading = true;
            this.reviewsVisible = false;

            this.games = await axios.get(`${baseUrl}/games`)
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

        createGame: async function () {
            this.newGameModel.name.trim();
            this.loading = true;
            await axios.post(`${baseUrl}/games`, this.newGameModel, axiosConfig)
                .then(response => response.data)
                .catch(error => {
                    this.errorMessage = error.message;
                    if (error.response.status == 401) {
                        this.errorMessage = "You do not have the rights to add an item";
                    }
                    this.error = true;
                    
                })
                .finally(() => {
                    this.loading = false;
                });
            $('#createGameModal').modal('hide');
            this.resetModels();
            this.showGames();
        },

        showCreateModal : async function () {
            $('#createGameModal').modal('show');

            await this.loadDevelopersAndPlatforms();
        },


        loadDevelopersAndPlatforms: async function () {
            this.developers = await axios.get(`${baseUrl}/Developers`)
                .then(response => response.data.items)
                .catch(error => {
                    if (error.response.status == 404) {
                        this.errorMessage = "endpoint not found";
                    }
                    this.hasError = true;
                });
            this.platforms = await axios.get(`${baseUrl}/Platforms`)
                .then(response => response.data.items)
                .catch(error => {
                    if (error.response.status == 404) {
                        this.errorMessage = "endpoint not found";
                    }
                    this.hasError = true;
                });
        },

        cancelGameAction: function () {
            this.resetModels();
        },


        resetModels: function () {
            this.newGameModel = {
                name: "",
                developerId: 0,
                platformIds: [],
                releaseDate: new Date(),
            };

            this.updateGameModel = {
                gameId: 0,
                name: "",
                developerId: 0,
                platformIds: [],
                releaseDate: new Date(),
            };

        }
    },
});

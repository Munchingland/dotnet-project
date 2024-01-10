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

        gamePage: true,

        isAdmin: false,

        developers: [],
        platforms: [],

        newGameModel: {
            name: "",
            developerId: 0,
            platformIds: [],
            releaseDate: new Date(),
        },

        updateGameModel: {
            id : 0,
            name: "",
            developerId: 0,
            platformIds: [],
            releaseDate: new Date(),
        },
        selectedGame: {},


        createGameError: "",
        updateGameError: "",

    },

    mounted: async function () {
        await this.showGames();
    },

    methods: {
        showGames: async function () {
            this.loading = true;
            this.reviewsVisible = false;
            this.isAdmin = hasUserAdminRole();
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
            this.error = false;
            this.loading = true;
            await axios.post(`${baseUrl}/games`, this.newGameModel, axiosConfig)
                .then(response => {
                    response.data;
                    $('#createGameModal').modal('hide');
                    this.resetModels();
                    this.showGames();
                })
                .catch(error => {
                    this.createGameError = "";
                    if (error.response.status == 401) {
                        this.errorMessage = "You do not have the rights to add an item";
                        $('#createGameModal').modal('hide');
                        this.resetModels();
                    }
                    else {
                        for (let key in error.response.data.errors) {
                            this.createGameError += `${error.response.data.errors[key]} \n `
                        }
                    }
                    this.hasError = true;
                    
                })
                .finally(() => {
                    this.loading = false;
                });
            
        },

        updateGame: async function () {
            this.updateGameModel.name.trim();
            this.error = false;
            this.loading = true;
            await axios.put(`${baseUrl}/games`, this.updateGameModel, axiosConfig)
                .then(response => {
                    $('#updateGameModal').modal('hide');
                    this.resetModels();
                    this.showGames();
                })
                .catch(error => {
                    this.updateGameError = "";
                    if (error.response.status == 401) {
                        this.errorMessage = "You do not have the rights to update an item";
                        $('#updateGameModal').modal('hide');
                        this.resetModels();
                    }
                    else {
                        for (let key in error.response.data.errors) {
                            this.updateGameError += `${error.response.data.errors[key]} \n `
                        }
                    }
                    this.hasError = true;

                })
                .finally(() => {
                    this.loading = false;
                });
            
        },

        showCreateModal : async function () {
            $('#createGameModal').modal('show');

            await this.loadDevelopersAndPlatforms();
        },
        showUpdateModal: async function (game) {
            $('#updateGameModal').modal('show');
            this.selectedGame = game;
            await this.loadDevelopersAndPlatforms();
            this.setUpdateModelWithGameInfo(game);
        },
        showDeleteModal: function (game) {
            $('#deleteGameConfirmModal').modal('show');
            this.selectedGame = game;

        },

        deleteGame: async function (selectedGameId) {
            this.isLoading = true;
            await axios.delete(`${baseUrl}/Games/${selectedGameId}`, axiosConfig).catch((e) => {
                if (e.response.status === 400) {
                    console.log(e.response.data[0].errorMessage);
                    this.errorMessage = e.response.data[0].errorMessage;
                }
                else {
                    this.errorMessage = e.message;
                }
            });
            $('#deleteGameConfirmModal').modal('hide');
            this.selectedGame = {};
            this.showGames();
        },

        setUpdateModelWithGameInfo: function (game) {
            this.updateGameModel.id = game.id;
            this.updateGameModel.name = game.name;
            this.updateGameModel.developerId = game.developer.id;
            this.updateGameModel.platformIds = game.platforms.map(platform=>platform.id);
            this.updateGameModel.releaseDate = game.releaseDate;
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

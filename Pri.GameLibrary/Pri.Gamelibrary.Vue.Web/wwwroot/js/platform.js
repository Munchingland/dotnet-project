let app = new Vue({
    el: "#platform",
    data: {
        loading: false,
        platforms: [],
        errorMessage: "",
        hasError: false,
        platformsVisible: false,
        selectedPlatform: {},

        newPlatformModel: {
            name: "",
            creationDate: new Date(),

        },

        updatePlatformModel : {
            name: "",
            id: 0,
            creationDate: new Date(),
        },
        gamePage: false,
        isAdmin:false,

        gamesVisible: false,
        games : [],
    },

    mounted: async function () {
        await this.showPlatforms();
    },

    methods: {
        showPlatforms: async function () {
            this.loading = true;
            this.isAdmin = hasUserAdminRole();

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
        },

        deletePlatform: async function (selectedPlatformId) {
            this.isLoading = true;
            await axios.delete(`${baseUrl}/platforms/${selectedPlatformId}`, axiosConfig).catch((e) => {
                if (e.response.status === 400) {
                    console.log(e.response.data[0].errorMessage);
                    this.errorMessage = e.response.data[0].errorMessage;
                }
                else {
                    this.errorMessage = e.message;
                }
            });
            $('#deletePlatformConfirmModal').modal('hide');
            this.selectedPlatform = {};
            this.showPlatforms();
        },
        createPlatform: async function () {
            this.newPlatformModel.name.trim();
            this.loading = true;
            await axios.post(`${baseUrl}/Platforms`, this.newPlatformModel, axiosConfig)
                .catch(e => {
                    hasError = true;
                    if (e.response.status === 401) {
                        this.errorMessage = "Does not posses the required rights to perform this action";
                    }
                    else if (e.response.status == 400) {
                        this.errorMessage = e.response.data[0].errorMessage;
                    }
                    else {
                        this.errorMessage = e.message;
                    }
                })
                .finally(() => {
                    this.loading = false;
                });
            $('#createPlatformModal').modal('hide');
            this.resetPlatformModels();
            this.showPlatforms();
        },
        updatePlatform: async function () {
            this.updatePlatformModel.name.trim();
            this.loading = true;
            await axios.put(`${baseUrl}/Platforms`, this.updatePlatformModel, axiosConfig)
                .catch(e => {
                    hasError = true;
                    if (e.response.status === 401) {
                        this.errorMessage = "Does not posses the required rights to perform this action";
                    }
                    else if (e.response.status == 400) {
                        this.errorMessage = e.response.data[0].errorMessage;
                    }
                    else {
                        this.errorMessage = e.message;
                    }
                })
                .finally(() => {
                    this.loading = false;
                });
            $('#updatePlatformModal').modal('hide');
            this.resetPlatformModels();
            this.showPlatforms();
        },


        showDeleteModal: function (platform) {
            $('#deletePlatformConfirmModal').modal('show');
            this.selectedPlatform = platform;
        },
        showUpdateModal: function (platform) {
            $('#updatePlatformModal').modal('show');
            this.selectedPlatform = platform;
            this.updatePlatformModel.name = platform.name;
            this.updatePlatformModel.id = platform.id;
        },

        showCreateModal: function () {
            $('#createPlatformModal').modal('show');
        },

        cancelPlatformAction: function () {
            this.resetPlatformModels();
        },

        resetPlatformModels: function () {
            this.newPlatformModel = {
                name: "",
                creationDate: new Date(),
            };
            this.updatePlatformModel = {
                name: "",
                platformId: 0,
                creationDate: new Date(),
            };
        }

    },
});

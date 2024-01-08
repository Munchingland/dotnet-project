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

        newDeveloperModel: {
            name: "",
            creationDate: new Date(),
        },

        updateDeveloperModel: {
            name: "",
            id: 0,
            creationDate: new Date(),
        },
        gamePage : false,
        selectedDeveloper: {},

        isAdmin : false,

    },
    mounted: async function () {
        await this.showDevelopers();
    },

    methods: {
        showDevelopers: async function () {
            this.isAdmin = hasUserAdminRole();
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
        },
        createDeveloper: async function () {
            this.newDeveloperModel.name.trim();
            this.loading = true;
            await axios.post(`${baseUrl}/Developers`, this.newDeveloperModel, axiosConfig)
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
            $('#createDeveloperModal').modal('hide');
            this.resetDeveloperModels();
            this.showDevelopers();
        },
        updateDeveloper: async function () {
            this.updateDeveloperModel.name.trim();
            this.loading = true;
            await axios.put(`${baseUrl}/Developers`, this.updateDeveloperModel, axiosConfig)
                .catch(e => {
                    this.error = true;
                    if (e.response.status === 401) {
                        this.errorMessage = "Does not posses the required rights to perform this action";
                    }
                    else if (e.response.status == 400) {
                        this.errorMessage = e.response.data[0].errorMessage;
                    }
                    else {
                        this.errorMessage = e.message;
                    }
                }).finally(() => {
                    this.isLoading = false;
                  });
            $('#updateDeveloperModal').modal('hide');
            this.resetDeveloperModels();
            this.showDevelopers();
        },

        deleteDeveloper: async function (developerId) {
            this.isLoading = true;
            await axios.delete(`${baseUrl}/developers/${developerId}`, axiosConfig).catch((e) => {
                if (e.response.status === 400) {
                    console.log(e.response.data[0].errorMessage);
                    this.errorMessage = e.response.data[0].errorMessage;
                }
                else {
                    this.errorMessage = e.message;
                }
            });
            this.selectedDeveloper = {};
            $('#deleteDeveloperConfirmModal').modal('hide');
            this.showDevelopers();
        },

        showDeleteModal: function (developer) {
            $('#deleteDeveloperConfirmModal').modal('show');
            this.selectedDeveloper = developer;
        },

        showCreateModal: function () {
            $('#createDeveloperModal').modal('show');
        },

        showUpdateModal: function (developer) {
            $('#updateDeveloperModal').modal('show');
            this.selectedDeveloper = developer;
            this.updateDeveloperModel.name = developer.name;
            this.updateDeveloperModel.id = developer.id;
            this.updateDeveloperModel.creationDate = developer.creationDate;
        },

        cancelDeveloperAction: function () {
            this.resetDeveloperModels();
        },

        resetDeveloperModels: function () {

            this.newDeveloperModel = {
                name: "",
                creationDate: new Date,
            };

            this.updateDeveloperModel = {
                name: "",
                id: 0,
                creationDate: new Date,
            };
        },
    },
});

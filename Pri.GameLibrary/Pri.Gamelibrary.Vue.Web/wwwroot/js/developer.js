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
            id : 0
        },
        selectedDeveloper: {},

    },
    mounted: async function () {
        await this.showDevelopers();
        consol.log("hi");
    },
    methods: {
        showDevelopers: async function () {
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
                .then(response => response.data)
                .catch(error => {
                    this.error = true;
                    this.errorMessage = error.message;
                })
                .finally(() => {
                    this.loading = false;
                });
            $('#createDeveloperModal').modal('hide');
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

        cancelDeveloperAction: function () {
            this.resetDeveloperModels();
        },

        resetDeveloperModels: function () {
            this.newDeveloperModel = {
                name : "",
            };
        }
    },
});

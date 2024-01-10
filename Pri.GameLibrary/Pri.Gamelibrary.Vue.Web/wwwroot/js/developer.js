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
            creationDate: "",
        },

        updateDeveloperModel: {
            name: "",
            id: 0,
            creationDate: "",
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
            this.resetError();
            await axios.post(`${baseUrl}/Developers`, this.newDeveloperModel, axiosConfig)
                .then(response => {
                    $('#createDeveloperModal').modal('hide');
                    this.resetDeveloperModels();
                    this.showDevelopers();
                })
                .catch(e => {
                    this.hasError = true;
                    if (e.response.status === 401) {
                        this.errorMessage = "Does not posses the required rights to perform this action";
                    }
                    else {
                        for (let key in e.response.data.errors) {
                            this.errorMessage += `${e.response.data.errors[key]} \n `
                        }
                    }
                })
                .finally(() => {
                    this.loading = false;
                });
           
        },
        updateDeveloper: async function () {
            this.updateDeveloperModel.name.trim();
            this.loading = true;
            this.resetError();
            if (this.updateDeveloperModel.creationDate == undefined) {
                this.errorMessage = "Select a date";
                this.hasError = true;
            }
            else {
                await axios.put(`${baseUrl}/Developers`, this.updateDeveloperModel, axiosConfig)
                    .then(r => {
                        $('#updateDeveloperModal').modal('hide');
                        this.resetDeveloperModels();
                        this.showDevelopers();
                    })
                    .catch(e => {
                        this.hasError = true;
                        if (e.response.status === 401) {
                            this.errorMessage = "Does not posses the required rights to perform this action";
                        }
                        else {
                            for (let key in e.response.data.errors) {
                                this.errorMessage += `${e.response.data.errors[key]} \n `
                            }
                        }
                    }).finally(() => {
                        this.isLoading = false;
                    });
            }
            
            
        },

        deleteDeveloper: async function (developerId) {
            this.isLoading = true;
            await axios.delete(`${baseUrl}/developers/${developerId}`, axiosConfig).catch((e) => {
                if (e.response.status === 400) {
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
            const originalDate = developer.founded; // Assuming this is in "MM/DD/YYYY" format
            const dateParts = originalDate.split('/');
            const formattedDate = new Date(`${dateParts[2]}-${dateParts[1]}-${dateParts[0]}`).toLocaleDateString('en-CA');
            this.updateDeveloperModel.creationDate = formattedDate;
        },

        cancelDeveloperAction: function () {
            this.resetDeveloperModels();
            this.resetError();
        },

        resetDeveloperModels: function () {

            this.newDeveloperModel = {
                name: "",
                creationDate: "",
            };

            this.updateDeveloperModel = {
                name: "",
                id: 0,
                creationDate: "",
            };
        },
        resetError: function () {
            this.errorMessage = "";
            this.hasError = false;
        },
    },
});

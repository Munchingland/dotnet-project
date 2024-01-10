let navbarVue = new Vue({
    el: ".navbar",
    name: "navigation",
    data: {
        loggedIn: false,
        loginModel: {
            email: null,
            password: null,
        },
        error: false,
        token: null,
        isAdmin: false,
        userName : "",

        registerModel: {
            email: null,
            password: null,
            userName: null,
            birthday: '',
            hasApproved: false,
        },

        registerError: false,
        registerErrorInfo: "",

        registerRequest: false,
        errorMessage: "",
    },
    created: function () {
        if (sessionStorage.getItem("token")) {
            this.loggedIn = true;
            this.isAdmin = hasUserAdminRole();
            this.userName = readUserNameFromToken();
        }
        else {
            this.loggedIn = false;
        }
    },
    methods: {
        submitLogin: async function () {
            await axios.post(`${baseUrl}/auth/login`, this.loginModel)
                .then((response) => {
                    sessionStorage.setItem("token", response.data.bearerToken);
                    this.loggedIn = true;
                    this.userName = readUserNameFromToken();
                    this.isAdmin = hasUserAdminRole();
                    this.errorMessage = null;
                }).
                catch((e) => {
                    this.errorMessage = "Login failed!";
                    this.loggedIn = false;
                })
                .finally(() => {
                    this.loginModel.email = "";
                    this.loginModel.password = ""
                    window.location.reload();
                });
            
        },
        submitRegister: async function () {

            await axios.post(`${baseUrl}/auth/register`, this.registerModel)
                .then((response) => {
                    if (response.data == "User created") {
                        this.resetRegister();
                        $('#registerModal').modal('hide');
                    }

                })
                .catch(e => {
                    if (e.response.status == 400) {
                        console.log(e);
                        this.registerErrorInfo = "";
                        for (let key in e.response.data.errors) {
                            this.registerErrorInfo += `${e.response.data.errors[key]} \n `
                        }
                        this.registerError = true; 
                    }
                })
        },

        submitLogout: function () {
            window.sessionStorage.removeItem("token");
            this.loggedIn = false;
            userName = "";
            isAdmin = false;

            this.goToHomePage();
        },

        goToHomePage: function () {
            window.location.href = "/";
        },

        AskForRegister: function () {
            $('#registerModal').modal('show');
        },
        cancelAction: function () {
            this.resetRegister();
        },
        resetRegister: function () {
            this.registerRequest = false;
            this.registerModel = {
                email: null,
                password: null,
                userName: null,
                birthday: '',
                hasApproved: false,
            };
        }
    }
});

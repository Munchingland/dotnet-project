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

        submitLogout: function () {
            window.sessionStorage.removeItem("token");
            this.loggedIn = false;
            userName = "";
            isAdmin = false;

            this.goToHomePage();
        },

        goToHomePage: function () {
            window.location.href = "/";
        }
    }
});

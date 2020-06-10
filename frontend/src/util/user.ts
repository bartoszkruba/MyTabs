enum Role {
    BASIC, ADMIN
}

class User {
    token: string
    username: string
    role: Role

    constructor(token: string, username: string, role: Role) {
        this.token = token;
        this.username = username;
        this.role = role;
    }
}

function getUserFromCookies(): User | null {
    return null;
}

function saveUserInCookies(user: User) {
    console.log("Saving user in cookies")
}

export {getUserFromCookies}
import Role from "@/models/Role";

export default class User {
    id: number
    token: string
    username: string
    role: Role

    constructor(id: number, token: string, username: string, role: Role) {
        this.id = id;
        this.token = token;
        this.username = username;
        this.role = role;
    }
}
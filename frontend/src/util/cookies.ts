import User from "@/models/User"
import Role from "@/models/Role";

export const getUserFromCookies = (): User | null => {
    return null;
}

export const saveUserInCookies = (user: User) => {
    console.log("Saving user in cookies")
}

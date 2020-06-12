import Role from "@/models/Role"

export const stringToRole = (value: string): Role => {
    switch (value.toLowerCase()) {
        case "basic":
            return Role.BASIC;
        case "admin":
            return Role.ADMIN;
        default:
            throw new Error("Invalid value: " + value);
    }
}
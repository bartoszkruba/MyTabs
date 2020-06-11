import {API_URL} from "@/util/constants"
import axios from 'axios';
import User from "@/models/User"

const client = axios.create({baseURL: API_URL})

export const createNewUser = (username: string, email: string, password: string) => {
    return axios.post("user", {username, email, password})
}

export const getUserById = async (id: number) => {
    return null;
}
